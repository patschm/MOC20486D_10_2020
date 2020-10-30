using System;

namespace Vullis
{
    class Program
    {
        static UManaged m1 = new UManaged();
        static UManaged m2 = new UManaged();

        static void Main(string[] args)
        {
            using (m1)
            {
                m1.Open();
            }
            //m1.Dispose();

            //GC.Collect();
            //GC.WaitForPendingFinalizers();     

            using (UManaged m3 = new UManaged())
            {
                m3.Open();
            }

            m2.Open();

            Console.ReadLine();
        }
    }
}
