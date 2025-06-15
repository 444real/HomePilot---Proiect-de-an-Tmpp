namespace SmartHomeConsoleApp.Devices
{
    public class Thermostat : SmartDevice
    {
        public int Temperature { get; private set; } = 20;

        public Thermostat(string name) : base(name) { }

        public void SetTemperature(int temperature)
        {
            Temperature = temperature;
            NotifyObservers($"{Name}: Temperature set to {temperature}°C.");
        }
    }
}
