using NUnit.Framework;

namespace tests
{
    public class CypressSearchTest:GoogleTests
    {
        [Test]
        public void SearchTest()
        {
            TestGoogleSearch("Cypress");
        }
    }
}