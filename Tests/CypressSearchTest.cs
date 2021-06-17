using NUnit.Framework;

namespace tests
{
    public class CypressSearchTest:TestFramework
    {
        [Test]
        public void SearchTest()
        {
            TestGoogleSearch("Cypress");
        }
    }
}