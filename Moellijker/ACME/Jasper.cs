using System;
using System.Collections.Generic;
using System.Text;

namespace ACME
{
    class Jasper: Werknemer
    {
        public void DoetIets()
        {
            Console.WriteLine("Jasper doet iets");
        }
        public override void Werkt()
        {
            DoetIets();
        }
    }
}
