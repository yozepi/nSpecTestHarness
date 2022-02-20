namespace yozepi.nspec.core.tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using yozepi.nespec.core;
    using yozepi.nspec.core.tests.specs;
    using yozepi.nspec.core.tools;

    [TestClass]
    public class nSpecTestHarness_UnitTests : nSpecTestHarness
    {
        public nSpecTestHarness_UnitTests() : base(new AssertionHarness())
        {
        }

        [TestMethod]
        public void Specs()
        {
            RunSpecs(() => new Type[] { typeof(TestHarness_Specs) });
        }
    }
}
