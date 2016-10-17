using UnityEngine;
using System.Collections;

public class RotateFiringPosition : MonoBehaviour {

	public Joystick rotJoy;
	public WeaponController weapon;


	private float horizontalRotateSpeed = 1.2f;

	// Update is called once per frame
	void FixedUpdate () {

		rotatePlayer (rotJoy. Horizontal(), rotJoy.Vertical());
	}

	public void rotatePlayer(float deltax, float deltay) {

		if (deltax !=0 || deltay !=0) {
			float header = Mathf.Atan2 (deltax, deltay);

			float rotationangle = header * Mathf.Rad2Deg * horizontalRotateSpeed;

			transform.localRotation = Quaternion.Euler (0, rotationangle, 0);

			weapon.Shoot ();

		}
	}
}
