namespace SmartHomeConsoleApp.Devices
{
    public class DeviceFactory
    {
        public SmartDevice CreateDevice(string type, string name)
        {
            switch (type.ToLower())
            {
                case "light": return new Light(name);
                case "thermostat": return new Thermostat(name);
                case "camera": return new Camera(name);
                case "doorlock": return new DoorLock(name);
                default: return null;
            }
        }
    }
}
