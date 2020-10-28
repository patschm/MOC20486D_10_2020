using System;
using System.Runtime.CompilerServices;

namespace Generieken
{
    class Test
    {
        public int Iets { get; set; }
    }
    class Point<T> //where T: class, new()
    {
        public T X { get; set; }
        public T Y { get; set; }

        //public static Point<T> Add(Point<T> a, Point<T> b)
        //{
        //    return new Point<T> { X = a.X + b.X, Y = a.Y + b.Y };
        //}

        public override string ToString()
        {
            return $"({X}, {Y})";
        }

        //public static T Create()
        //{
        //    return new T();
        //}
    }


    class Program
    {
        static void Main(string[] args)
        {
            //Test t = Point<Test>.Create();

            var p1 = new Point<int> { X = 10, Y = 20 };
            var p2 = new Point<int> { X = 100, Y = 200 };
            Console.WriteLine($"{nameof(p1)}={p1}, p2={p2}");
            Swap(ref p1, ref p2);
            Console.WriteLine($"p1={p1}, p2={p2}");

            string a = "10";
            string b = "20";

            Console.WriteLine($"a={a}, b={b}");
            Swap<string>(ref a, ref b);
            Console.WriteLine($"a={a}, b={b}");
        }

        static void Swap<T>(ref T aa, ref T bb)
        {
            T tmp = aa;
            aa = bb;
            bb = tmp;
        }

        //static void Swap(ref long aa, ref long bb)
        //{
        //    long tmp = aa;
        //    aa = bb;
        //    bb = tmp;
        //}
        //static void Swap(ref double aa, ref double bb)
        //{
        //    double tmp = aa;
        //    aa = bb;
        //    bb = tmp;
        //}
        //static void Swap(ref int aa, ref int bb)
        //{
        //    int tmp = aa;
        //    aa = bb;
        //    bb = tmp;
        //}
    }
}
