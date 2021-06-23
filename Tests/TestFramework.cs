using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace tests
{
    public class TestFramework
    {
        public IWebDriver Driver { get; set; }
        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArguments
                (
                    "--incognito",
                    "--start-maximized",
                    "--disable-extensions",
                    "--disable-notifications",
                    "--disable-application-cache"
                );
            Driver = new ChromeDriver("C:/WebDriver/bin/",options);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        }
        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
        public static bool IsElementPresent(IWebElement element,By by)
        {
            try
            {
                element.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
    }
    
}