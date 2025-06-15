using SmartHomeConsoleApp.Devices;

namespace SmartHomeConsoleApp.Command
{
    public class LockDoorCommand : ICommand
    {
        private DoorLock _doorLock;

        public LockDoorCommand(DoorLock doorLock)
        {
            _doorLock = doorLock;
        }

        public void Execute()
        {
            _doorLock.Lock();
        }
    }

    public class UnlockDoorCommand : ICommand
    {
        private DoorLock _doorLock;
        public UnlockDoorCommand(DoorLock doorLock)
        {
            _doorLock = doorLock;
        }
        public void Execute()
        {
            _doorLock.Unlock();
        }
    }
}
