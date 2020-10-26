using System;
using System.Linq;

namespace Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            int x;
            int y;

            //Console.WriteLine($"x={x}, y={y}");
            Swap(out x, out y);
            Console.WriteLine($"x={x}, y={y}");

            var result = TelOp( b:2, a:1);
            ShowNumber(result);
        }

        private static void Swap(out int aa, out int bb)
        {
            aa = 1000;
            bb = 2000;
            int tmp = bb;
            bb = aa;
            aa = tmp;
        }

        // Procedure. Geeft niks terug. Voert alleen uit.
        static void ShowNumber(object nr)
        {
            Console.WriteLine(nr);
        }

        // Function. Geeft altijd een waarde terug
        static int TelOp(int a = 0, int b = 0)
        {
            int r = a + b;
            return r;
        }
        static int TelOp(params int[] nrs)
        {
            int r = nrs.Sum();
            return r;
        }
        static float TelOp(float a, float b)
        {
            return a + b;
        }
    }
}
