using ISO.Interfaces;
using System;

namespace DoomsdayPreppers
{
    public class Valkuil: IDetectable
    {
        public void Activate()
        {
            Open();
        }

        public void Open()
        {
            Console.WriteLine("De valkuil met spiezen gaat open");
        }
    }
}
