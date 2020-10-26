using System;
using System.Collections.Generic;
using System.Text;

namespace ACME
{
    abstract class Werknemer : Persoon, IContract
    {
        public void Werken()
        {
            Werkt();
        }

        public abstract void Werkt();
    }
}
