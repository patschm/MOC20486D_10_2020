using System;

namespace HumanCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            WillemKlein wk = new WillemKlein();
            SimonVdMeer sm = new SimonVdMeer();

            wk.RekenUit(sm.Add);
            wk.RekenUit(sm.Subtract);
        }
    }
}
