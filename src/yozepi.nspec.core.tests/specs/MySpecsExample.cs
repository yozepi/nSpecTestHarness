namespace yozepi.nspec.core.tests.specs
{
    using yozepi.nespec.core;
    using yozepi.nspec.core.tools;

    class MySpecsExample : nSpecTestHarness
    {
        public MySpecsExample() : base(new AssertionHarness())
        {
        }

        void example_test()
        {
            it["is a test"] = () => { };
        }
    }
}
