namespace SmartHomeConsoleApp.Devices
{
    public class Light : SmartDevice
    {
        public bool IsOn { get; private set; } = false;

        public Light(string name) : base(name) { }

        public override void TurnOn()
        {
            if (IsOn)
            {
                NotifyObservers($"{Name}: The light is already ON!");
            }
            else
            {
                IsOn = true;
                NotifyObservers($"{Name} was turned ON.");
            }
        }

        public override void TurnOff()
        {
            if (!IsOn)
            {
                NotifyObservers($"{Name}: The light is already OFF!");
            }
            else
            {
                IsOn = false;
                NotifyObservers($"{Name} was turned OFF.");
            }
        }
    }
}
