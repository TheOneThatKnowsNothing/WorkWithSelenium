using NUnit.Framework;

namespace tests
{
    public class JavaSearchTest:TestFramework
    {
        [Test]
        public void SearchTest()
        {
            TestGoogleSearch("Java");
        }
    }
}