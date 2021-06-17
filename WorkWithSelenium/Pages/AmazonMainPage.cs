using OpenQA.Selenium;

namespace PageObjectPattern
{
    public class AmazonMainPage
    {
        private readonly IWebDriver Driver; 
        public AmazonMainPage(IWebDriver driver)
        {
            Driver=driver;
            Driver.Navigate().GoToUrl(@"https://www.amazon.com/");
        }
        IWebElement Filter => Driver.FindElement(By.XPath("//*[@id=\"nav-search-dropdown-card\"]/div"));
        IWebElement Books => Driver.FindElement(By.XPath("//*[@id=\"searchDropdownBox\"]/option[6]"));


    }
}