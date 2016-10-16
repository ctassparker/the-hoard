using UnityEngine;
using System.Collections;

public class MissileController : MonoBehaviour {


	private GameObject target;
	private float speed = 35f;

	public void Seek (GameObject _target) {
	
		target = _target;
	}

	void Update() {


		if (target ==null) {

			Destroy (gameObject);
			return;
		}

		Vector3 dir = target.transform.position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;
		Debug.Log (distanceThisFrame);
		if(dir.magnitude <= distanceThisFrame) {

			HitTarget ();
			return;
		}

		transform.LookAt (target.transform.position);
		transform.Translate (dir.normalized * distanceThisFrame, Space.World);
	}

	void HitTarget() {

		Debug.Log ("We Hit Something");
		Destroy (this.gameObject);
		Destroy (target);
	}


}
