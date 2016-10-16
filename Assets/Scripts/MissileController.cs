using UnityEngine;
using System.Collections;

public class MissileController : MonoBehaviour {


	private GameObject target;
	private float speed = 10f;

	public void Seek (GameObject _target) {
	
		target = _target;
	}

	void Update() {


		if (target == null) {

			Destroy (gameObject);
			return;
		}

		Vector3 dir = target.transform.position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;
		if(dir.magnitude <= distanceThisFrame) {

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

		Debug.Log ("We Hit Something");
		Destroy (this.gameObject);
		Destroy (target);
	}


}
