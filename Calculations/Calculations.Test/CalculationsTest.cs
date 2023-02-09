using NuGet.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

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
    
    public class CalculationsTest : IClassFixture<CalculationsFixture>, IDisposable
    {
        private readonly CalculationsFixture _calculationsFixture;
        private readonly ITestOutputHelper testOutputHelper;
        private readonly MemoryStream stream;

        public CalculationsTest(CalculationsFixture calculationsFixture, ITestOutputHelper testOutputHelper)
        {
            _calculationsFixture = calculationsFixture;
            this.testOutputHelper = testOutputHelper;
            stream = new MemoryStream();

            testOutputHelper.WriteLine("Constructor");
        }

        [Fact]
        [Trait("Category","Fibo")]
        public void FiboDoesNotIncludeZero()
        {
            testOutputHelper.WriteLine("FiboDoesNotIncludeZero");
            var calc = _calculationsFixture.Calc;
            Assert.All(calc.FibNumbers, x => Assert.NotEqual(0, x) );
        }

        [Fact]
        [Trait("Category", "Fibo")]
        public void FiboNotIncludeFour()
        {
            testOutputHelper.WriteLine("FiboNotIncludeFour");
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

        [InlineData(1, true)]
        [InlineData(4, false)]
        [Theory]
        public void CheckOddNumber_TestOddAndEven(int num, bool expected)
        {
            var Calc = _calculationsFixture.Calc;
            var result = Calc.CheckOddNumber(num);
            Assert.Equal(expected, result);
        }

        [MemberData(nameof(TestDataShare.IsOddOr_EvenData), MemberType = typeof(TestDataShare))]
        [Theory]
        public void CheckOddNumber_TestOddAndEvenUsingMemberData(int num, bool expected)
        {
            var Calc = _calculationsFixture.Calc;
            var result = Calc.CheckOddNumber(num);
            Assert.Equal(expected, result);
        }

        public void Dispose()
        {
            stream.Close();
        }
    }
}
