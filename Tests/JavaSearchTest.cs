using NUnit.Framework;

namespace tests
{
    public class JavaSearchTest:GoogleTests
    {
        [Test]
        public void SearchTest()
        {
            TestGoogleSearch("Java");
        }
    }
}