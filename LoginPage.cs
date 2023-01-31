using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TOCI_III_Project
{
    public class LoginPage : BaseClass
    {
        By loginBtn = By.CssSelector(".navbar-right .btn-link");
        By emailInput = By.Id("input-email");
        By passwordInput = By.Id("input-password");
        By loginSubmit = By.ClassName("btn-lg");
        By PinRoutingCheck = By.CssSelector(".col-md-8 h2");
        By inputPin = By.Id("input-pin");
        By continuePin = By.XPath("//button[text()='Continue']");

        public void LoginPositive(string email, string password, string Pin)
        {
            By copyrightText = By.ClassName("copyright-text");
            string matchingTextForHome = "© Copyright 2023 OpenCart";
            string matchingTextForPin = "Please confirm who you are!";

            driver.FindElement(loginBtn).Click();
            driver.FindElement(emailInput).SendKeys(email);
            driver.FindElement(passwordInput).SendKeys(password);
            driver.FindElement(loginSubmit).Click();
            if (driver.FindElement(PinRoutingCheck).Text == matchingTextForPin)
            {
                driver.FindElement(inputPin).SendKeys(Pin);
                driver.FindElement(continuePin).Click();
            }
            var matchingText = driver.FindElement(copyrightText).Text;
            Assert.AreEqual(matchingTextForHome, matchingText, "Assert Failed and Login Not Performed");
            
        }

        public void LoginNegative(string email, string password, string Pin)
        {
            By invalidText = By.ClassName("alert-danger");
            string matchingTextForInvalidLogin = "No match for E-Mail and/or Password.\r\n×";
            string matchingTextForInvalidPin = "PIN does not match!";
            
            driver.FindElement(loginBtn).Click();
            driver.FindElement(emailInput).SendKeys(email);
            driver.FindElement(passwordInput).SendKeys(password);
            driver.FindElement(loginSubmit).Click();
            if (driver.FindElement(loginBtn).Text != "LOGIN")
            {
                driver.FindElement(inputPin).SendKeys(Pin);
                driver.FindElement(continuePin).Click();
                var matchingText = driver.FindElement(invalidText).Text;
                Assert.AreEqual(matchingTextForInvalidPin, matchingText, "Assert Failed and Login Performed");
            }
            else
            {
                var matchingText = driver.FindElement(invalidText).Text;
                Assert.AreEqual(matchingTextForInvalidLogin, matchingText, "Assert Failed and Login Performed");
            }

        }

        public void Logout()
        {
            By logoutBtnLocator = By.ClassName("btn-black");
            string logoutBtnText = "REGISTER";

            driver.FindElement(logoutBtnLocator).Click();
            var matchingText = driver.FindElement(logoutBtnLocator).Text;
            Assert.AreEqual(logoutBtnText, matchingText, "Assert Failed and Logout activity couldn't perform!");
        }
    }
}
 
