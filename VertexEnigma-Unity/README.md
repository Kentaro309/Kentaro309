# Vertex Enigma – IEEE Game SIG 2024 Submission

Vertex Enigma is a multiplayer escape room game developed in Unity over 4 months and submitted to the IEEE Game SIG 2024 competition, where it placed 3rd. This repository showcases the programming work and systems design I contributed as the sole programmer on our three-person team.

---

## Overview

Vertex Enigma is a multiplayer escape room game where players collaborate to solve puzzles and escape a series of unique, themed rooms. The goal in each level is to interact with objects around the environment to find clues and discover a four-symbol keycode required to unlock the exit. Players communicate verbally (without seeing each other's screens) to share findings and coordinate solutions. Each new level introduces a unique mechanic, adding a new challenge and requiring creative teamwork. As players progress, the central hub room reveals new story elements that further the narrative.

---

## Promotional Trailer

This video was produced for our IEEE Game SIG 2024 submission to showcase the game's direction, design goals, and implemented features. It was used in competition to present our team's progress under a tight development timeline.

[![Watch the trailer](https://img.youtube.com/vi/3-exacWd3Xw/0.jpg)](https://www.youtube.com/watch?v=3-exacWd3Xw)

---

## Role and Contributions

As the sole programmer on the team, I was responsible for the complete technical implementation of gameplay systems in Unity using C#. My key contributions included:

- **Modular Interaction System**  
  - Designed and implemented a modular, event-driven system for player-object interactions (pick-up, inspect, sort) using C# in Unity.
  - Ensured scalable and maintainable design to support future feature additions.

- **Dynamic Room-State Tracking**  
  - Built a system to track player progress using static variables.
  - Dynamically updated the main room on load to reveal new story elements as players advanced.

- **Integration with Inherited Code**  
  - Analyzed existing player controller and teammate-written scripts.
  - Integrated my new systems carefully to avoid breaking existing functionality.
  - Refactored and reorganized code to maintain compatibility and stability.

- **Bug Fixing and Collision Handling**  
  - Identified and resolved inherited collision bugs by implementing layer-based filtering.
  - Ensured smooth and reliable interaction behaviors without physics conflicts.

- **Cinematics and Rendering**  
  - Designed custom camera paths and handled in-engine rendering for trailer-ready cinematic sequences showcased in the competition submission.

- **Version Control and Collaboration**  
  - Managed Git-based workflows to maintain version history.
  - Coordinated development with non-technical team members to ensure seamless integration of art and design assets.

---

## Repository Structure
/Scripts – All core Unity C# scripts implementing gameplay systems  
README.md – Project overview, design decisions, and documentation


---

## Screenshots

<img src="https://github.com/user-attachments/assets/e9ed3a10-7293-457a-9eae-053c4d5fa946" alt="Vertex Enigma Main Menu" width="500"/> <img src="https://github.com/user-attachments/assets/a7591c41-51cd-4f26-96fc-97711163c797" alt="Vertex Enigma Level 1" width="500"/>
<img src="https://github.com/user-attachments/assets/c9ee46ca-7157-46bb-96f3-2094a8517633" alt="IEEE" width="500"/> <img src="https://github.com/user-attachments/assets/4a2fc4a2-cb36-496b-ab3c-36be37544db1" alt="IEEE" width="500"/>




---
<!--
## Credits and External Code

This project includes some scripts and components that were either originally written by teammates or adapted from online tutorials. These were essential to maintain the functionality and integration of the project:

- **PlayerController.cs**: Initially sourced from an online tutorial (original source unknown), with my modifications to support custom interactions and collision filtering.
- **[OtherScript].cs**: Written by a teammate; retained and adapted to ensure compatibility with new features I implemented.


--- -->

## Notes

This repository is not a full Unity project export. It is a curated version that emphasizes my programming contributions.
