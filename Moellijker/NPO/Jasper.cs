using System;
using System.Collections.Generic;
using System.Text;

namespace NPO
{
    class Jasper
    {
        public string telNr = "1234565789";

        public void ViaRooksignalen(string msg)
        {
            Console.WriteLine($"Ontvangen via rooksignale op nummer {telNr}: {msg}");
        }
    }
}
