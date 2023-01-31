using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace TOCI_III_Project
{
    [TestClass]
    public class UnitTest1
    {
        string Email = "irshaddaniyal3@gmail.com";
        string Password = "pass1234";
        string Pin = "0987";
        LoginPage loginPage = new LoginPage();


        [TestCategory("LoginPositive")]
        [TestMethod]
        public void TestMethod1()
        {
            loginPage.SeleniumInit();
            loginPage.LoginPositive(Email, Password, Pin);
            loginPage.Logout();
            loginPage.CloseIt();
        }

        [TestCategory("LoginNegative")]
        [TestMethod]
        public void TestMethod2()
        {
            loginPage.SeleniumInit();
            loginPage.LoginNegative("irshaddaniyal3@gmail.com", "pass1234", "0021");
            loginPage.CloseIt();
        }

        [TestCategory("LoginNegative")]
        [TestMethod]
        public void TestMethod3()
        {
            loginPage.SeleniumInit();
            loginPage.LoginNegative("irshaddaniyal3@gmail.com", "3822", "0011");
            loginPage.CloseIt();
        }

        [TestCategory("ChangePasswordPositive")]
        [TestMethod]
        public void TestMethod4()
        {
            HomePage homePage = new HomePage();
            loginPage.SeleniumInit();
            loginPage.LoginPositive(Email, Password, Pin);
            homePage.ChangePasswordPositive("3822", "pass1234");
            homePage.CloseIt();
        }

        [TestCategory("ChangePasswordNegative")]
        [TestMethod]
        public void TestMethod5()
        {
            HomePage homePage = new HomePage();
            loginPage.SeleniumInit();
            loginPage.LoginPositive(Email, Password, Pin);
            homePage.ChangePasswordNegative("3822231", "3822", "3822");
            homePage.CloseIt();
        }

        [TestCategory("ChangePasswordNegative")]
        [TestMethod]
        public void TestMethod6()
        {
            HomePage homePage = new HomePage();
            loginPage.SeleniumInit();
            loginPage.LoginPositive(Email, Password, Pin);
            homePage.ChangePasswordNegative("pass1234", "3823422", "35465");
            homePage.CloseIt();
        }

        [TestCategory("UsabilityTestingRouting")]
        [TestMethod]
        public void TestMethod7()
        {
            HomePage homePage = new HomePage();
            homePage.SeleniumInit();
            loginPage.LoginPositive(Email, Password, Pin);
            homePage.RoutingWithDropDown();
            loginPage.Logout();
            homePage.CloseIt();
        }

        [TestCategory("EditAccountDetailsPositive")]
        [TestMethod]
        public void TestMethod8()
        {
            HomePage homePage = new HomePage();
            loginPage.SeleniumInit();
            loginPage.LoginPositive(Email, Password, Pin);
            homePage.EditAccountDetailsPositive("Muhammad", "Dani", "Digevol", "", "irshaddaniyal3@gmail.com", "India");
            homePage.CloseIt();
        }

        [TestCategory("EditAccountDetailsPositive")]
        [TestMethod]
        public void TestMethod9()
        {
            HomePage homePage = new HomePage();
            loginPage.SeleniumInit();
            loginPage.LoginPositive(Email, Password, Pin);
            homePage.EditAccountDetailsPositiveWithImage("Muhammad", "Daniyal", "Digevol.AI", "321", "irshaddaniyal3@gmail.com", "Pakistan", "D:\\UBIT 8th Semester", "pp.jpg");
            homePage.CloseIt();
        }

        [TestCategory("EditAccountDetailsNegative")]
        [TestMethod]
        public void TestMethod10()
        {
            HomePage homePage = new HomePage();
            loginPage.SeleniumInit();
            loginPage.LoginPositive(Email, Password, Pin);
            homePage.EditAccountDetailsNegative("Muhammad", "Daniyal", "Digevol.AI", "321", "daniyali428gmail.com", "Pakistan");
            homePage.CloseIt();
        }

        [TestCategory("AddStore")]
        [TestMethod]
        public void TestMethod11()
        {
            string myStore = "www.testdaniyal56.com";
            HomePage homePage = new HomePage();
            loginPage.SeleniumInit();
            loginPage.LoginPositive(Email, Password, Pin);
            homePage.AddStorePositive(myStore);
            homePage.CloseIt();
            loginPage.SeleniumInit();
            loginPage.LoginPositive(Email, Password, Pin);
            homePage.AddStoreNegative(myStore);
            homePage.CloseIt();
        }

        [TestCategory("DeleteStore")]
        [TestMethod]
        public void TestMethod12()
        {
            HomePage homePage = new HomePage();
            loginPage.SeleniumInit();
            loginPage.LoginPositive(Email, Password, Pin);
            homePage.DeleteAllStore();
            homePage.CloseIt();
        }

        [TestCategory("DeleteStore")]
        [TestMethod]
        public void TestMethod13()
        {
            HomePage homePage = new HomePage();
            loginPage.SeleniumInit();
            loginPage.LoginPositive(Email, Password, Pin);
            homePage.DeleteStore(2);
            homePage.CloseIt();
        }
    }
}
