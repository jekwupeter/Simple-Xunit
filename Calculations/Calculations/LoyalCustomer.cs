using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculations
{
    public class LoyalCustomer : Customer
    {
        public int Discount { get; set; }

        public LoyalCustomer()
        {
            Discount = 10;
        }

        public override int GetOrdersByName(string Name)
        {
            return 1;
        }

        public static class CustomerFactory
        {
            public static Customer CreateCustomerInstance(int orderCount)
            {
                if (orderCount <= 50)
                {
                    return new Customer();
                }
                else
                {
                    return new LoyalCustomer();
                }
            }
        }
    }
}
