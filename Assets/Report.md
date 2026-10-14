This was added at 12:23 AM so feel free to discard it or deduct points

# Zombie Survival Game — Systems Report

## 1. System Division

I divided the game into five systems, here they are:

- **ZombieSpawner:** Spawns zombies at random positions a bit further away from the center, controls spawning frequency, assigns difficulty and detects waves.
- **ZombieLife:** Controls each zombie's movement, dictates lives, sprite changes, and eventual doom.
- **DifficultyController:** Increases zombie speed and maximum lives, reduces spawn intervals after a while.
- **InputHandler:** Detects mouse clicks with Unity's Input System(almost said particle system) and deletes the zombie that was clicked from existence.
- **UiController:** Only Handles the Game Over screen for now.

The `Difficulty` class stores the difficulty level, speed, lives and spawn frequency.

## 2. Observer Pattern

I used events in:

- **`onCapture`:** A zombie raises this event when it reaches the center(We can't let the zombies in the lawn). The spawner subscribes to it and triggers the Game Over sequence.
- **`raiseDifficulty`:** The spawner raises this event when each wave is completed. The difficulty controller subscribes and updates its values.
