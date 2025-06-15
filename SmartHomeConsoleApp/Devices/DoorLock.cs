namespace SmartHomeConsoleApp.Devices
{
    public class DoorLock : SmartDevice
    {
        public bool IsLocked { get; private set; }

        public DoorLock(string name) : base(name) { }

        public void Lock()
        {
            if (IsLocked)
            {
                NotifyObservers($"{Name}: The door is already locked!");
            }
            else
            {
                IsLocked = true;
                NotifyObservers($"{Name} is now LOCKED.");
            }
        }

        public void Unlock()
        {
            if (!IsLocked)
            {
                NotifyObservers($"{Name}: The door is already unlocked!");
            }
            else
            {
                IsLocked = false;
                NotifyObservers($"{Name} is now UNLOCKED.");
            }
        }
    }
}