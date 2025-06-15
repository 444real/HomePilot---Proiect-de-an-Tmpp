using SmartHomeConsoleApp.Devices;

namespace SmartHomeConsoleApp.Command
{
    public class TurnOnCommand : ICommand
    {
        private SmartDevice _device;

        public TurnOnCommand(SmartDevice device)
        {
            _device = device;
        }

        public void Execute()
        {
            _device.TurnOn();
        }
    }

    public class TurnOffCommand : ICommand
    {
        private SmartDevice _device;
        public TurnOffCommand(SmartDevice device)
        {
            _device = device;
        }
        public void Execute()
        {
            _device.TurnOff();
        }
    }
}
