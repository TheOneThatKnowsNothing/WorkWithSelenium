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
    }
}