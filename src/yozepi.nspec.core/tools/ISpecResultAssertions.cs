namespace yozepi.nspec.core.tools
{
    public interface ISpecResultAssertions
    {
        public void ReportFailureCount(string message);

        public void ReportInclusive(string message);
    }
}
