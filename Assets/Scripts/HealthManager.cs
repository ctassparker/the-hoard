using UnityEngine;
using System.Collections;

public class HealthManager : MonoBehaviour {

	public float health;

	void Update() {

		if (this.health <= 0f) {
			//if (gameObject.tag == "Zombie") {
				Destroy (gameObject);
			//}
		}
	}
	
	public void TakeDamage(float damage) {

		health -= damage;
	}
}
