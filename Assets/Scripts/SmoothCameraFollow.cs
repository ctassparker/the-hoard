using UnityEngine;
using System.Collections;

public class SmoothCameraFollow : MonoBehaviour {

	public Transform lookAt;

	private bool smooth = true;
	private float smoothSpeed = 0.1f;
	private Vector3 offset = new Vector3 (0f, 20f, -20f);

	void Start() {

		this.transform.eulerAngles = new Vector3 (45, 0, 0);
	}

	private void LateUpdate() {
	
		Vector3 desiredPosition = lookAt.transform.position + offset;

		if (smooth) {

			transform.position = Vector3.Lerp (transform.position, desiredPosition, smoothSpeed);
		} else {
		
			transform.position = desiredPosition;
		}

	}
}
