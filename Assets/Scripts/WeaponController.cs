using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {


	public Transform firePoint;

	public GameObject bulletPrefab;

	private bool canFire = true;

	private float fireRate = 100f;
	private float refreshCountdown = 10f;

	void Update() {

		if (!canFire) {

			FireCountdown ();
		}
	}

	void FireCountdown () {

		canFire = false;
		refreshCountdown -= Time.deltaTime * fireRate;

		if (refreshCountdown <= 0) {
			refreshCountdown = 20f;
			canFire = true;
		}
			
	}
		
	public void Shoot() {

		if (canFire) {
			Debug.Log ("Bullet fired at:" + firePoint.position + firePoint.rotation.eulerAngles);
			Instantiate (bulletPrefab, firePoint.position, firePoint.localRotation);
			canFire = false;
		}
	}
}
