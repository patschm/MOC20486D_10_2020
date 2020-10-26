using System;
using System.Collections.Generic;
using System.Text;

namespace ACME
{
    class Ben: Werknemer
    {
        public override void Werkt()
        {
            WerktZichRot();
        }
        public void WerktZichRot()
        {
            Console.WriteLine("Ben werkt zich een slag in de rondte");
        }
    }
}
