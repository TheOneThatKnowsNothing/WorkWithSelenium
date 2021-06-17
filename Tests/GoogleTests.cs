using NUnit.Framework;
using WorkWithSelenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using PageObjectPattern;
using System;

namespace tests
{
    public class GoogleTests
    {
        public IWebDriver Driver { get; set; }
        //public WebDriverWait Wait { get; set; }
        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArguments
                (
                    "--start-maximized",
                    "--disable-extensions",
                    "--disable-notifications",
                    "--disable-application-cache"
                );
            Driver = new ChromeDriver("C:/WebDriver/bin/",options);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Driver.Navigate().GoToUrl(@"https://www.google.com/");
        }
        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }

        //[Test]
        public void TestGoogleSearch(string input)
        {
            GoogleMainPage page = new GoogleMainPage(Driver);
            page.InputSearch(input);
            Assert.IsNotNull(page.ClickSearch());
        }
    }
    
}