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


## 🎯 Speldoel
**Sla zoveel mogelijk spijkers binnen de tijd.**  
Maar let op: *elke spijker heeft een unieke combinatie van effecten* die je gameplay beïnvloeden.

---

## ⚙️ Variatiecomponenten

Alle spijker-prefabs zijn opgebouwd uit **herbruikbare componenten** die bepalen wat er gebeurt bij een interactie.  
Deze componenten worden gecombineerd tot unieke variaties.

### ✅ Beschrijving van de componenten

| Component         | Beschrijving                                                              | Gameplay Effect                            |
|------------------|---------------------------------------------------------------------------|---------------------------------------------|
| `Score`          | Verhoogt of verlaagt de score van de speler bij interactie                | 🎯 Beïnvloedt het scoreverloop              |
| `Sound`          | Speelt een geluid af bij aanraking                                        | 🔊 Feedback en sfeer                        |
| `CameraShake`    | Laat de camera kort trillen                                               | 💥 Voelt impactvol aan                      |
| `ParticleEmitter`| Activeert een particle effect (explosie, rook, vonken, enz.)              | ✨ Visuele flair of explosiegevoel          |
| `SlowTime`       | Vertraagt tijdelijk de tijd in de game                                    | 🐢 Dramatisch effect / tijdelijk voordeel   |

⚠️ Let op

    🔴 Vermijd spijkers met een HeavyCameraShake effect.
    Deze spijkers zorgen voor een zware visuele verstoring én geven géén extra punten. Ze kosten je tijd en focus zonder beloning. Richt je liever op spijkers die wél bijdragen aan je score!
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
