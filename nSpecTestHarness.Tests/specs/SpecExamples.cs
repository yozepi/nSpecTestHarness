using NSpec;

namespace nSpecTestHarness.Tests.specs
{
    class SpecExamples : nspec
    {
        void example_test()
        {
            xit["is a pending test"] = () => { };
        }
    }
}
