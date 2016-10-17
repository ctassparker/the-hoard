using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	private float bulletSpeed = 75f;
	private float bulletDamage = 50f;

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

	void OnCollisionEnter(Collision col) {
		if(col.gameObject.tag == "Zombie") {
			Debug.Log ("Zombie shot!");
			col.gameObject.GetComponent<HealthManager>().TakeDamage(bulletDamage);
		}
		Destroy (gameObject);

	}
}
