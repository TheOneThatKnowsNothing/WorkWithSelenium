using System;
using OpenQA.Selenium;


namespace PageObjectPattern
{
    public class GoogleMainPage
    {
        private readonly IWebDriver Driver; 
        public GoogleMainPage(IWebDriver driver)
        {
            Driver=driver;
        }
        IWebElement SearchBox => Driver.FindElement(By.CssSelector(".gLFyf.gsfi"));
        IWebElement SearchButton => Driver.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[2]/div[2]/div[2]/center/input[1]"));
        IWebElement DoodlesButton => Driver.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[2]/div[2]/div[2]/center/input[2]"));

        // public GoogleMainPage GetGoogleMainPage()
        // {

        // } 
        public void ClearSearch()
        {
             this.SearchBox.Clear();
        }
        public void InputSearch(string textToType)
        {
            this.SearchBox.SendKeys(textToType);
        }
        public SearchResultsPage ClickSearch()
        {
            string Input= SearchBox.GetAttribute("value");
            if(string.IsNullOrWhiteSpace(Input))
                return null;
            this.SearchButton.Click();
            return new SearchResultsPage(this.Driver);
        }
        public void ClickDoodles()
        {
            this.DoodlesButton.Click();
        }
    }
}