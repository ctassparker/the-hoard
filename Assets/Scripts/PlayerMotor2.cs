using UnityEngine;
using System.Collections;

public class PlayerMotor2 : MonoBehaviour {

	private float horizontalRotation = 0;
	private float horizontalRotateSpeed = 0.6f;
	private CharacterController cc;
	private float moveSpeed = 5.0f;

	void Start() {

		cc = GetComponent<CharacterController> ();
	}

	public void rotatePlayer(float deltax, float deltay) {

		float header = Mathf.Atan2 (deltax, deltay);

		float rotationangle = header * Mathf.Rad2Deg * horizontalRotateSpeed;

		transform.rotation = Quaternion.Euler (0, rotationangle, 0);
	}

	public void movePlayer(Vector3 movement) {
		movement = transform.rotation * movement;
		//Move the player
		cc.Move (movement * Time.deltaTime * moveSpeed);

	}
}
