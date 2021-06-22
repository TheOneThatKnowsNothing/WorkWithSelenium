using System;
using System.Collections.Generic;
using Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObjectPattern;
using System.Linq;

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
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            try
            {
                driver.Navigate().GoToUrl(@"https://www.amazon.com/s?k=Java&i=stripbooks-intl-ship&ref=nb_sb_noss");
                string def = "German Shepherd";
                //driver.FindElement(By.CssSelector(".gLFyf.gsfi")).SendKeys(def);
                //Xpath for Search button
                //driver.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[2]/div[2]/div[2]/center/input[1]")).Click();
                
                List<IWebElement> Books = driver.FindElements(By.XPath("//*[@id=\"search\"]/div[1]/div/div[1]/div/span[3]/div[2]/*[@data-uuid]")).ToList();
                List<Book> books = new List<Book>();                
                foreach(var item in Books)
                {
                    Book a = new Book();
                    a.Name=item.FindElement(By.XPath("div/span/div/div/div[2]/div[2]/div/div[1]/h2/a/span")).Text;
                    
                    
                    foreach(var el in item.FindElements(By.XPath("div/span/div/div/div[2]/div[2]/div/div[1]/div/div/*")))
                    {
                        a.Author+=el.Text+" ";
                    }
                    a.Author.TrimEnd();
                    foreach(var el in item.FindElements(By.XPath("div/span/div/div/div[2]/div[2]/div/div[2 or 3]/div[1]/div/div[1]/div[2]/a/span[1]/span[1]")))
                    {
                        a.Price+=el.GetAttribute("innerHTML");
                    }
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
                    //a.IsBestSeller = IsElementPresent(item,By.XPath("div/span/div/div/div[1]/div/span/div/span/span[1]/span/span"));

                    a.IsBestSeller= item.FindElements(By.XPath("div/span/div/div/div[1]/div/span/div/span/span[1]/span/span")).Count()!=0;

                    Console.WriteLine(a.Name);
                    Console.WriteLine(a.Author);
                    Console.WriteLine(a.Price);
                    Console.WriteLine(a.IsBestSeller);
                }

            }finally{
                driver.Quit();
            }
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
            finally{

            }
        }
    }
}
