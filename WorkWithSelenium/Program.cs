using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObjectPattern;

namespace WorkWithSelenium
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new ChromeOptions();
            options.AddArguments
                (
                    "--start-maximized",
                    "--disable-extensions",
                    "--disable-notifications",
                    "--disable-application-cache"
                );
            IWebDriver driver = new ChromeDriver("C:/WebDriver/bin/",options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            try
            {
                driver.Navigate().GoToUrl(@"https://www.google.com/");
                string input = string.Empty;
                //string def = "German Shepherd";
                do{
                    Console.Write("Please enter what do you want to search:");
                    input=Console.ReadLine();
                }while(string.IsNullOrWhiteSpace(input));
                driver.FindElement(By.CssSelector(".gLFyf.gsfi")).SendKeys(input);
                //Xpath for Search button
                driver.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[2]/div[2]/div[2]/center/input[1]")).Click();   
            }finally{
                driver.Quit();
            }
        }
    }
}
