# Mini Projet Modélisation Géométrique - Unity Simulation

## Overview
This project is a Unity-based simulation that immerses the user in a tactical scenario where they must protect a strategic location against a group of rioters. The simulation is designed to teach tactical decision-making, emotional management, and ethical considerations in crowd control scenarios.

## Features
- **Tactical Simulation**: Manage distances, crowd density, and strategic positioning.
- **Grenade System**: Implement realistic grenade throwing physics, including trajectory and environmental interactions.
- **Real-Time Mesh Deformation**: Objects such as cars and urban furniture deform upon interaction with grenades.
- **Particle System for Smoke Grenades**: Realistic and optimized smoke effects.
- **AI Behavior**: Simulated rioters navigate the environment and respond dynamically to smoke grenades.
- **Animations**: Vehicles and pedestrians move naturally through the scene.
- **Shaders**: Visual traces of explosions with custom shaders.
- **Scenario Outcomes**:
  - **Success**: Rioters are blocked from progressing.
  - **Failure**: Explosives hit the user or the protected area is abandoned.
- **Bonus**:
  - Main Menu for launching the game.
  - Sound effects for vehicles, explosions, and city ambiance.

## Requirements
- **Unity Version**: Unity 2022 or above is required to run this project.

## How to Run the Simulation
1. Clone this repository to your local machine:
   ```bash
   git clone https://github.com/JitBay/mini_projet_modeli.git
2. Open the project in Unity 2022 or newer.
3. Set the **Menu Scene** as the starting scene in Unity's build settings:
   - Go to `File > Build Settings`.
   - Add all scenes to the build.
   - Ensure the **Menu Scene** is at the top of the list.
4. Press **Play** in the Unity Editor or build and run the project.

## Objectives
### Gameplay:
- Navigate the avatar (CRS) in a simulated urban environment.
- Prevent rioters from accessing a protected zone.
- Use grenades to control the crowd while minimizing collateral damage.

## Development Objectives
### OBJ 1: Avatar Control
- Import a third-person controller for the user.
- Add a baton to the left hand and a grenade to the right hand.
- Modify the avatar's mesh to resemble a CRS officer.

### OBJ 2: Grenade Mechanics
- Design a physics-based grenade system, including:
  - Realistic trajectories considering air resistance, rotation, and bounce.
  - Automatic grenade respawn in the avatar's hand after throwing.

### OBJ 3: Real-Time Mesh Deformation
- Allow vehicles and urban furniture to deform when interacting with grenades or explosions.

### OBJ 4: Smoke Grenades
- Create a smoke particle system that does not significantly impact FPS.
- Implement optimization by stopping older particle systems before creating new ones.

### OBJ 5: Environment Animations
- Enable vehicles to move realistically without colliding with pedestrians.
- Animate pedestrians walking on sidewalks.

### OBJ 6: AI Navigation
- Simulate rioters navigating streets and sidewalks, responding dynamically to smoke grenades.
- Implement rioters launching small explosives at regular intervals.

### OBJ 7: Visual Effects
- Add explosion traces to the environment using custom shaders.

### OBJ 8: Scenario Outcomes
- **Mission Success**:
  - Block rioters from progressing for a specified time.
- **Mission Failure**:
  - An explosive hits the avatar or the user leaves the protected area.

### OBJ 9: Bonus Features
- Main menu to start the game, view objectives, and quit.
- Sound effects for vehicles, explosions, and city ambiance.

## Key Assets Used
- **Urban Environment**: [Demo City by Versatile Studio](https://assetstore.unity.com/packages/3d/environments/urban/demo-city-by-versatile-studio-mobile-friendly-269772)
- **Third-Person Controller**: [Third-Person Controller (Basic Locomotion)](https://assetstore.unity.com/packages/tools/game-toolkits/third-person-controller-basic-locomotion-free-82048)

## Acknowledgments
This project was developed as part of the **Modélisation Géométrique** course under **Guillaume Loup**. Special thanks to the course instructors and collaborators for their guidance and support.
