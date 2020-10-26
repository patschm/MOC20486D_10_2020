using System;
using System.Collections.Generic;
using System.Text;

namespace ACME
{
    interface IContract
    {
        void Werken();
    }

    class LoonyTunes
    {
        private List<IContract> werknemers = new List<IContract>();

        public void Hire(IContract wn)
        {
            werknemers.Add(wn);
        }

        public void Produceer()
        {
            int nr = 2;
            Console.WriteLine($"Loony Tunes start {nr}");
            foreach (IContract wn in werknemers)
            {
                wn.Werken();
            }
        }
    }
}
