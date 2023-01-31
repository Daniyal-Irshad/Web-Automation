using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOCI_III_Project
{
    public class BaseClass
    {
        public static IWebDriver driver;
        public static WebDriverWait wait;
        string EntryPoint_Url = "https://www.opencart.com/index.php?route=cms/demo";
        public IWebDriver SeleniumInit()
        {
            IWebDriver chromeDriver = new ChromeDriver();
            driver = chromeDriver;  
            driver.Manage().Window.Maximize();
            driver.Url = EntryPoint_Url;
            return driver;
        }

        public void CloseIt()
        {
            driver.Close();
        }

        public IWebElement WaitForElement(By by)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            return wait.Until(ExpectedConditions.ElementIsVisible(by));
        }
    }
}
