using System;

namespace SmartHomeConsoleApp.Observer
{
    public class DeviceObserver : IObserver
    {
        public void Update(string message)
        {
            Console.WriteLine($"[NOTIFICARE]: {message}");
        }
    }
}
