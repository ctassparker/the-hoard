using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerMotor : NetworkBehaviour
{
	private Camera cam;
	private Vector3 camOffset = new Vector3(0f,1.75f,0.17f);
	private float jumpSpeed = 20f;
	private CharacterController cc;

	private float verticalRotation = 0;
	private float horizontalRotation = 0;

	private float verticalRotateSpeed = 0.2f;
	private float horizontalRotateSpeed = 0.6f;

	private float verticalVelocity = 0;

	private float upDownRange = 60.0f;


	void Start ()
	{
		cam = Camera.main; 
		cc = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if (!cc.isGrounded || verticalVelocity != 0) {
			verticalVelocity += Physics.gravity.y * Time.deltaTime;
			movePlayer(new Vector3(0,verticalVelocity,0));

		}
		// Get camera to follow player
		cam.transform.position = this.transform.position + camOffset;
	}

	// Use a single camera in the scene, but make sure it's following the correct player
	void OnNetworkInstantiate(NetworkMessageInfo message) {
		if (GetComponent<NetworkView>().isMine) {
			cam = Camera.main;
		}
	}

	public void rotatePlayer(float deltax, float deltay) {
		
		horizontalRotation -= deltax * horizontalRotateSpeed;
		verticalRotation -= deltay * verticalRotateSpeed;
		verticalRotation = Mathf.Clamp (verticalRotation, -upDownRange, upDownRange);

		cam.transform.position = this.transform.position;
		transform.rotation = Quaternion.Euler (0,horizontalRotation, 0);
		// Rotate the camera
		cam.transform.rotation = Quaternion.Euler (verticalRotation,horizontalRotation, 0);
	}

	public void movePlayer(Vector3 movement) {
		movement = transform.rotation * movement;
		//Move the player
		cc.Move (movement * Time.deltaTime);

	}
	public void jump() {
		if (cc.isGrounded) {
			verticalVelocity = jumpSpeed;
		}

	}

}

