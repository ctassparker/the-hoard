using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {


	private GameObject target;
	private float speed = 1.5f;
	private float damage = 20f;
	private bool canAttack = true;

	public void Seek (GameObject _target) {

		target = _target;
	}
		
	void Start() {

		this.Seek (GameObject.FindGameObjectWithTag("Player"));
	}

	void Update() {

		if (target == null) {

			Destroy (gameObject);
			return;
		}

		Vector3 dir = target.transform.position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;
		if (dir.magnitude <= distanceThisFrame && canAttack) {

			HitTarget ();
			return;
		}

		float step = speed * Time.deltaTime;
		Vector3 newDir = Vector3.RotateTowards (transform.forward, dir, step, 0.0f);
		Debug.DrawRay (transform.position, newDir, Color.red);
		transform.rotation = Quaternion.LookRotation (newDir);
		transform.Translate (dir.normalized * distanceThisFrame, Space.World);
	}

	void HitTarget() {

		Debug.Log ("We Hit player");
		target.GetComponent<HealthManager> ().TakeDamage (damage);
		canAttack = false;
		StartCoroutine("AttackCountdown");
	}

	IEnumerator AttackCountdown() {
	
		yield return new WaitForSeconds (0.5f);
		canAttack = true;
	}


}
