using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace Calculations.Test
{
    [Collection("Customer")]
    public class CustomerDetailsTest
    {
        private readonly CustomerFixture customerFixture;

        public CustomerDetailsTest(CustomerFixture customerFixture)
        {
            this.customerFixture = customerFixture;
        }
    
        [Fact]
        public void GetFullName_GivenFirstAndLastName_ReturnFullName()
        {
            Assert.Equal("John Doe", customerFixture.Cust.GetFullName("John", "Doe"));
        }

    }
}
