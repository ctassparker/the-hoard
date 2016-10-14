using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class HealthManager : NetworkBehaviour {
	// Textures for the health manager
	public Texture greenTexture;  
	public Texture redTexture;

	private float timeSinceDamaged;
	private float timeThreshold;
	private float maxHealth;
	private float healthRegenAmount;

	private float currentHealth;

	void Awake() {
		maxHealth = 100;
		currentHealth = 30;
		greenTexture = (Texture) Resources.Load ("green");
		redTexture = (Texture) Resources.Load ("red");
	}

	[Command]
	public void CmdDamagePlayer(int dam) {
		currentHealth -= dam;
		Debug.Log ("Oww, player now has " + currentHealth + " hp");
		if (currentHealth <= 0) {
			RpcRespawn ();
		}
	}


	[ClientRpc]
	public void RpcRespawn() {
		Debug.Log ("Respawning");
		currentHealth = maxHealth;
	}

	void OnGUI()
	{
		makeHealthBar ();
	}

	public void makeHealthBar (){
		float barWidth = 200f;
		float barHeight = 20f;
		float greenWidth = barWidth * (currentHealth / maxHealth); 
		float redWidth = barWidth - greenWidth;

		// Offset from the top of the screen
		int offset = 10;

		// The leftmost x point for the green bar
		float xGreen = (Screen.width / 2) - (barWidth / 2);

		float xRed = xGreen + greenWidth;

		GUI.DrawTexture ((new Rect (xGreen, offset, greenWidth, barHeight)), greenTexture, ScaleMode.StretchToFill);
		GUI.DrawTexture ((new Rect (xRed, offset, redWidth, barHeight)), redTexture, ScaleMode.StretchToFill);

	}


	public void TakeDamage(float damageAmount)
	{
		currentHealth -= damageAmount;
		timeSinceDamaged = 0;
	}

	void Update()
	{
		timeSinceDamaged += Time.deltaTime;
		if (timeSinceDamaged >= timeThreshold) {
			regenerateHealth ();
		}

	}

	void regenerateHealth()
	{
		currentHealth += healthRegenAmount;
		currentHealth = Mathf.Min (maxHealth, currentHealth);
	}


	public float getCurrentHealth()
	{
		return currentHealth;
	}

	public void setCurrentHealth(float hp)
	{
		currentHealth = hp;
	}



}
