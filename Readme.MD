COMP30019 Graphics and Interaction Project 2 Proposal
Jordan Lo Presti - 640011 - jlo1
Christopher Tass-Parker - 541236 - tass


The Game
	The genre of the game we aim to create will be a top-down shooter. The aim of the game is to survive for as long as possible as you are swarmed by hordes of enemies. The longer you survive, the bigger the horde and the bigger your score!

Hardware Inputs
	For playing the game these are the key inputs that will control the player.

Left Joystick (Touch)
	Controls the movement of the player, displayed as part of the UI

Right Joystick (Touch)
	Controls the rotation of the player (i.e the direction the player is facing) and also the firing of the weapon in this direction.

Accelerometer
	The accelerometer will be used to detect if the device is shaking, this input will detonate a bomb that will instantly kill many enemies if the horde is getting too strong, this feature will be available a limited number of times so choose wisely.


Visualisation:
3-D Graphics 
	The 3D environment will be powered by the Unity game engine. All models will be 3 dimensional.  

The Camera
	The camera will be placed above the player and will follow the player such that it is always within a predetermined radius of the center of the screen. 

Lighting
	The scene will be lit using a light source above the playing surface and rendered using a Phong Shader with Ka, Kd and Ks values adjusted for our textures.

Visual Effects
	Animation of enemies and the player for when they are moving/rotating and attacking and also Particle Systems will be used for different weapons (e.g. explosions and flames)

Polygons
	A plane will be used for  our main surface and modified with a procedurally generated terrain similar to the first project. This will allow the variation of the number of the bulk of the polygons in the scene so that performance can be optimized. As an estimate the bulk of our polygons will be have approximately ~30-35k vertices.


Milestones: 
Core functionality: 
	Environment: Terrain/Player Models/Environment models

	Player movement control 

	Player shoot control

	Player and enemy health

	Accelerometer input

	Camera orientation and movement to follow player

	NPC Control Algorithm

	Scoring System

Extra Functionality: 
	Power ups that can be picked up for different/stronger weapons

	Never-ending terrain

	Spawn less/more enemies based on the score/time alive.

