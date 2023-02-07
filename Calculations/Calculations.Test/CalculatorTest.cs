using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Calculations.Test
{
    public class CalculatorTest
    {
        [Fact]
        public void Add_GivenTwoIntValues_ReturnsInt()
        {
            var calc = new Calculator();
            var result = calc.Add(1, 3);
            Assert.Equal(4, result);
        }

        [Fact]
        public void AddDouble_GivenTwoDoubleValues_ReturnsDouble()
        {
            var calc = new Calculator();
            var result = calc.AddDouble(1.222, 3.5);
            Assert.Equal(4.7, result, 1);
        }

    }
}
