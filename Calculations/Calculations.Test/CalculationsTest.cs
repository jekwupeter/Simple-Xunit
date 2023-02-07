using NuGet.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Calculations.Test
{
    public class CalculationsFixture : IDisposable
    {
        public Calculations Calc => new();

        public void Dispose()
        {
            // clean    
        }
    }
    
    public class CalculationsTest : IClassFixture<CalculationsFixture>
    {
        private readonly CalculationsFixture _calculationsFixture;

        public CalculationsTest(CalculationsFixture calculationsFixture)
        {
            _calculationsFixture = calculationsFixture;
        }

        [Fact]
        [Trait("Category","Fibo")]
        public void FiboDoesNotIncludeZero()
        {
            var calc = _calculationsFixture.Calc;
            Assert.All(calc.FibNumbers, x => Assert.NotEqual(0, x) );
        }

        [Fact]
        [Trait("Category", "Fibo")]
        public void FiboNotIncludeFour()
        {
            var calc = _calculationsFixture.Calc;
            Assert.DoesNotContain(4, calc.FibNumbers);
        } 

        [Fact]
        public void CheckCollection()
        {
            var calc = _calculationsFixture.Calc;
            var expectedCollection = new List<int> { 1, 1, 2, 3, 5, 8, 13 };
            Assert.Equal(expectedCollection, calc.FibNumbers);
        }
    }
}
