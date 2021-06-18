using OpenQA.Selenium;

namespace PageObjectPattern
{
    public class GoogleSearchResultsPage
    {
        private readonly IWebDriver Driver;
        public GoogleSearchResultsPage(IWebDriver driver)
        {
           Driver = driver;
        }
    }
}