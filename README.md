# Laser-Defender-unity-2d-
### Game Overview
![alt text](image.png)
![alt text](image-1.png)
![alt text](image-2.png)
### Game design
**Theme**: Space Shooter.
**Core Mechanic**: Shoot enemies - Dodge bullets.
**Game loop**: Single level with endless enemy waves. Shoot enemies for points until health reaches zero and game ends.
### Game controls
Press A W S D keys to move the player and press Space key to fire.
### Features
- Using prefabs for enemies, player, projectile
- Instantiating enemies endlessly 
- Particle effects(taking damage from player and enemies)
- Audio
- UI Canvas for Menu and Gameover scene
- Singleton pattern(Audio and Scorekeeper)
- Using ScriptableObject to contain enemy prefab and path (enemies's path) prefab
- Using objectpoll pattern to initiate player's projectiles and enemy's projectiles