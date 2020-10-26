using System;
using System.Collections.Generic;
using System.Text;

namespace VirtueleWereld
{
    abstract class Lamp
    {
        // Field. Hierin slaan wij eigenschappen op.
        private int lumen = 100;


        // Encapsulation
        // door middel van Properties
        public int Lumen
        {
            set
            {
                if (value >= 0 && value < 1000)
                {
                    lumen = value;
                }
            }
            get
            {
                return lumen;
            }
        }
        // Auto generating property.
        public ConsoleColor Kleur { get; set; } = ConsoleColor.Yellow;


        // Gedrag
        // Leg je vast in methods
        // Virtual maakt polymorfisme mogelijk
        // Een afgeleide class _kan_ het polymorfisme activeren (hoeft niet)
        // gebruik abstract om het vrijblijvende eraf te halen
        public abstract void Aan();
        //{
        //    Console.BackgroundColor = Kleur;
        //    Console.WriteLine($"De lamp brand met {Lumen} lumen");
        //}
        public void Uit()
        {
            Console.WriteLine("De lamp is uit");
            Console.ResetColor();
        }

        // Constructors
        // Zijn bedoeld om fields van een initiele waarde te voorzien.
        // Gebruik ze alleen als je zelf geen fatsoenlijke default kunt bedenken.
        public Lamp(int lumen, ConsoleColor color)
        {
            Lumen = lumen;
            Kleur = color;
        }
        // Krijg je normaal by default als je zelf geen constructor maakt.
        public Lamp()
        {

        }
    }
}
