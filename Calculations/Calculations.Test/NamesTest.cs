using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Calculations.Test
{
    public class NamesTest
    {
        [Fact]
        public void AddName_GivenTwoStringValue_ReturnsString()
        {
            var names = new Names();
            var result = names.AddNames("John", "Doe");
            Assert.Equal("John Doe", result, ignoreCase: true);
            Assert.StartsWith("John", result); // regex can be used for comparison
        }

        [Fact]
        public void NickName_MustBeNull()
        {
            var names = new Names();
            names.NickName = "test";
            Assert.NotNull(names.NickName);
        }

        [Fact]
        public void AddNames_AlwaysReturnsValue() 
        {
            var names = new Names();
            var result = names.AddNames("Test", "Make");
            Assert.NotNull(result);
            Assert.True(!string.IsNullOrEmpty(result));
        } 
    }
}
