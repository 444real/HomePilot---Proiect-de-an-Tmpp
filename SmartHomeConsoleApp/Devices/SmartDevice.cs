using SmartHomeConsoleApp.Observer;
using System;
using System.Collections.Generic;

namespace SmartHomeConsoleApp.Devices
{
    public abstract class SmartDevice : IObservable
    {
        public string Name { get; set; }
        private List<IObserver> _observers = new List<IObserver>();

        public SmartDevice(string name)
        {
            Name = name;
        }

        public virtual void TurnOn()
        {
            NotifyObservers($"{Name} was turned ON.");
        }

        public virtual void TurnOff()
        {
            NotifyObservers($"{Name} was turned OFF.");
        }

        // Observer methods
        public void AddObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers(string message)
        {
            foreach (var obs in _observers)
                obs.Update(message);
        }
    }
}
