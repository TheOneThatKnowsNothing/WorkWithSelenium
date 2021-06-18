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
        IWebElement SearchBox => Driver.FindElement(By.XPath("//*[@id=\"twotabsearchtextbox\"]"));
        IWebElement SearchButton => Driver.FindElement(By.XPath("//*[@id=\"nav-search-submit-button\"]"));
        
        public void OpenFilter()
        {
            this.Filter.Click();
        }
        public void OpenBooks()
        {
            this.Books.Click();
        }

        public void ClearSearchBox()
        {
            this.SearchBox.Clear();
        }
        public void InputSearch(string textToType)
        {
            this.SearchBox.SendKeys(textToType);
        }
        public AmazonSearchResultsPage ClickSearch()
        {
            string Input= SearchBox.GetAttribute("value");
            if(string.IsNullOrWhiteSpace(Input))
                return null;
            this.SearchButton.Click();
            return new AmazonSearchResultsPage(this.Driver);
        }

    }
}