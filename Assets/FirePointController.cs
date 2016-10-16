using UnityEngine;
using System.Collections;

public class FirePointController : MonoBehaviour {

	public WeaponController weapon;

	private float horizontalRotateSpeed = 0.6f;

	public Joystick rotJoy;
	public Joystick movJoy;

	private float moveSpeed = 5.0f;


	void FixedUpdate() {


		rotatePoint (rotJoy.Horizontal (), rotJoy.Vertical ());
		movePoint (new Vector3(movJoy.Horizontal(), 0, movJoy.Vertical()));
	}

	public void rotatePoint(float deltax, float deltay) {

		if (deltax !=0 || deltay !=0) {
			
			float header = Mathf.Atan2 (deltax, deltay);

			float rotationangle = header * Mathf.Rad2Deg * horizontalRotateSpeed;

			transform.localRotation = Quaternion.Euler (0, rotationangle, 0);

			weapon.Shoot ();
		}
	}

	public void movePoint(Vector3 movement) {
		//Move the player
		transform.Translate(movement * Time.deltaTime * moveSpeed);

	}
}
