using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using yozepi.Tests.Unit.specs;

namespace yozepi.Tests.Unit
{
    [TestClass]
    public class nSpecTestHarness_UnitTests : nSpecTestHarness
    {
        [TestMethod]
        public void Specs()
        {
            RunSpecs(() => new Type[] { typeof(TestHarness_Specs) });
        }
    }
}
