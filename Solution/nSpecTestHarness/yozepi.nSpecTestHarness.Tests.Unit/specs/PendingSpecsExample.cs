using NSpec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yozepi.Tests.Unit.specs
{
    class PendingSpecsExample : nspec
    {
        void example_test()
        {
            xit["is a pending test"] = () => { };
        }
    }
}
