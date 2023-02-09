using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculations
{
    public class Calculations
    {
        public List<int> FibNumbers => new() { 1, 1, 2, 3, 5, 8, 13};

        public bool CheckOddNumber(int number)
        {
            return (number % 2) == 1;
        }
    }
}
