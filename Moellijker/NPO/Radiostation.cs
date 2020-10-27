using System;
using System.Collections.Generic;
using System.Text;

namespace NPO
{
    delegate void OntvangstMethode(string message);

    class Radiostation
    {
        public event OntvangstMethode Subscribers;
        
        public void Broadcast()
        {
            Console.WriteLine("We gaan beginnen...");
            Subscribers("Hallo allemaal");
        }
    }
}
