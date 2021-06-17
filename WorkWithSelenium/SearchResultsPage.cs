using OpenQA.Selenium;

namespace PageObjectPattern
{
    public class SearchResultsPage
    {
        private readonly IWebDriver Driver;
        public SearchResultsPage(IWebDriver driver)
        {
           Driver = driver;
        }
    }
}