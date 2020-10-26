using System;

namespace EigenTypes
{
    enum Weekdagen: ulong
    { 
        Zondag =1 ,
        Maandag = 2,
        Dinsdag = 4,
        Woensdag = 8,
        Donderdag = 16,
        Vrijdag = 32,
        Zaterdag = 64
    }


    class Program
    {
        static void Main(string[] args)
        {
            int dag = 2;
            Weekdagen dag2 = (Weekdagen)dag;
            Console.WriteLine(dag2);
        }
    }
}
