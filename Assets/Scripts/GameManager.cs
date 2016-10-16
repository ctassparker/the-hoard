﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject zombie;
	public GameObject player;

	// Use this for initialization
	void Start () {
	
		SpawnZombies (10);
	}

	private void SpawnZombies(int zombCount) {

		InvokeRepeating ("Spawn", 0.0f, 2.0f);
	}

	private Vector3 GetRandomPosition() {

		Vector3 randomPoint = Random.insideUnitSphere * 40;
		randomPoint.y = 3.0f;

		return player.transform.position + randomPoint;
	}

	private void Spawn() {
		Instantiate (zombie, GetRandomPosition (), Quaternion.identity);
	}

}