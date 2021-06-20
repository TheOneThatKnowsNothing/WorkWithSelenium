using NUnit.Framework;
using PageObjectPattern;
namespace tests
{
    public class JavaSearchTest:TestFramework
    {
        //[Test]
        public void JavaSearch()
        {
            GoogleMainPage page = new GoogleMainPage(Driver);
            page.InputSearch("Java");
            Assert.IsNotNull(page.ClickSearch());
        }
    }
}