using NUnit.Framework;
using PageObjectPattern;
using Models;
using System.Linq;

namespace tests
{
    public class AmazonTest:TestFramework
    {
        [Test]
        public void SearchTest()
        { 
            Book toCompare=new Book{
                Name ="Head First Java, 2nd Edition",
                Author="by Kathy Sierra and Bert Bates  |  May 11, 2009",
                Price="$17.15 to rent",
                IsBestSeller=false
            };
            AmazonMainPage searchPage = new AmazonMainPage(Driver);
            searchPage.InputSearch("Java");
            searchPage.OpenFilter();
            searchPage.CheckBooks();
            AmazonSearchResultsPage resPage = searchPage.ClickSearch();
            
            var books = resPage.ReturnBooks();
            Assert.That(books.Any(p => p.Equals(toCompare)));
        }
    
    }
}