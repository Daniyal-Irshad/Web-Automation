using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenDialogWindowHandler;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V106.HeapProfiler;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TOCI_III_Project
{
    public class HomePage : BaseClass
    {
        //For Change Password
        By chngePassBtn = By.XPath("//a[text()='Change Password']");
        By oldPassInput = By.Id("input-current");
        By newPassInput = By.Id("input-password");
        By confirmPassInput = By.Id("input-confirm");
        By successTextLocator = By.ClassName("alert-success");
        By continueBtn = By.XPath("//button[text()='Continue']");

        //For Account-Details-Edit
        By accDetailsBtn = By.XPath("//a[text()='Account Details']");
        By firstNameInput = By.Id("input-firstname");
        By lastNameInput = By.Id("input-lastname");
        By companyInput = By.Id("input-company");
        By taxIdInput = By.Id("input-tax-id");
        By emailInput = By.Id("input-email");
        By dropDown = By.Id("input-country");
        By clearImgBtn = By.ClassName("btn-default");
        By browseImageBtn = By.ClassName("btn-success");
        By imgInput = By.Id("input-image");
        By submitBtn = By.XPath("//button[text()='Submit']");
        string successTextForAD = "Success: Your account details have been successfully updated!\r\n×";

        //For Add-Store 
        By purchaseLocator = By.XPath("//a[text()=' Purchases']");
        By storeLocator = By.XPath("//a[text()=' Your Stores']");
        By addStoreBtn = By.CssSelector(".text-right .btn-primary");
        By domainInput = By.Id("input-domain");
        By storeTable = By.XPath("//*[@id='store']/tbody");
        By tableRows = By.TagName("tr");
        By rowsOfTable = By.XPath("//*[@id='store']/tbody/tr");
        By tableData = By.TagName("td");
        By emptyStoreLocator = By.ClassName("text-center");
        string emptyStoreText = "No results!";
        int check = 0;



        public void ChangePasswordPositive(string oldPass, string newPass)
        {
            string successText = "Success: Your password has been successfully updated!\r\n×";

            driver.FindElement(chngePassBtn).Click();
            driver.FindElement(oldPassInput).SendKeys(oldPass);
            driver.FindElement(newPassInput).SendKeys(newPass);
            driver.FindElement(confirmPassInput).SendKeys(newPass);
            driver.FindElement(continueBtn).Click();
            var matchingText = driver.FindElement(successTextLocator).Text;
            Assert.AreEqual(successText, matchingText, "Assert Failed and Change Password Activity didn't Perform");
        }
        public void ChangePasswordNegative(string oldPass, string newPass, string newPassConfirm)
        {
            By invalidOldPass = By.ClassName("text-danger");
            string invalidOldPassText = "Your current password is incorrect!";
            string invalidNewPassConfirm = "Password confirmation does not match password!";

            driver.FindElement(chngePassBtn).Click();
            driver.FindElement(oldPassInput).SendKeys(oldPass);
            driver.FindElement(newPassInput).SendKeys(newPass);
            driver.FindElement(confirmPassInput).SendKeys(newPassConfirm);
            driver.FindElement(continueBtn).Click();
            var matchingText = driver.FindElement(invalidOldPass).Text;
            if (matchingText == invalidOldPassText)
            {
                Assert.AreEqual(invalidOldPassText, matchingText, "Assert Failed and Change Password Activity didn't occure a/c to behavior");
            }
            else
            {
                Assert.AreEqual(invalidNewPassConfirm, matchingText, "Assert Failed and Change Password Activity didn't occure a/c to behavior");
            }
        }

        public void RoutingWithDropDown()
        {
            By dropDown = By.ClassName("dropdown");
            By dropDownValue = By.XPath("//ul[contains(@class,'dropdown-menu')]//li//a[text()='OpenCart Partners']");
            By routingMatchTextLocator = By.CssSelector(".container h1");
            string routingMatchText = "Your eCommerce success delivered by seasoned OpenCart experts";

            driver.FindElement(dropDown).Click();
            driver.FindElement(dropDownValue).Click();
            var matchingText = driver.FindElement(routingMatchTextLocator).Text;
            Assert.AreEqual(routingMatchText, matchingText, "Assert Failed and Routing didn't perform");

        }

        public void EditAccountDetailsPositive(string fname, string lname, string company, string taxId, string email, string country)
        {
            driver.FindElement(accDetailsBtn).Click();
            driver.FindElement(firstNameInput).Clear();
            driver.FindElement(firstNameInput).SendKeys(fname);
            driver.FindElement(lastNameInput).Clear();
            driver.FindElement(lastNameInput).SendKeys(lname);
            driver.FindElement(companyInput).Clear();
            driver.FindElement(companyInput).SendKeys(company);
            driver.FindElement(taxIdInput).Clear();
            driver.FindElement(taxIdInput).SendKeys(taxId);
            driver.FindElement(emailInput).Clear();
            driver.FindElement(emailInput).SendKeys(email);
            SelectElement dropDownOptions = new SelectElement(driver.FindElement(dropDown));
            dropDownOptions.SelectByText(country);
            driver.FindElement(submitBtn).Click();
            var matchingText = driver.FindElement(successTextLocator).Text;
            Assert.AreEqual(successTextForAD, matchingText, "Assert Failed and Account Details couldn't be edited");

        }

        public void EditAccountDetailsPositiveWithImage(string fname, string lname, string company, string taxId, string email, string country, string folderPath, string fileName)
        {
            driver.FindElement(accDetailsBtn).Click();
            driver.FindElement(firstNameInput).Clear();
            driver.FindElement(firstNameInput).SendKeys(fname);
            driver.FindElement(lastNameInput).Clear();
            driver.FindElement(lastNameInput).SendKeys(lname);
            driver.FindElement(companyInput).Clear();
            driver.FindElement(companyInput).SendKeys(company);
            driver.FindElement(taxIdInput).Clear();
            driver.FindElement(taxIdInput).SendKeys(taxId);
            driver.FindElement(emailInput).Clear();
            driver.FindElement(emailInput).SendKeys(email);
            SelectElement dropDownOptions = new SelectElement(driver.FindElement(dropDown));
            dropDownOptions.SelectByText(country);
            driver.FindElement(clearImgBtn).Click();
            driver.FindElement(browseImageBtn).Click();
            HandleOpenDialog handleOpenDialog = new HandleOpenDialog();
            handleOpenDialog.fileOpenDialog(folderPath, fileName);
            Thread.Sleep(5000);
            driver.FindElement(submitBtn).Click();
            var matchingText = driver.FindElement(successTextLocator).Text;
            Assert.AreEqual(successTextForAD, matchingText, "Assert Failed and Account Details couldn't be edited");

        }

        public void EditAccountDetailsNegative(string fname, string lname, string company, string taxId, string email, string country)
        {
            By invalidEmailLocator = By.ClassName("text-danger");
            string invalidEmailText = "E-Mail Address does not appear to be valid!";
            driver.FindElement(accDetailsBtn).Click();
            driver.FindElement(firstNameInput).Clear();
            driver.FindElement(firstNameInput).SendKeys(fname);
            driver.FindElement(lastNameInput).Clear();
            driver.FindElement(lastNameInput).SendKeys(lname);
            driver.FindElement(companyInput).Clear();
            driver.FindElement(companyInput).SendKeys(company);
            driver.FindElement(taxIdInput).Clear();
            driver.FindElement(taxIdInput).SendKeys(taxId);
            driver.FindElement(emailInput).Clear();
            driver.FindElement(emailInput).SendKeys(email);
            SelectElement dropDownOptions = new SelectElement(driver.FindElement(dropDown));
            dropDownOptions.SelectByText(country);
            driver.FindElement(submitBtn).Click();
            var matchingText = driver.FindElement(invalidEmailLocator).Text;
            Assert.AreEqual(invalidEmailText, matchingText, "Assert Failed and Account Details editing  couldn't be perform a/c to the behavior");
        }

        public void AddStorePositive(string myStore)
        {

            By successAddLocator = By.ClassName("alert-success");
            string successAddText = "Success: You have modified your stores!\r\n×";

            driver.FindElement(purchaseLocator).Click();
            WaitForElement(storeLocator).Click();
            driver.FindElement(addStoreBtn).Click();
            driver.FindElement(domainInput).SendKeys(myStore);
            driver.FindElement(addStoreBtn).Click();
            var matchingText = driver.FindElement(successAddLocator).Text;
            Assert.AreEqual(successAddText, matchingText, "Assert Failed and Add Store activity couldn't perform!");

        }

        public void AddStoreNegative(string myStore)
        {
            
            By alreadyDomainLocator = By.ClassName("text-danger");
            string alreadyRegisteredText = "Store domain is already registered!";

            driver.FindElement(purchaseLocator).Click();
            WaitForElement(storeLocator).Click();
            driver.FindElement(addStoreBtn).Click();
            driver.FindElement(domainInput).SendKeys(myStore);
            driver.FindElement(addStoreBtn).Click();
            var matchingText = driver.FindElement(alreadyDomainLocator).Text;
            Assert.AreEqual(alreadyRegisteredText, matchingText, "Assert Failed and Add Store activity couldn't perform!");

        }
        int[] getStore()
        {
            int[] arr = new int[2];
            try
            {
                check++;
                int count = WaitForElement(storeTable).FindElements(tableRows).Count();
                int trueStore = WaitForElement(rowsOfTable).FindElements(tableData).Count();
                arr[0] = count;
                arr[1] = trueStore;
                return arr;
            }
            catch (NoSuchElementException)
            {

            }
            catch (WebDriverTimeoutException) { }
            return arr;
        }

        public void DeleteAllStore()
        {
            By deleteStoreBtn = By.XPath("//*[@id='store']/tbody/tr[1]/td[4]/a[2]");

            if (check == 0)
            {
                driver.FindElement(purchaseLocator).Click();
                WaitForElement(storeLocator).Click();
            }

            if (getStore()[0] == 1 && getStore()[1] == 1)
            {
                var matchingText = driver.FindElement(emptyStoreLocator).Text;
                Assert.AreEqual(emptyStoreText, matchingText, "Assert Failed and Add Store activity couldn't perform!");
                return;
            }
            WaitForElement(deleteStoreBtn).Click();
            Thread.Sleep(2000);
            driver.SwitchTo().Alert().Accept();
            DeleteAllStore();
        }

        public void DeleteStore(int storeNum)
        {

            By deleteStoreLocator = By.ClassName("alert-success");
            By deleteStoreBtn = By.XPath(String.Format("//*[@id='store']/tbody/tr[{0}]/td[4]/a[2]",storeNum));
            By storeHeadLocator = By.CssSelector(".col-md-9 h2");
            string storeHeadText = "Your Registered Stores";

            string deleteStoreText = "Success: You have modified your stores!\r\n×";

            driver.FindElement(purchaseLocator).Click();
            WaitForElement(storeLocator).Click();
            if (getStore()[0] == 1 && getStore()[1] == 1)
            {
                var matchingText = driver.FindElement(emptyStoreLocator).Text;
                Console.WriteLine("There is no store present to be deleted!");
                Assert.AreEqual(emptyStoreText, matchingText, "Assert Failed and Add Store activity couldn't perform!");
                return;
            }
            else
            {
                if (getStore()[0] >= storeNum)
                {
                    WaitForElement(deleteStoreBtn).Click();
                    Thread.Sleep(2000);
                    driver.SwitchTo().Alert().Accept();
                    var matchingText = driver.FindElement(deleteStoreLocator).Text;
                    Console.WriteLine("Store deleted successfully!");
                    Assert.AreEqual(deleteStoreText, matchingText, "Assert Failed and Add Store activity couldn't perform!");
                }
                else
                {
                    var matchingText = driver.FindElement(storeHeadLocator).Text;
                    Console.WriteLine("Entered id of Store is not exist, no store is deleted!");
                    Assert.AreEqual(storeHeadText,matchingText,"Assert Failed !");
                }

            }
            
        }
    }
}
