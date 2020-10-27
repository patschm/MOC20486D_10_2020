using ISO.Interfaces;
using System;
using System.Collections.Generic;

namespace Infrac
{
    public class DetectieLus
    {
        private List<IDetectable> devices = new List<IDetectable>();

        public void Connect(IDetectable device)
        {
            devices.Add(device);
        }

        public void Trigger()
        {
            Console.WriteLine("Hmmmm. We zien iets...");
            // TODO: Activeer hier alles wat aan de detectielus hangt.
            foreach(IDetectable device in devices)
            {
                device.Activate();
            }
        }
    }
}
