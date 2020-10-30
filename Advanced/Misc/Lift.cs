using System;

namespace Misc
{
    public class Lift
    {
        private int etageNummer = 0;

        public void Call(int etNr)
        {
            Console.WriteLine("Lift komt eraan");
            etageNummer = etNr;
        }
        public int CurrentFloor
        {
            get
            {
                return etageNummer;
            }
        }
    }
}