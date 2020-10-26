using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VirtueleWereld
{
    // Overerving.
    // Bevordert het hergebruik.
    // Je mag maar van een class tegelijk erven.
    class TL: Lamp
    {
        public int StartTijd { get; set; } = 1000;
        public override void Aan()
        {
            for (int i = 0; i < StartTijd / 100; i++)
            {
                Console.BackgroundColor = Kleur;
                Console.WriteLine("Knipper");
                Task.Delay(100).Wait();
                Console.ResetColor();
            }
            Console.BackgroundColor = Kleur;
            Console.WriteLine($"De TL brand met {Lumen} lumen");
        }
    }
}
