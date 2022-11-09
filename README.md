# Survival Game Prototype

A basic survival game prototype.

## Controls:

• Move forward, left, back and right - 	**W, A, S, D.**

• Interact/Pick up item - 	**E.**

• Open Inventory - 	**I.**

## Features:



## Player movement system and camera follow system.

The player is able to move around on the terrain with use of a script that detects user keystrokes and moves the player object accordingly. The main camera is moved by detecting the mouse position and following it.

## Random generation of trees, rocks and berry bushes on terrain.

Spawn points are selected on the terrain during runtime by generating random X and Z co-ordinates, then the terrain is sampled for its height value which is set to the Y value, and a tree, rock or berry bush is generated at that position. This means a random set of trees/rocks/berry bushes is generated each time.

![Random Generation](https://user-images.githubusercontent.com/46501575/200926357-e762a373-f4dd-4090-96d9-cfc30bdefb01.png)

## Axe and pickaxe equipment system.

When the player first enters the game, they have the ability to pick up an axe or pickaxe by pressing the "E" key. Doing so will "equip" the item, meaning the model of the item on the floor will be destroyed and an animated first person version will be enabled in the game hierarchy which is attached to the player. The axe and pickaxe both have idle and swing animations that are triggered by idling or clicking the left mouse button, using a script. Picking up an axe/pickaxe will add the respective item to the players inventory. The player also has the ability to drop the axe/pickaxe by pressing F. This will instantiate a new item model on the floor and disable the first person view of that item.

![Equipment1](https://user-images.githubusercontent.com/46501575/200940241-e38479da-c1db-44cd-99d3-722a19bdfa26.png)

![Equipment2](https://user-images.githubusercontent.com/46501575/200940261-1fbb290b-34bc-4a72-abdb-15892306c9de.png)

![Equipment3](https://user-images.githubusercontent.com/46501575/200940808-b1caef08-7255-4ce1-ac61-1dd389da7f7c.png)

## Tree/rock destruction and item collection system.

All trees and rocks spawned in the game can be broken, provided the player has equipped the correct tool. For instance, trees can only be broken if the player has an axe equipped, rocks can only be broken if the player has a pickaxe equipped. Once a tree or rock has been broken, that gameobject is destroyed, a particle effect is instantiated and an item is instantiated that the player can pick up by pressing "E" (rocks have to broken multiple times to drop items). Once a player picks up an item, the tag of that item is then added to the inventory system. Berries can be picked up simply by pressing "E". This is done by using a raycast and tagging gameobjects to distinguish between different objects in the game and storing health values for each tree/rock which are decreased when the player clicks on them. Once the health reaches zero, that gameobject is destroyed and an item object is instantiated in its place.

![Treerock](https://user-images.githubusercontent.com/46501575/200941491-ec97e7c1-48cf-4b1b-bbaa-d49c5b4cca17.png)

![Treerock1](https://user-images.githubusercontent.com/46501575/200941745-74deef5a-c291-4181-827a-215084211d40.png)

## Inventory system and inventory UI.

Picked up items are added to a list which stores the tags of each item that has been picked up. A UI to display these values is enabled in the hierarchy when the player presses the "I" key, which also disables scripts for movement and camera control. These can be re-enabled, along with disabling the UI element when the user presses "I" once more. The inventory UI will look through the inventory list when it is opened, and instantiate UI icons (at the moment they are just different coloured squares) in different positions relative to available slots in the inventory. Put simply, this means the player is able to open an inventory by pressing "I", which logs current items that have been gathered.

![Inventory](https://user-images.githubusercontent.com/46501575/200942127-8e3137dc-b846-4d4e-81f2-fdf44bc8f38a.png)

## Day/Night system and enemy spawning.

The time of day slowly progresses as the player plays the game. This is done by altering the values of the directional light in the scene and using a lighting preset to make the scene appear as though it is a different time of day. We also log the time of day with a variable, and use it to determine whether or not to enable the "EnemySpawner" gameobject, which contains a script to select random points - relative to the player - to spawn enemy gameobjects. The enemy spawner is enabled during the night and disabled at sunrise, along with destroying all enemy gameobjects. Effectively this means that there is a day and night system, which spawns enemies at night, and despawns them at sunrise. Full days are ten minutes long, however it takes roughly five to seven minutes for enemies to begin spawning.

![Enemies and night](https://user-images.githubusercontent.com/46501575/200943072-e7157105-5226-48d6-9f8e-c493019ff7cf.png)


## Enemy and health/health UI system and death.

Enemy gameobjects are attached to the aforementioned "EnemySpawner", which is enabled or disabled depending on the time of day. Enemies themselves are placeholder capsules with an enemy AI attached. The AI has a number of different behaviour states which are transitioned between depending on the condition of the player. Enemies also have health which is decreased if the player attacks them (presses left mouse button while the tag has been hit with the players raycast). The player can also receive damage from the enemies, which is done by decreasing a value and updating the health UI when the enemy comes into collision with the player.

![health](https://user-images.githubusercontent.com/46501575/200944045-749ab10c-30fe-4b1c-aa7f-779157565c96.png)
