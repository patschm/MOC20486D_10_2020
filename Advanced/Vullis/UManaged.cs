using System;
using System.Collections.Generic;
using System.Text;

namespace Vullis
{
    class UManaged : IDisposable
    {
        private static bool isOpen = false;

        public void Open()
        {
            if (isOpen)
            {
                Console.WriteLine("Helaas");
                return;
            }
            Console.WriteLine("Openen...");
            isOpen = true;
        }
        public void Close()
        {
            Console.WriteLine("Closing...");
            isOpen = false;
        }

        public void Dispose()
        {
            Close();
            GC.SuppressFinalize(this);
        }

        ~UManaged()
        {
            Close();
        }
    }
}
