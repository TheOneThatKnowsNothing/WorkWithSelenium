using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace PageObjectPattern
{
    public class GoogleMainPage
    {
        private readonly IWebDriver Driver; 
        public GoogleMainPage(IWebDriver driver)
        {
            Driver=driver;
            this.Driver.Manage().Window.Maximize();
        }
        [FindsBy(How = How.CssSelector, Using = ".gLFyf.gsfi")]
        IWebElement SearchBox { get; set; }
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[3]/form/div[1]/div[1]/div[2]/div[2]/div[2]/center/input[1]")]
        IWebElement SearchButton { get; set; }
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[3]/form/div[1]/div[1]/div[2]/div[2]/div[2]/center/input[2]")]
        IWebElement DoodlesButton { get; set; }
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
        public SearchResultsPage ClickSearch(string textToType)
        {
            if(string.IsNullOrWhiteSpace(this.SearchBox.Text))
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