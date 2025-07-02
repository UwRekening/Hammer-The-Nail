<img width="1280" alt="logo" src="https://github.com/UwRekening/SpaceBalls/assets/66946691/5487d137-03ba-47b8-b565-91cd4e70f890">

# Hammer The Nail 🔨

[![School Project](https://img.shields.io/badge/Project-School-blue.svg)]()  
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://choosealicense.com/licenses/mit/)

## Over dit project

**Hammer The Nail** is een game gemaakt als opdracht voor het keuzedeel *Game Development met Reusable Components*.  
Het doel van dit project was om te werken met modulaire en herbruikbare scripts in Unity.  
De game ondersteunt meerdere vormen van input en is ontworpen volgens Clean Code-principes.

---

## 🎮 Besturing

Je kunt het spel op twee manieren spelen:

- 🖱️ **Muis:** Klik op spijkers om ze in te slaan.  
- 🧤 **AXIS Pro Motion Capture Suite:** Beweeg je hand richting de spijkers om ze fysiek te raken.

Selecteer je gewenste inputmethode via de UI voor de game start.

---

## 🎯 Doel van het spel

Sla zoveel mogelijk spijkers binnen de tijd.  
Elke spijker heeft een ander effect:

- 🟢 **Normal Nail** – gewone score  
- ✨ **Extra Score Nail** – bonuspunten  
- 🔻 **Min Score Nail** – verlaagt je score  
- 🔺 **Move Up Nail** – spijker schiet omhoog  
- ⏱️ **Remove Time Nail** – verkort je speeltijd  
- 💣 **Explosion Nail** – shake en extra impact  
- ❌ **Delete Nail** – verwijdert zichzelf

---

## ⚙️ Features

- ✅ Herbruikbare componenten (`IInteractable`, `IPlayerBehaviour`)  
- 🔊 Dynamisch audiosysteem met `SoundType` enums  
- 💥 Speciale effecten: camera shake, time slowdown, particles  
- 🎛️ Input-switching via UI (muis of motion suite)  
- 🧠 Slimme spawner voor willekeurige nails  
- 🕹️ Duidelijke scheiding tussen GameFlow, Countdown & Logic  
- 📈 Realtime score- en timerweergave  

---

## 🛠️ Gebouwd met

- Unity 2022+
- C#
- AXIS Motion Capture SDK *(optioneel)*

---

## 📄 Licentie

Dit project is gelicenseerd onder de [MIT-licentie](https://choosealicense.com/licenses/mit/).
