using ISO.Interfaces;
using System;

namespace DoomsdayPreppers
{
    public class Valkuil: IDetectable
    {
        public void Activate()
        {
            Open(this);
        }

        public void Open(object sender)
        {
            Console.WriteLine("De valkuil met spiezen gaat open");
        }
    }
}
