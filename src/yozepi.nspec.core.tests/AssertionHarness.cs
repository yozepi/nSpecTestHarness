namespace yozepi.nspec.core.tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using yozepi.nspec.core.tools;

    internal class AssertionHarness : ISpecResultAssertions
    {
        public void ReportFailureCount(string message)
        {
            Assert.Fail(message);
        }

        public void ReportInclusive(string message)
        {
            Assert.Inconclusive(message);
        }
    }
}
