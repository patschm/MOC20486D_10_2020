using System;

namespace ACME
{
    class Program
    {
        static void Main(string[] args)
        {
            Jasper j = new Jasper();
            Alfred al = new Alfred();
            LoonyTunes lt = new LoonyTunes();
            Ben b = new Ben();
            RoadRunner rn = new RoadRunner();

            lt.Hire(rn);
            lt.Hire(j);
            lt.Hire(al);
            lt.Hire(b);

            lt.Produceer();
        }
    }
}
