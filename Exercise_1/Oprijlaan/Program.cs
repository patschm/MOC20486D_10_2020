using DoomsdayPreppers;
using Heras;
using Infrac;
using Osram;
using System;

namespace Oprijlaan
{
    class Program
    {
        static void Main(string[] args)
        {
            Hek hek = new Hek();
            Lamp lamp = new Lamp();
            DetectieLus lus = new DetectieLus();
            Valkuil kuil = new Valkuil();
            
            lus.Activated += hek.Open;
            lus.Activated += kuil.Open;
            lus.Activated += lamp.Aan;

            lus.Connect(hek);
            lus.Connect(kuil);
            lus.Connect(lamp);

            lus.Trigger();
        }
    }
}
