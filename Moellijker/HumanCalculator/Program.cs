using System;

namespace HumanCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            WillemKlein wk = new WillemKlein();
            SimonVdMeer sm = new SimonVdMeer();

            Berekening b1 = sm.Add;
            b1 += sm.Subtract;
            b1 += sm.Add;
            b1 -= sm.Subtract;
            b1 += SchrodingerVergelijking;
            b1 += SchrodingerVergelijking;

            // Multicast delegate
            foreach(var item in b1.GetInvocationList())
            {
                Console.WriteLine(item.Method.Name);
            }

            int result = b1(1, 2);
            Console.WriteLine(result);

            //wk.RekenUit(b1);

            //wk.RekenUit(sm.Add);
            //wk.RekenUit(sm.Subtract);
            //wk.RekenUit(SchrodingerVergelijking);
        }

        static int SchrodingerVergelijking(int x, int y)
        {
            return x * y;
        }
    }
}
