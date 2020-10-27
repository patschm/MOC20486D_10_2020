using System;

namespace LazyPeople
{
    // Blauwdruk van een functie
    // Dit is een type definitie!!!!
    delegate void Job(int bla);

    internal class Boris
    {
        public void VoerDitUit(Job funktie)
        {
            Console.WriteLine("Boris gaat de volgende taak uitvoeren:");

            ///* wat komt er terug? */ funktie(/*welke argumenten?*/);

            funktie(5);

        }
    }
}