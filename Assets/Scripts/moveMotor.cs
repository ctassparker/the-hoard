using UnityEngine;
using System.Collections;

public class moveMotor : MonoBehaviour {

	public Joystick moveJoy;

	private float moveSpeed = 5.0f;

	void FixedUpdate() {

		Vector3 moveVec = new Vector3 (moveJoy.Horizontal(), 0, moveJoy.Vertical());
		movePlayer (moveVec);
	}

	public void movePlayer(Vector3 movement) {
		transform.position += movement * Time.deltaTime * moveSpeed;
	}

}
