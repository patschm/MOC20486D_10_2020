using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataHost.SomeClasses
{
    public class SuperCalculator : ICalculator
    {
        public int Add(int a, int b)
        {
            return a - b;
        }
    }
}
