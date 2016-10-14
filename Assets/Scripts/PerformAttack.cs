using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PerformAttack : NetworkBehaviour {

	//Unfinished! - Stinngo

	[SerializeField]
	private Camera camera;

	//[SerializeField]
	//private LayerMask mask;

	public Weapon weapon;
	private float cooldownRemaining;


	public GameObject bulleteffect;


	// Use this for initialization
	void Start () {

		cooldownRemaining = 0.0f;
	
	}
	
	// Update is called once per frame
	// Make sure to change controls
	void Update () {

		if (cooldownRemaining > 0) 
		cooldownRemaining -= Time.deltaTime;
			
		if (Input.GetMouseButton (0) && cooldownRemaining <= 0 && weapon.getCurrentAmmo() > 0) {

			shoot ();

			updateWeaponStats ();

		}
				
	}

	void shoot() {
		
		Ray ray = new Ray (Camera.main.transform.position, Camera.main.transform.forward);
		RaycastHit hitInfo;

		if (Physics.Raycast (ray, out hitInfo, weapon.getRange())) {
			Vector3 hitPoint = hitInfo.point;

			if (hitInfo.rigidbody) {
				HitObjectRigidBody (hitInfo);
			}

			GameObject go = hitInfo.collider.gameObject;
			//Instantiate (bulleteffect, hitInfo.transform.position, transform.rotation);

			if (go.tag == "Enemy") {
				
				HealthManager hm = (HealthManager)go.GetComponent (typeof(HealthManager));
				hm.TakeDamage (40f);
				Debug.Log ("Got here");
			}
				

		}
			
	
	}

	void updateWeaponStats () 
	{
		this.cooldownRemaining = weapon.fireRate;
		weapon.useAmmo ();
		
	}

	void HitObjectRigidBody(RaycastHit hitInfo)
	{
		hitInfo.rigidbody.AddForceAtPosition (weapon.getForce() 
			* Camera.main.transform.forward, hitInfo.point);
	}
		
}
