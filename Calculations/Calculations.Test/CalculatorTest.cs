using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Calculations.Test
{
    public class CalculatorFixture : IDisposable
    {
        public Calculator Calc => new Calculator();

        public void Dispose()
        {
            // clean
        }
    }                             
    public class CalculatorTest : IClassFixture<CalculatorFixture>
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly MemoryStream _memoryStream;
        private readonly CalculatorFixture _calculatorFixture; //injected as singleton instance

        public CalculatorTest(ITestOutputHelper testOutputHelper, CalculatorFixture calculatorFixture)
        {
            _testOutputHelper = testOutputHelper;
            _memoryStream = new MemoryStream();
            _calculatorFixture = calculatorFixture;

            _testOutputHelper.WriteLine("Constructor");

            
        }

        [Fact]
        public void Add_GivenTwoIntValues_ReturnsInt()
        {
            var calc = _calculatorFixture.Calc;
            var result = calc.Add(1, 3);
            Assert.Equal(4, result);
        }

        [Fact]
        public void AddDouble_GivenTwoDoubleValues_ReturnsDouble()
        {
            var calc = _calculatorFixture.Calc;
            var result = calc.AddDouble(1.222, 3.5);
            Assert.Equal(4.7, result, 1);
        }

    }
}
