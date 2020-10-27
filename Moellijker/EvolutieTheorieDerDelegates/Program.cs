using System;

namespace EvolutieTheorieDerDelegates
{
    delegate int MathDel(int a, int b);

    class Program
    {
        static void Main(string[] args)
        {
            // Framework 1.0/1.1 (2002/2003)
            MathDel m1 = new MathDel(Add);
            int result = m1(1, 2);

            // Framework 2.0 (2005)
            MathDel m2 = Add;
            result = m2(2, 3);

            int c = 10;

            MathDel m3 = delegate (int a, int b)
            {
                return a + b;
            };
            result = m3(3, 4);

            // Framework 3.0 (2007)
            // Lambda expressie
            MathDel m4 =  (a, b) => a + b;
            result = m4(4, 5);

            // Functions
            Func<int, int, int> m5 = Add;
            result = m5(5, 6);

            Func<int, int, int> m6 = (a, b) => a + b;
            result = m6(6, 7);

            // Procedures
            Action<int> cw = nr => Console.WriteLine(nr);
            cw(result);

            // C# 8.0
            int InlineAdd(int a, int b)
            {
                return a + b;
            }

            result = InlineAdd(7, 8);
            cw(result);
            //Console.WriteLine(result);
        }

        static int Add(int a, int b)
        {
            return a + b;
        }
    }
}
