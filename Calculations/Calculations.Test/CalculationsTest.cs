using NuGet.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Calculations.Test
{
    public class CalculationsTest
    {
        [Fact]
        public void FiboDoesNotIncludeZero()
        {
            var calc = new Calculations();
            Assert.All(calc.FibNumbers, x => Assert.NotEqual(0, x) );
        }

        [Fact]
        public void FiboNotIncludeFour()
        {
            var calc = new Calculations();
            Assert.DoesNotContain(4, calc.FibNumbers);
        }

        [Fact]
        public void CheckCollection()
        {
            var calc = new Calculations();
            var expectedCollection = new List<int> { 1, 1, 2, 3, 5, 8, 13 };
            Assert.Equal(expectedCollection, calc.FibNumbers);
        }
    }
}
