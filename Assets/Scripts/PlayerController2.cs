using UnityEngine;
using System.Collections;

public class PlayerController2 : MonoBehaviour {

	public PlayerMotor2 motor;
	public Joystick rotJoy;
	public Joystick moveJoy;
	public GameObject missile;

	// Use this for initialization
	void Start () {

		if(SystemInfo.deviceModel.Contains("iPhone")) {
			Debug.Log ("YO");
			Screen.orientation = ScreenOrientation.LandscapeLeft;
		}
	}

	void Update() {

		if(Input.GetKeyDown(KeyCode.Space)){


		}
	}

	void FixedUpdate() {

	
		motor.rotatePlayer (rotJoy.Horizontal(), rotJoy.Vertical());

		Vector3 moveVec = new Vector3 (moveJoy.Horizontal(), 0, moveJoy.Vertical());
		motor.movePlayer (moveVec);

	}
		
}
