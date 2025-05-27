# 🚀 Space Tether Game (3D Environment, 2D Gameplay)

A physics-based game developed in Unity. Control a rocket to pick up boulders using a chain of capsules (tether), and deliver them to the drop zone while avoiding obstacles and managing fuel.

## 🎯 Objective

Use physics to fly a rocket, attach boulders with a tether, and deliver them to a drop zone. Avoid obstacles and conserve fuel to win.

## 🎮 Gameplay Summary

- Rocket starts on the left with limited power
- Pick up boulders using the tether chain
- Fly to the drop zone on the other side
- Avoid rotating and oscillating obstacles
- Game resets on fuel depletion or collision

## ✨ Features

- Tether built with capsules and `HingeJoint`s
- Boulders of varying mass: light (1), medium (5), heavy (8)
- Power UI display with fuel depletion logic
- Gravity: `-2.0` Y-axis for space-like descent
- Rocket movement with `Rigidbody.AddForce`

## ⌨️ Controls

- `←` / `→` / `↑` — Move rocket using constant thrust

## 🛠️ Tools Used

- Unity (Version 2022 or later)
- C# Scripting
- Unity Physics (Rigidbodies, Joints)

## 📂 How to Use

1. Open the project in Unity.
2. Assign boulders and drop zone.
3. Play the game and try to deliver all boulders without running out of power.

---
