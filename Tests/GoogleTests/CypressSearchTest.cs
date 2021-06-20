using NUnit.Framework;
using PageObjectPattern;

namespace tests
{
    public class CypressSearchTest:TestFramework
    {
        //[Test]
        public void CypressSearch()
        {
            GoogleMainPage page = new GoogleMainPage(Driver);
            page.InputSearch("Cypress");
            Assert.IsNotNull(page.ClickSearch());
        }
    }
}