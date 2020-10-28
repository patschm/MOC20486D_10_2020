using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataHost.SomeClasses
{
    public class Calculator : ICalculator
    {
        private int x = 10;

        public int Add(int a, int b)
        {
            x++;
            return a + b + x;
        }
    }
}
