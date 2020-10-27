using System;

namespace LazyPeople
{
    class Program
    {
        static void Main(string[] args)
        {
            Alfred alfred = new Alfred();
            Boris boris = new Boris();

            int age = 10;
            Job k = alfred.Taak;
 
            boris.VoerDitUit(alfred.Taak);
            boris.VoerDitUit(Ontplof);

        }

        static void Ontplof(int aantal)
        {
            Console.WriteLine($"Ontplof {aantal} keer");
        }
    }
}
