using UnityEngine;
using System.Collections;

public class PlayerController2 : MonoBehaviour {

	public PlayerMotor2 motor;
	public Joystick rotJoy;
	public Joystick moveJoy;

	// The devide between moving and scrolling with the touch screen
	private int screenXDivide = (Screen.width) / 2;
	int screenWidth = Screen.width;
	// Use this for initialization
	void Start () {

		if(SystemInfo.deviceModel.Contains("iPhone")) {
			Debug.Log ("YO");
			Screen.orientation = ScreenOrientation.LandscapeLeft;
		}
	}

	void FixedUpdate() {


		motor.rotatePlayer (rotJoy.Horizontal(), rotJoy.Vertical());

		Vector3 moveVec = new Vector3 (moveJoy.Horizontal(), 0, moveJoy.Vertical());
		motor.movePlayer (moveVec);
//		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
//			// Go through each touch
//			for (int i = 0; i < Input.touchCount; i++) {
//				Vector2 deltaTouch = Input.GetTouch(i).deltaPosition;
//				if (Input.GetTouch (i).position.x < screenXDivide) {
//					// Is movement for the player, left hand part of screen
//					Vector3 v3Touch = new Vector3 (deltaTouch.x,0,deltaTouch.y);
//					motor.movePlayer (v3Touch);
//
//					// Check if the player is scrolling on the buttons
//				} else if (Input.GetTouch (i).position.x  < screenWidth) {
//					// Is rotation for player, right hand part of screen
//					motor.rotatePlayer(deltaTouch.x,deltaTouch.y);
//
//				}
//			}
//		}
	}
	
//	// Update is called once per frame
//	void Update () {
//	
//		if (Input.GetKey (KeyCode.LeftArrow)) {
//		
//			this.transform.position += Vector3.left * Time.deltaTime * 5;
//		}
//
//		if (Input.GetKey (KeyCode.RightArrow)) {
//
//			this.transform.position += Vector3.right * Time.deltaTime * 5;
//		}
//
//		if (Input.GetKey (KeyCode.UpArrow)) {
//
//			this.transform.position += Vector3.forward * Time.deltaTime * 5;
//		}
//
//		if (Input.GetKey (KeyCode.DownArrow)) {
//
//			this.transform.position += Vector3.back * Time.deltaTime * 5;
//		}
//	}
}
