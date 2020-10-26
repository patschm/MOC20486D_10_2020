using System;

namespace VirtueleWereld
{
    class Program
    {
        static void Main(string[] args)
        {
            // Virtuele big bang

            // Generaliseren!
            Lamp l1 = new TL();// (200, ConsoleColor.Green);

            // Property initializers
            l1 = new TL { 
                Lumen = -300, 
                Kleur = ConsoleColor.Cyan,
                StartTijd = 500
            };

            //(l1 as TL).StartTijd = 300;
            //l1.Lumen = 200;
            //Console.WriteLine(l1.Lumen);

           // l1.lumen = 1000;
           // l1.kleur = ConsoleColor.Red;
            
            l1.Aan();
            Console.WriteLine("jklsejdfkls");
            l1.Uit();



            // Big crunch
        }
    }
}
