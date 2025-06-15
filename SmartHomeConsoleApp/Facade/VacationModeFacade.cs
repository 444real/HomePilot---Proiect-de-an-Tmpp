using SmartHomeConsoleApp.Singleton;
using SmartHomeConsoleApp.Devices;
using SmartHomeConsoleApp.Command;

namespace SmartHomeConsoleApp.Facade
{
    public class VacationModeFacade
    {
        private SmartHomeController _controller;

        public VacationModeFacade(SmartHomeController controller)
        {
            _controller = controller;
        }

        public void ActivateVacationMode()
        {
            foreach (var device in _controller.GetDevices())
            {
                if (device is Light)
                    device.TurnOff();
                else if (device is Thermostat)
                    ((Thermostat)device).SetTemperature(16); // Reduce heating
                else if (device is DoorLock)
                    ((DoorLock)device).Lock();
            }
            System.Console.WriteLine("SmartHome: Vacation Mode ACTIVATED.");
        }
    }
}
