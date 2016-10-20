using UnityEngine;
using System.Collections;

public class MissileLauncher : MonoBehaviour {

	public GameObject missile;
	public GameObject player;

	private bool canFire;

	private float accelerometerUpdateInterval = 1 / 60;
	private float lowPassKernelWidthSeconds = 1.0f;
	private float shakeDetectionThreshold = 1.5f;
	private float lowPassFilterFactor;
	private Vector3 lowPassvalue = Vector3.zero;
	private Vector3 acceleration;
	private Vector3 deltaAcceleration;

	void Start() {
		canFire = true;
		lowPassFilterFactor = accelerometerUpdateInterval / lowPassKernelWidthSeconds;
		shakeDetectionThreshold *= shakeDetectionThreshold;

		lowPassvalue = Input.acceleration;
	}

	void Update() {

		acceleration = Input.acceleration;
		lowPassvalue = Vector3.Lerp (lowPassvalue, acceleration, lowPassFilterFactor);
		deltaAcceleration = acceleration - lowPassvalue;

		if(deltaAcceleration.sqrMagnitude >= shakeDetectionThreshold && canFire && GameManager.missiles > 0) {

			StartCoroutine ("DropMissiles");
			Debug.Log ("SHAAAAAAAAAAAAAAAAKE!!!!!");
		}

		if(Input.GetKeyDown(KeyCode.Space) && GameManager.missiles > 0) {
			StartCoroutine ("DropMissiles");

		}

	}

	IEnumerator DropMissiles() {
		LaunchMissiles ();
		canFire = false;
		yield return new WaitForSeconds (10);
		canFire = true;
	}

	void LaunchMissiles() {

		GameManager.missiles--;

		Debug.Log ("Launching missiles");
		GameObject[] targets = GameObject.FindGameObjectsWithTag ("Zombie");

		foreach(GameObject target in targets) {
			Vector3 offset = new Vector3 (Random.Range(-20f, 20f), Random.Range(20f, 30f), Random.Range(-20f, 20f));

			Debug.Log ("missile launched");

			if (Vector3.Distance (target.transform.position, player.transform.position) < 20) {
				Vector3 pos = target.transform.position + offset;

				Debug.Log ("target " + target.transform.position + " missile: " + pos);

				GameObject missileGO = (GameObject)Instantiate (missile, pos, Quaternion.identity); 

				MissileController mc = missileGO.GetComponent<MissileController> ();

				if (mc != null) {

					mc.Seek (target);
				}
			}
		}
	}
}
