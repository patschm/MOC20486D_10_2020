using System;
using System.Collections.Generic;
using System.Text;

namespace ACME
{
    class Alfred : Werknemer
    {
        public override void Werkt()
        {
            KanIets();
        }
        public void KanIets()
        {
            Console.WriteLine("Alfred doet iets vreemds");
        }
    }
}
