using NUnit.Framework;
using PageObjectPattern;

namespace tests
{
    public class AmazonTest:TestFramework
    {
        [Test]
        public void JavaSearchTest()
        {
            AmazonMainPage searchPage = new AmazonMainPage(Driver);
            searchPage.InputSearch("Java");
            searchPage.OpenFilter();
            searchPage.CheckBooks();
            AmazonSearchResultsPage resPage = searchPage.ClickSearch();
            var books = resPage.PopulateBooks();
            //Assert.Contains()
            //Assert.IsNotNull();
        }
    }
}