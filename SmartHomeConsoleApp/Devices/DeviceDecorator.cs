namespace SmartHomeConsoleApp.Devices
{
    public abstract class DeviceDecorator : SmartDevice
    {
        protected SmartDevice _device;

        public DeviceDecorator(SmartDevice device) : base(device.Name)
        {
            _device = device;
        }

        public override void TurnOn()
        {
            _device.TurnOn();
        }

        public override void TurnOff()
        {
            _device.TurnOff();
        }
    }

    public class CameraWithNightVision : DeviceDecorator
    {
        public CameraWithNightVision(Camera camera) : base(camera) { }

        public void EnableNightVision()
        {
            NotifyObservers($"{Name}: Night vision ENABLED.");
        }
    }
}
