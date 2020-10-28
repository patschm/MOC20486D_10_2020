using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Taken
{
    class Program
    {
        static void Main(string[] args)
        {
            //Synchroon();
            //AsyncOldSchool(); // APM
            //AsyncMiddeleeuwen(); // Framework 4.0
            //AsyncDerModerneMensch();  // Framework 4.5.1

            //CancellationTokenSource nikko = new CancellationTokenSource();
            //AnderGeinigSpul(nikko.Token);
            //Task.Delay(5000).Wait();
            //nikko.Cancel();

            //EchteMultiThreading();
            DeomTaskReturns();

            Console.WriteLine("Done!");
            Console.ReadLine();
        }

        private static Task<int> DeomTaskReturns()
        {
            Task.Delay(10);
            return Task.FromResult(42);
        }

        private static async void EchteMultiThreading()
        {
            int a = 0;
            int b = 0;

            //AutoResetEvent zl1 = new AutoResetEvent(false);
            //AutoResetEvent zl2 = new AutoResetEvent(false);
            //ManualResetEventSlim
            var t1 = Task.Run(() => {
                Task.Delay(2000).Wait();
                return 42;
            });
            var t2 = Task.Run(() => {
                Task.Delay(3000).Wait();
                return 52;
            });
            await Task.WhenAll( t1, t2);
            int res = t1.Result + t2.Result;
            Console.WriteLine(res);

            //zl1.Reset();
            //zl2.Reset();
            //a = 0;
            //b = 0;
            //t1 = Task.Run(() => {
            //    Task.Delay(2000).Wait();
            //    a = 42;
            //    zl1.Set();
            //});
            //t2 = Task.Run(() => {
            //    Task.Delay(3000).Wait();
            //    b = 52;
            //    zl2.Set();
            //});

            //WaitHandle.WaitAll(new WaitHandle[] { zl1, zl2 });
            //res = a + b;
            //Console.WriteLine(res);
        }

        private static void AnderGeinigSpul(CancellationToken bommetje)
        {
            Task.Run(()=> {
                Console.WriteLine("Taak start");
                for (; ; )
                {
                    if (bommetje.IsCancellationRequested)
                    {
                        Console.WriteLine("Bye");
                        return;
                    }
                    Console.WriteLine("job");
                    Task.Delay(200).Wait();
                }
            });
        }

        static async void AsyncDerModerneMensch()
        {
            //var t1 = Task.Run(() =>
            //{
            //    var result = Add(10, 20);
            //    return result;
            //});

            //var t1 = AddAsync(10, 30);

            try
            {
                decimal res = await AddAsync(10, 30);  // Zachte return

                Console.WriteLine("En verder...");
                Console.WriteLine($"Antwoord is: {res}");
                res = await AddAsync(10, 30);  // Zachte return

                Console.WriteLine("En verder...");
                Console.WriteLine($"Antwoord is: {res}");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void AsyncMiddeleeuwen()
        {
            // Task Library TPL
            //Task<decimal> t1 = new Task<decimal>(() => {
            //    var result = Add(10, 20);
            //    return result;
            //});

            //t1.ContinueWith(pt => {
            //    Console.WriteLine($"Antwoord is: {pt.Result}");
            //}).ContinueWith(pt => {
            //    Console.WriteLine($"Klaar!!!");
            //});

            //t1.Start();

            Task.Run(() =>
            {
                var result = Add(10, 20);
                return result;
            }).ContinueWith(pt => {
                //if (pt.Exception != null)
                //{
                //    Console.WriteLine(pt.Exception.InnerException.Message);
                //}
                Console.WriteLine($"Antwoord is: {pt.Result}");
            });

            
        }

        private static void AsyncOldSchool()
        {
            Func<decimal, decimal, decimal> add = Add;

            //add.BeginInvoke(10, 20, MyCallback, add);

           add.BeginInvoke(10, 20, ar2 =>
            {
                var result = add.EndInvoke(ar2);
                Console.WriteLine($"Antwoord is: {result}");
            }, null);

            //while(!ar.IsCompleted)
            //{
            //    Console.Write(".");
            //    Task.Delay(500).Wait();
            //}    
        }

        private static void MyCallback(IAsyncResult ar)
        {
            Func<decimal, decimal, decimal> add = ar.AsyncState as Func<decimal, decimal, decimal>;
            var result = add.EndInvoke(ar);
            Console.WriteLine($"Antwoord is: {result}");
        }

        private static void Synchroon()
        {
            var result = Add(10, 20);
            Console.WriteLine($"Antwoord is: {result}");
        }

        static decimal Add(decimal a, decimal b)
        {
            Task.Delay(5000).Wait();
            //throw new Exception("Ooops");
            return a + b;
        }

        static Task<decimal> AddAsync(decimal a, decimal b)
        {
            return Task.Run(() =>Add(a, b));
        }
    }
}
