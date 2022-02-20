namespace yozepi.nspec.core.tests.specs
{
    using NSpec;

    class FocusedTestsExample : NSpec.nspec
    {
        [Tag("focus")]
        void example_test()
        {
            it["is a test"] = () => { };
        }
    }
}
