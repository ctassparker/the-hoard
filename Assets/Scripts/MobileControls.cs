using UnityEngine;
using System.Collections;

// This class assumes GUI buttons have been created
public class MobileControls : Controls {
	int screenWidth = Screen.width;
	int screenHeight = Screen.height;
	//int screenXDivide = (Screen.width - 100) / 2;
	private float moveSpeed = 5.0f;
	private int screenXDivide = (Screen.width - 100) / 2;

	bool Controls.playerMovement() {
		return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && Input.GetTouch(0).position.x < screenXDivide;	
	}

	Vector3[] Controls.getPlayerMovement() {
		int touchesCount = 0;
		// Check how many touches are valid first
		for (int i = 0; i < Input.touchCount; i++) {
			if (Input.GetTouch (i).position.x < screenXDivide) {
				touchesCount += 1;
			}
		}

		Vector3[] touches = new Vector3[touchesCount];

		for (int i = 0; i < Input.touchCount; i++) {
			Vector2 aTouchPos = Input.GetTouch (i).position;
			Vector2 aTouchDel = Input.GetTouch (i).deltaPosition;
			if (aTouchPos.x < screenXDivide) {
				Vector3 v3Touch = new Vector3 (aTouchDel.x,0,aTouchDel.y);
				touches [i] = v3Touch;
			}
		}
		return touches;
	}

	bool Controls.cameraRotation() {
		return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && Input.GetTouch(0).position.x > screenXDivide;	
	}


	Vector2[] Controls.getPlayerRotation() {
		int touchesCount = 0;
		// Check how many touches are valid first
		for (int i = 0; i < Input.touchCount; i++) {
			if (Input.GetTouch (i).position.x > screenXDivide) {
				touchesCount += 1;
			}
		}
		Debug.Log ("Touch count is " + touchesCount);
		Debug.Log ("Unity touch count is " + Input.touchCount);

		Vector2[] touches = new Vector2[touchesCount];

		for (int i = 0; i < Input.touchCount; i++) {
			Vector2 aTouchPos = Input.GetTouch (i).position;
			Vector2 aTouchDel = Input.GetTouch (i).deltaPosition;
			if (aTouchPos.x > screenXDivide) {
				touches [i] = aTouchDel;
			}
		}
		return touches;
	}

	void Controls.jump () {
	}


}

