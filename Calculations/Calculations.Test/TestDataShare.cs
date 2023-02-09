using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculations.Test
{
    public static class TestDataShare
    {
        public static IEnumerable<object[]> IsOddOr_EvenData{
            get{
                yield return new object[] { 1, true };
                yield return new object[] { 6, false };
            }
        }
    }
}
