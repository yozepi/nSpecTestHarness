using NSpec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yozepi.Tests.Unit.specs
{
    class FocusedTestsExample: nspec
    {
        [Tag("focus")]
        void example_test()
        {
            it["is a test"] = () => { };
        }
    }
}
