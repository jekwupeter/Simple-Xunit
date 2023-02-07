using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using static Calculations.LoyalCustomer;

namespace Calculations.Test
{
    [Collection("Customer")]
    public class CustomerTest
    {
        private readonly CustomerFixture _fixture;
        private readonly ITestOutputHelper testOutputHelper;

        public CustomerTest(CustomerFixture fixture, ITestOutputHelper testOutputHelper)
        {
            _fixture = fixture;
            this.testOutputHelper = testOutputHelper;
        }
    
        [Fact]
        public void CheckNameNotEmpty()
        {
            // var customer = new Customer();
            Assert.NotNull(_fixture.Cust.Name);
            Assert.False(string.IsNullOrEmpty(_fixture.Cust.Name));

        }

        [Fact]
        public void CheckAgeForDiscount()
        {
            Assert.InRange(_fixture.Cust.Age, 10, 50);
        }

        [Fact]
        public void CheckGetOrdersByNameNotNull()
        {
            Assert.Throws<ArgumentException>(() => _fixture.Cust.GetOrdersByName(null));
        }

        [Fact]
        public void CheckGetOrdersByNameExceptionMessage()
        {
            var exceptionDetails = Assert.Throws<ArgumentException>(() => _fixture.Cust.GetOrdersByName(null));
            Assert.Equal("Null name", exceptionDetails.Message);
        }

        [Fact]
        public void LoyalCustomerForOrdersGT50()
        {
            var customer = CustomerFactory.CreateCustomerInstance(60);
            Assert.IsType(typeof(LoyalCustomer), customer);
            
            var loyalCustomer = Assert.IsType<LoyalCustomer>(customer); // returns object casted to loyalCustomer
            Assert.Equal(10, loyalCustomer.Discount);
        }
    }
}
