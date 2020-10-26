using System;
using System.Collections;
using System.Collections.Generic;

namespace Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            if (i == 9)
            {

            }
            else
            {

            }

            switch (i)
            {
                case -1:
                case 0:
                    Console.WriteLine("nul");
                    break;
                case 1:
                    Console.WriteLine("een");
                    break;
                default:
                    Console.WriteLine("anders");
                    break;
            }



            for (i = 0; i < 10; i++)
            {
                break; // Verlaat hele loop
                continue; // Stopt huidige iteratie
                Console.WriteLine(i);
            }

            // 0 of meer keer uitgevoerd
            while (i < 10)
            {

            }
            // In ieder geval een keer uitgevoerd
            do
            {

            }
            while (i < 10);

            // arrays 1) Aaneengesloten geheugen. 2) Immutable
            // Type[] varname;
            int[] nrs = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[,] matrix = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };
            int[][] jagged = new int[3][];

            jagged[0] = new int[5];
            jagged[1] = new int[20];

            // Ouwe meuk (NIET GEBRUIKEN!!!) Niet type safe
            //ArrayList list = new ArrayList();
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            LinkedList<string> llist = new LinkedList<string>();
            Stack<int> stack = new Stack<int>();
            //stack.Push()
            Queue<bool> queue = new Queue<bool>();
            queue.Enqueue(true);
            bool res = queue.Dequeue();

            //Hashtable
            Dictionary<string, int> lookup = new Dictionary<string, int>();

            lookup.Add("een", 1);
            lookup.Add("twee", 2);
            lookup.TryAdd("drie", 3);

            foreach (var tmp in llist)
            {
                Console.WriteLine(tmp);
            }




            // Type varnaam;
            int age = 10;
            string name = "Patrick";

            int? data = null;

            int result = data ?? 42;

            {
                bool isMale = true;
            }

            // een of meer operands en een operator
            int nr = age + 3;
            Console.WriteLine(++age);

            int x = 1;
            int y = 2;

            Console.WriteLine(x ^ y);

            bool ba = age < 10 && DoeIets();


        }

        private static bool DoeIets()
        {
            Console.WriteLine("Ok");
            return true;
        }
    }
}
