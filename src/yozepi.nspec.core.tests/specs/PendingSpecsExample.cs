namespace yozepi.nspec.core.tests.specs
{
    class PendingSpecsExample : NSpec.nspec
    {
        void example_test()
        {
            xit["is a pending test"] = () => { };
        }
    }
}
