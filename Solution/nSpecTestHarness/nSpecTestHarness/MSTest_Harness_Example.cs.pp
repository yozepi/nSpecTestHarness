using Microsoft.VisualStudio.TestTools.UnitTesting;
using yozepi;

namespace $rootnamespace$.yozepi
{
    //A simple example of running specs in MS UnitTestFramework 
    //[TestClass]
    public class MSTest_Harness_Example : nSpecTestHarness
    {
        //[TestMethod]
        public void TestTheSpecs()
        {
            this.RunMySpecs();
        }

        void sample_spec()
        {
            var beautifulDay = true;
            it["should be a beautiful day"] = () =>
                Assert.IsTrue(beautifulDay);
        }
    }
}
