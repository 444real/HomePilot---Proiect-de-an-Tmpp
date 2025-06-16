HomePilot – SmartHome Console Application

Această aplicație simulează controlul centralizat al unei case inteligente direct din consolă. Utilizatorul poate aprinde/stinge luminile, seta temperatura, bloca/debloca ușa și activa modul Vacanță. Proiectul demonstrează utilizarea a 6 șabloane de design software:
Factory Pattern – Crearea dispozitivelor smart (Creațional)

Devices/DeviceFactory.cs

Separă logica de creare a obiectelor Light, Thermostat, Camera, DoorLock de restul aplicației. Permite adăugarea ușoară de noi tipuri de dispozitive fără a modifica logica principală din Program.cs.
Singleton Pattern – Controlul central SmartHome (Creațional)

Singleton/SmartHomeController.cs

Asigură existența unei singure instanțe globale de SmartHomeController care gestionează lista de dispozitive smart din casă. Astfel, orice acțiune sau comandă se propagă centralizat.
Decorator Pattern – Funcționalități suplimentare pentru dispozitive (Structural)

Devices/DeviceDecorator.cs, Devices/CameraWithNightVision.cs

Permite adăugarea dinamică de funcționalități suplimentare la dispozitive, cum ar fi night vision la camere, fără a modifica clasa de bază. Fiecare extensie este o "decorare" a dispozitivului inițial.
Observer Pattern – Notificări la schimbarea stării dispozitivelor (Comportamental)

Observer/DeviceObserver.cs și în SmartDevice

Permite atașarea de observatori (ex: DeviceObserver) care sunt notificați automat când starea unui dispozitiv se schimbă (ex: lumina este aprinsă, ușa este blocată). Este util pentru logare, alerte sau extindere viitoare a comportamentului.
Command Pattern – Executarea acțiunilor asupra dispozitivelor (Comportamental)

Command/ICommand.cs, CommandInvoker.cs, comenzi concrete

Permite executarea comenzilor precum TurnOn, TurnOff, LockDoor, UnlockDoor asupra dispozitivelor, cu o structură ce poate fi extinsă ușor (ex: Undo/Redo sau comenzi programate).
Facade Pattern – Activarea scenariilor complexe cu o singură comandă (Structural)

Facade/VacationModeFacade.cs

Oferă o interfață simplificată pentru scenarii complexe, precum activarea modului Vacanță: toate luminile se sting, termostatul scade temperatura, ușa se blochează. Ascunde complexitatea apelurilor multiple din spate.
Utilizare rapidă

    Rulează aplicația.

    Selectează acțiunile din meniu: poți controla fiecare dispozitiv sau poți activa un scenariu global.

    Primești notificări la fiecare acțiune efectuată.

    Poți extinde proiectul adăugând noi dispozitive, noi scenarii, sau observatori.

Structură directoare

SmartHomeConsoleApp/
│   Program.cs
├── Devices/
├── Command/
├── Observer/
├── Singleton/
├── Facade/

Proiect realizat pentru a demonstra design pattern-uri moderne într-un context de smart home.
