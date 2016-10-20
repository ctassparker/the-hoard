using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject zombie;
	public GameObject player;

	private float spawnRate = 5;
	private int spawnCounter = 12;

	// Use this for initialization
	void Start () {
	
		SpawnZombies (spawnRate);
	}

	private void SpawnZombies(float spawnRate) {

		InvokeRepeating ("Spawn", 0.0f, spawnRate);
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

    void Update() {
        if (this.player == null) {
            SceneManager.LoadScene(0);
        }
    }

}
