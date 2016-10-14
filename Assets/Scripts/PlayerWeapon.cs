using UnityEngine;
using System.Collections;

public class PlayerWeapon : MonoBehaviour
{
	private Camera cam;

	// Use this for initialization
	void Start ()
	{
		cam = Camera.main; 
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void fire(){
		Ray ray = new Ray (cam.transform.position, cam.transform.forward);
		RaycastHit hitInfo;

		if (Physics.Raycast (ray, out hitInfo, 100)) {
			Vector3 hitPoint = hitInfo.point;

			GameObject go = hitInfo.collider.gameObject;

			if (go.tag == "Player") {
				// We've hit another player
				// Damage them
				PlayerController otherScript = go.GetComponent<PlayerController>();
				otherScript.health.CmdDamagePlayer (30);

			}

			Debug.Log ("Object hit: " + go.name);
		}
	}
}

