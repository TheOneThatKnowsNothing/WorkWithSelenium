using NUnit.Framework;

namespace tests
{
    public class TestingFirstText:GoogleTests
    {
        [Test]
        public void TestFirstText()
        {
            TestGoogleSearch("Java");
        }
    }
    public class SecondFirstText:GoogleTests
    {
        [Test]
        public void TestSecondText()
        {
            TestGoogleSearch("Cypress");
        }
    }
}