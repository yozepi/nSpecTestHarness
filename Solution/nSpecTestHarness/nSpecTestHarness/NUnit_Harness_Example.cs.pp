using NUnit.Framework;
using yozepi;

namespace $rootnamespace$.yozepi
{
    //[TestFixture]
    public class NUnit_Harness_Example : nSpecTestHarness
    {
        //A simple example of running specs in NUnit 
        //[Test]
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
