using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yozepi.Tests.Unit.specs
{
    class MySpecsExample: nSpecTestHarness
    {
        void example_test()
        {
            it["is a test"] = () => { };
        }
    }
}
