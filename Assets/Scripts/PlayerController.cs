using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {
	public PlayerMotor motor;
	public PlayerWeapon playerweapon;
	public HealthManager health;
	private bool isAndriod = false;

	// Params for the buttons on the right of the screen
	private static readonly int buttonWidth = 100;

	// The devide between moving and scrolling with the touch screen
	private int screenXDivide = (Screen.width - buttonWidth) / 2;
	int screenWidth = Screen.width;
	static int screenHeight = Screen.height;
	int buttonHeight =  screenHeight / 4;
		
	void OnGUI(){
		createButtons();
	}
	void Update() {
		//Debug.Log (health);

	}
	void Start() {
		motor = GetComponent<PlayerMotor> ();
		playerweapon = GetComponent<PlayerWeapon> ();
		health = GetComponent<HealthManager> ();

		if (isAndriod) {
			Screen.orientation = ScreenOrientation.LandscapeLeft;
		}
		else {
			//Cursor.lockState = CursorLockMode.Locked;
		}
	}
		
	void FixedUpdate() {
		if (!isLocalPlayer){
			return;
		}

		if (isAndriod) {

			if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
				// Go through each touch
				for (int i = 0; i < Input.touchCount; i++) {
					Vector2 deltaTouch = Input.GetTouch(i).deltaPosition;
					if (Input.GetTouch (i).position.x < screenXDivide) {
						// Is movement for the player, left hand part of screen
						Vector3 v3Touch = new Vector3 (deltaTouch.x,0,deltaTouch.y);
						motor.movePlayer (v3Touch);

							// Check if the player is scrolling on the buttons
					} else if (Input.GetTouch (i).position.x  < screenWidth - buttonWidth) {
						// Is rotation for player, right hand part of screen
						motor.rotatePlayer(deltaTouch.x,deltaTouch.y);

					}
				}
			}
		} else {
			if ((Input.GetAxis ("Vertical") != 0) | (Input.GetAxis("Horizontal") != 0)) {
				//movePlayer();


				//Directional Input
				float forwardSpeed = Input.GetAxis ("Vertical");
				float strafeSpeed = Input.GetAxis ("Horizontal");


				//Set speed vector
				Vector3 speed = new Vector3 (strafeSpeed, 0, forwardSpeed); 
				motor.movePlayer(speed);
			}
		}
			
	}
		
	public void map(){
	}
	public void chat(){
	}

	public void createButtons(){

		if (GUI.Button(new Rect(screenWidth - buttonWidth,screenHeight - buttonHeight,buttonWidth,buttonHeight), "Fire")){
			Debug.Log("Fire");
			playerweapon.fire ();
		}
		if (GUI.Button(new Rect(screenWidth - buttonWidth,screenHeight - 2*buttonHeight,buttonWidth,buttonHeight), "Jump")){
			motor.jump ();
			Debug.Log("Jump");
		}
		if (GUI.Button(new Rect(screenWidth - buttonWidth,screenHeight - 3*buttonHeight,buttonWidth,buttonHeight), "Map")){
			map ();
			Debug.Log("Map");
		}
		if (GUI.Button(new Rect(screenWidth - buttonWidth,screenHeight - 4*buttonHeight,buttonWidth,buttonHeight), "Chat")){
			Debug.Log("Chat");
			chat ();
		}
	}
}



