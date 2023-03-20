using NSpec;

namespace nSpecTestHarness.Tests.specs
{
    class FocusedTestsExample: yozepi.nSpecTestHarness
    {
        [Tag("focus")]
        void example_test()
        {
            it["is a test"] = () => { };
        }
    }
}
