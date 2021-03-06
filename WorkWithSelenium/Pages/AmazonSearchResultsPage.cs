using System.Collections.Generic;
using System.Linq;
using Models;
using OpenQA.Selenium;

namespace PageObjectPattern
{
    public class AmazonSearchResultsPage
    {
        private readonly IWebDriver Driver;
        public AmazonSearchResultsPage(IWebDriver driver)
        {
           Driver = driver;
        }
        List<IWebElement> BooksData => Driver.FindElements(By.XPath("//*[@id=\"search\"]/div[1]/div/div[1]/div/span[3]/div[2]/*[@data-uuid]")).ToList();
        public List<Book> ReturnBooks()
        {
            List<Book> books = new List<Book>();                
            foreach(var item in this.BooksData)
            {
                Book a = new Book();
                a.Name=item.FindElement(By.XPath("div/span/div/div/div[2]/div[2]/div/div[1]/h2/a/span")).Text.Trim();
                foreach(var el in item.FindElements(By.XPath("div/span/div/div/div[2]/div[2]/div/div[1]/div/div/*")))
                {
                    a.Author+=el.Text+" ";
                }
                a.Author=a.Author.Trim();
                if(item.FindElements(By.XPath("div/span/div/div/div[2]/div[2]/div/div[2 or 3]/div[1]/div/div[1]/div[2]")).Count!=0)
                {
                    IWebElement priceBox = item.FindElement(By.XPath("div/span/div/div/div[2]/div[2]/div/div[2 or 3]/div[1]/div/div[1]/div[2]"));
                    foreach(var el in priceBox.FindElements(By.XPath("a/span[1]/span[1] | a[1]/span[3] | a[2]/span[3] | a[2]/span[1]")))
                    {                                  // div/span/div/div/div[2]/div[2]/div/div[3]/div[1]/div/div[1]/div[1]/a  
                        a.Price+=el.GetAttribute("innerHTML")+" ";
                    }
                    a.Price=a.Price.Trim();
                }

                //a.IsBestSeller = IsElementPresent(item,By.XPath("div/span/div/div/div[1]/div/span/div/span/span[1]/span/span"));
                a.IsBestSeller= item.FindElements(By.XPath("div/span/div/div/div[1]/div/span/div/span/span[1]/span/span")).Count()!=0;
                books.Add(a);
            }
            return books;
        }

    }
}