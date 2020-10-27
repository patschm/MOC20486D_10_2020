using ISO.Interfaces;
using System;

namespace Heras
{
    public class Hek: IDetectable
    {
        public void Activate()
        {
            Open(this);
        }

        public void Open(object sender)
        {
            Console.WriteLine("Het hek gaat open");
        }
    }
}
