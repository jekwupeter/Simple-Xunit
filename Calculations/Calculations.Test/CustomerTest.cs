using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static Calculations.LoyalCustomer;

namespace Calculations.Test
{
    public class CustomerTest
    {
        [Fact]
        public void CheckNameNotEmpty()
        {
            var customer = new Customer();
            Assert.NotNull(customer.Name);
            Assert.False(string.IsNullOrEmpty(customer.Name));

        }

        [Fact]
        public void CheckAgeForDiscount()
        {
            var customer = new Customer();
            Assert.InRange(customer.Age, 10, 50);
        }

        [Fact]
        public void CheckGetOrdersByNameNotNull()
        {
            var customer = new Customer();
            Assert.Throws<ArgumentException>(() => customer.GetOrdersByName(null));
        }

        [Fact]
        public void CheckGetOrdersByNameExceptionMessage()
        {
            var customer = new Customer();
            var exceptionDetails = Assert.Throws<ArgumentException>(() => customer.GetOrdersByName(null));
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
