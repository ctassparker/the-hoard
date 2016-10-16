using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	private float bulletSpeed = 75f;
	public PlayerMotor2 motor;

	// Use this for initialization
	void Start () {
		StartCoroutine ("LifeSpan");
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate(transform.forward * bulletSpeed * Time.deltaTime);
	}

	IEnumerator LifeSpan() {

		yield return new WaitForSeconds (1);
		Destroy (gameObject);
	}
}
