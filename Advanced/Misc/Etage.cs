using System;
using System.IO;

namespace Misc
{
    public class Etage
    {
        public int EtageNummer { get; set; }
        public static Lift Elevator { get; set; } = new Lift();

        public void CallElevator()
        {
            Elevator.Call(EtageNummer);
        }
        public void ShowStatus()
        {
            Console.WriteLine($"De lift is op de {Etage.Elevator.CurrentFloor}e");
        }

    }
}