using UnityEngine;
using System.Collections;

public class PlayerMotor2 : MonoBehaviour {

	public WeaponController weapon;
	private float horizontalRotateSpeed = 1.2f;
	private float moveSpeed = 5.0f;

	//public float floatStrength;

//	private float originalY;
//
//	void Start() {
//
//		originalY = transform.position.y;
//	}


	public void rotatePlayer(float deltax, float deltay) {

		if (deltax !=0 || deltay !=0) {
			float header = Mathf.Atan2 (deltax, deltay);

			float rotationangle = header * Mathf.Rad2Deg * horizontalRotateSpeed;

			transform.localRotation = Quaternion.Euler (0, rotationangle, 0);
		}
	}

	public void movePlayer(Vector3 movement) {
		transform.Translate(movement * Time.deltaTime * moveSpeed);
	}

//	void Update() {
//
//		Vector3 pos = transform.position;
//		pos.y = originalY + Mathf.Sin (Time.time) * floatStrength;
//		transform.position = pos;
//	}
}
