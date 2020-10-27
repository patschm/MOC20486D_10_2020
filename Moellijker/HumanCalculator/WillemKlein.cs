using System;
using System.Collections.Generic;
using System.Text;

namespace HumanCalculator
{
    delegate int Berekening(int dummy1, int dummy2);

    class WillemKlein
    {
        public void RekenUit(Berekening berekening)
        {
            Console.WriteLine("Willem Klein gaat nu rekenen....");
            int res = berekening(2, 3);

            //....

            Console.WriteLine($"Willem Klein roept: Het antwoord is: {res}");
        }
    }
}
