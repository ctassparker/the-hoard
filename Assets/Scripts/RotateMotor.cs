using UnityEngine;
using System.Collections;

public class RotateMotor : MonoBehaviour {

	public Joystick rotJoy;

	private float horizontalRotateSpeed = 1.2f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		rotatePlayer (rotJoy. Horizontal(), rotJoy.Vertical());
	}

	public void rotatePlayer(float deltax, float deltay) {

		if (deltax !=0 || deltay !=0) {
			float header = Mathf.Atan2 (deltax, deltay);

			float rotationangle = header * Mathf.Rad2Deg * horizontalRotateSpeed;

			transform.localRotation = Quaternion.Euler (0, rotationangle, 0);

 		}
	}
}
