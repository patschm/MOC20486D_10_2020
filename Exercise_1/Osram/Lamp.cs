using ISO.Interfaces;
using System;

namespace Osram
{
    public class Lamp : IDetectable
    {
        public void Aan(object sender)
        {
            Console.WriteLine(sender);
            Console.WriteLine("De lamp gaat aan");
        }

        public void Activate()
        {
            Aan(this);
        }
    }
}
