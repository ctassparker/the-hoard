using UnityEngine;
using System.Collections;

public class ComputerControls : Controls {
	private float moveSpeed = 5.0f;
	float verticalVelocity = 0;
	private float jumpSpeed = 5f;

	bool Controls.playerMovement() {
		return (Input.GetAxis ("Vertical") != 0) | (Input.GetAxis("Horizontal") != 0);
	}
	Vector3[] Controls.getPlayerMovement() {
		//Directional Input
		float forwardSpeed = Input.GetAxis ("Vertical") * moveSpeed;
		float strafeSpeed = Input.GetAxis ("Horizontal") * moveSpeed;

		verticalVelocity += Physics.gravity.y * Time.deltaTime;

		//Set speed vector
		Vector3 speed = new Vector3 (strafeSpeed, verticalVelocity, forwardSpeed); 

		Vector3[] speedArray = new Vector3[1];
		speedArray [0] = speed;
		return speedArray;
	}
	Vector2[] Controls.getPlayerRotation() {
		Vector2[] test = null;
		return test;
	}

	bool Controls.cameraRotation() {
		return false;
	}

	void Controls.jump () {
		verticalVelocity = jumpSpeed;
	}

}

