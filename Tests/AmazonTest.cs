using NUnit.Framework;
using PageObjectPattern;

namespace tests
{
    public class AmazonTest:TestFramework
    {
        [Test]
        public void JavaSearchTest()
        {
        AmazonMainPage page = new AmazonMainPage(Driver);
        page.InputSearch("Java");
        page.OpenFilter();
        page.CheckBooks();
        page.ClickSearch();
        //Assert.IsNotNull();
        }
    }
}