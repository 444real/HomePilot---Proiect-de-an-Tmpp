using System;
using SmartHomeConsoleApp.Devices;
using SmartHomeConsoleApp.Observer;
using SmartHomeConsoleApp.Singleton;
using SmartHomeConsoleApp.Command;
using SmartHomeConsoleApp.Facade;

namespace SmartHomeConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var controller = SmartHomeController.Instance;
            var factory = new DeviceFactory();

            // Creăm dispozitivele
            var light = factory.CreateDevice("light", "Living Room Light");
            var thermostat = factory.CreateDevice("thermostat", "Hall Thermostat");
            var doorLock = factory.CreateDevice("doorlock", "Front Door Lock");

            controller.AddDevice(light);
            controller.AddDevice(thermostat);
            controller.AddDevice(doorLock);

            // Adaugăm observer pentru notificări
            var observer = new DeviceObserver();
            light.AddObserver(observer);
            thermostat.AddObserver(observer);
            doorLock.AddObserver(observer);

            var invoker = new CommandInvoker();

            Console.WriteLine("==== SmartHome Control Center ====");
            Console.WriteLine("1. Aprinde lumina");
            Console.WriteLine("2. Stinge lumina");
            Console.WriteLine("3. Setează temperatura");
            Console.WriteLine("4. Blochează usa");
            Console.WriteLine("5. Deblochează usa");
            Console.WriteLine("6. Activează modul Vacanta");
            Console.WriteLine("7. Afiseaza status dispozitive");
            Console.WriteLine("0. Iesire");

            bool running = true;
            while (running)
            {
                Console.Write("\nAlege o optiune: ");
                var opt = Console.ReadLine();

                switch (opt)
                {
                    case "1":
                        invoker.SetCommand(new TurnOnCommand(light));
                        invoker.ExecuteCommand();
                        break;
                    case "2":
                        invoker.SetCommand(new TurnOffCommand(light));
                        invoker.ExecuteCommand();
                        break;
                    case "3":
                        Console.Write("Seteaza temperatura (°C): ");
                        if (int.TryParse(Console.ReadLine(), out int temp))
                        {
                            ((Thermostat)thermostat).SetTemperature(temp);
                        }
                        else
                        {
                            Console.WriteLine("Temperatura invalida!");
                        }
                        break;
                    case "4":
                        invoker.SetCommand(new LockDoorCommand((DoorLock)doorLock));
                        invoker.ExecuteCommand();
                        break;
                    case "5":
                        invoker.SetCommand(new UnlockDoorCommand((DoorLock)doorLock));
                        invoker.ExecuteCommand();
                        break;
                    case "6":
                        var vacationFacade = new VacationModeFacade(controller);
                        vacationFacade.ActivateVacationMode();
                        break;
                    case "7":
                        ShowStatus(light, thermostat, doorLock);
                        break;
                    case "0":
                        running = false;
                        Console.WriteLine("La revedere!");
                        break;
                    default:
                        Console.WriteLine("Optiune invalida!");
                        break;
                }
            }
        }

        static void ShowStatus(SmartDevice light, SmartDevice thermostat, SmartDevice doorLock)
        {
            var lightObj = (Light)light;
            var thermostatObj = (Thermostat)thermostat;
            var doorLockObj = (DoorLock)doorLock;

            Console.WriteLine("\n--- Status dispozitive ---");
            Console.WriteLine($"Light: {lightObj.Name} - {(lightObj.IsOn ? "ON" : "OFF")}");
            Console.WriteLine($"Termostat: {thermostatObj.Name} - {thermostatObj.Temperature}°C");
            Console.WriteLine($"Door: {doorLockObj.Name} - {(doorLockObj.IsLocked ? "Locked" : "Unlocked")}");
        }
    }
}
