namespace nSpecTestHarness.Tests.specs
{
    class PendingSpecsExample : yozepi.nSpecTestHarness
    {
        void example_test()
        {
            xit["is a pending test"] = () => { };
        }
    }
}
