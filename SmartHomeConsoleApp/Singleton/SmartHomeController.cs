using SmartHomeConsoleApp.Devices;
using System.Collections.Generic;

namespace SmartHomeConsoleApp.Singleton
{
    public class SmartHomeController
    {
        private static readonly SmartHomeController _instance = new SmartHomeController();

        private List<SmartDevice> _devices = new List<SmartDevice>();
        public static SmartHomeController Instance => _instance;

        private SmartHomeController() { }

        public void AddDevice(SmartDevice device)
        {
            _devices.Add(device);
        }

        public List<SmartDevice> GetDevices() => _devices;
    }
}
