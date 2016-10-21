COMP30019 Graphics and Interaction Project 2 Proposal
Jordan Lo Presti - 640011 - jlo1
Christopher Tass-Parker - 541236 - tass

**SCROLL DOWN FOR IMPLEMENTATION DETAILS**


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


**IMPLEMENTATION**

For the assignment we managed to implement all of or core features, and from our extra functionality we implemented the infinite terrain and the dynamic zombie spawning system, only missing the power ups.

1. What the application does
The app is an isometric view survival shooter game. The aim of the game is to stay alove for as long as possible and kill as many zombies as you can while you're alive. The game will get harder as the game pregresses, in the first round the zombies will spawn every 5 seconds, and with each round you progress through, the more zombies will spawn at a faster rate, with the fastest spawn rate being one second.

2. How to use it
The app offers three forms of input, two joystick controllers as part of the UI and an accelerometer input. 
	The left joystick is used to move the player object in any direction on the terrain.
	The right joystick is used to rotate the player in any direction as well as shoot in the direction that the player 		is aiming.
	The accelerometer input is used to detect a shake of the device (not extremely hard but not soft), which will 		trigger missiles to be launched from a random position above all the zombies that are within a certain radius of the  player, this is most useful for when the horde around you is too strong, however it is to be used wisely as only 5 missile launches are permitted per game.
	
3. How we modelled objects and entities
The app has 6 main models. 
	1. The player model is a red cube, built using Unity's inbuilt 3D cube model
	2. The zombie model was downloaded from the asset store, which came with animations which we used for 			walking/attacking. The zombies will spawn in the afforementioned fog, in a random position around the player
	3. The bullet model is a 3D sphere generated using Unity's in-built sphere model
	4. The terrain is inifinte and is implemented using planes as tiles for a tile-Map style terrain and perlin noise function to alter the height and make each tile flow seamlessly, we used the Phong shader with texturing and bumpmaps explored in labs, we altered the diffuse, ambient and specular influence to 1, 0.5 and 0.2 respectively to suit our terrain texture, a point light is use to illuminate the terrain, the point light sits above the player and moves with the player as well.
	5. The fog is another plane rendered above all other objects in the scene with a custom 'fog of war' shader applied to it to allow a viewport to display the character and it's current surroundings, the fog plane moves with the player as the terrain is infinite. The main use for the fog plane is to block out the spawning of zombies so the user doesn't see them appear from thin air when they are instantiated and also to block out the terrain tiles spawning into view as they are procedurally spawned/generated. The shader takes in the player positon, a radius and max fog radius which are used to determine the radius around the player of which the pixel values alhpa channel should be set lower, to allow transparency, the shader is a vertex and surface shader.
	6. The missile model is out sourced and the smoke trail is a shuriken particle system, that we used Unity's particle system tools to build.
	
4. How you handled graphics and camera motion
To reduce the computation expense of the graphics we made our terrain procedurally generated/infinite, this means that only a small portion of the terrain is rendered under the player at one time, instead of having a larger map, which saves rendering computation.
The main camera has a script attached, which forces it to always look at and follow the player in a smooth motion from a predetermined fixed offset which gives an isometric view of the game.

5. A statement about any code/APIs you have sourced/used from the internet that is not your own.	
We used a few sources to help with the builidng of our game, listed below.

Procedural/Infinite perlin noise
https://www.youtube.com/watch?v=dycHQFEz8VI

Fog of war shader
https://www.youtube.com/watch?v=yzcfTb9e0lo

Touch input joysticks
https://www.youtube.com/watch?v=uSnZuBhOA2U

Accelerometer input
http://stackoverflow.com/questions/31389598/how-can-i-detect-a-shake-motion-on-a-mobile-device-using-unity3d-c-sharp

Zombie model & animations
http://u3d.as/bFW

Phong Shader
Phong texture shader from labs

Missile/Smoke trail
-https://www.youtube.com/watch?v=feTek1j1Beo
-http://tf3dm.com/3d-model/agm-114-hell-fire-17444.html

Textures
Downloaded from the Unity asset store

