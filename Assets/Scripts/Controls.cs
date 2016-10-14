using UnityEngine;
using System.Collections;

interface Controls {

	// boolean if the player needs to move
	bool playerMovement();
	Vector3 [] getPlayerMovement();
	// boolean if the player needs to rotate
	bool cameraRotation();
	Vector2[] getPlayerRotation();
	void jump();
}

