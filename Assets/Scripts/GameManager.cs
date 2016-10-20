using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject zombie;
	public GameObject player;
	public GameObject roundUI;
	public GameObject killsUI;
	public GameObject missilesUI;

	public static int kills = 0;
	public static int missiles = 5;

	private float spawnRate = 1.0f;
	private int previousSpawnCount = 5;
	private int round = 1;

	// Use this for initialization
	void Start () {
	
		StartCoroutine (SpawnZombie (spawnRate));
	}

	private Vector3 GetRandomPosition() {

		Vector3 randomPoint = new Vector3(30, 0, -30);

		for (int i = 0; i < 1000; i++) {
			randomPoint = Random.insideUnitSphere * 40;
			randomPoint.y = 0.0f;

			if (Vector3.Distance (randomPoint, player.transform.position) > 30) {
				return player.transform.position + randomPoint;
			}
		}

		return player.transform.position + randomPoint;
	}

	private void Spawn() {
		Instantiate (zombie, GetRandomPosition (), Quaternion.identity);

	}

	IEnumerator SpawnZombie(float rate) {
		int spawnCounter = previousSpawnCount;
		while (true) {
			yield return new WaitForSeconds (rate);
			Debug.Log ("Zombie Spawned");
			Spawn ();
			spawnCounter--;
			if(spawnCounter == 0) {
				round++;
				Debug.Log (round);
				spawnCounter = previousSpawnCount * 2;
				Debug.Log (spawnCounter);
				previousSpawnCount = spawnCounter;
				if(spawnRate > 1.0f) {
					spawnRate -= 0.5f;
				}
			}
		}

	}

    void Update() {

		roundUI.GetComponent<Text> ().text = "Wave :  " + round.ToString();
		killsUI.GetComponent<Text> ().text = "Kills :  " + kills.ToString();
		missilesUI.GetComponent<Text> ().text = "Missiles :  " + missiles.ToString ();

    }

}
