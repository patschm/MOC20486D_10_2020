using System;
using System.Diagnostics;
using System.Text;
using Misc2;

namespace Misc
{
    class Program
    {
        static void Main(string[] args)
        {
            // Flatgebouw();
            //Punten();
            //Geinig();

            Point p = new Point { X = 10, Y = 20 };

            //Console.WriteLine(p);
            //DoeIets(p);
            //Console.WriteLine(p);

            DeHeap();

        }

        private static void DeHeap()
        {
            Stopwatch sw = new Stopwatch();
            //string s = "";
            StringBuilder s = new StringBuilder();
            sw.Start();
            for(int i = 0; i < 90000; i++)
            {
                s.Append(i.ToString());
                //s += i.ToString();
            }
            string s2 = s.ToString();
            sw.Stop();

            Console.WriteLine(sw.Elapsed);

        }

        private static void DoeIets(Point pp)
        {
            pp.X = 100;
            pp.Y = 200;
        }

        private static void Geinig()
        {
            string name = "Patrick";
            string res = name.SponsoredByAcme("Joho");

            Console.WriteLine(42.SponsoredByAcme("V&D"));
        }

        private static void Punten()
        {
            Point p1 = new Point { X = 10, Y = 20 };
            Point p2 = new Point { X = 100, Y = 200 };

            Point p3 = p1 + p2;

            Console.WriteLine(p3.SponsoredByAcme("Hutchington Bay"));
        }

        private static void Flatgebouw()
        {
            Etage[] flat = new Etage[30];

            for (int i = 0; i < flat.Length; i++)
            {
                flat[i] = new Etage { EtageNummer = i };
            }


            flat[27].CallElevator();

            foreach (var et in flat)
            {
                et.ShowStatus();
            }
        }
    }
}
