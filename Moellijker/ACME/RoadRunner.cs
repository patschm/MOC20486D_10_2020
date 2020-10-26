using System;
using System.Collections.Generic;
using System.Text;

namespace ACME
{
    class RoadRunner : IContract
    {
        public void Werken()
        {
            Werkt();
        }

        public  void Werkt()
        {
            Console.WriteLine("Roadrunner bliep bliep");
        }
    }
}
