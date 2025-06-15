namespace SmartHomeConsoleApp.Devices
{
    public class Camera : SmartDevice
    {
        public Camera(string name) : base(name) { }
        public virtual void EnableNightVision() { }
    }
}
