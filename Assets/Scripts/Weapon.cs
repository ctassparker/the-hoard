using UnityEngine;
using System.Collections;

[System.Serializable]
public class Weapon : MonoBehaviour {

	//Initialised values

	public int ammoCapacity;
	public float fireRate;
	public float maxDamage;
	public float reloadTime;
	public string weaponName;
	public float sphereCastRadius;
	public float range;

	private int currentAmmo;

	//Audio
	AudioSource ac;
	public AudioClip gunshotSound;
	public AudioClip reloadSound;
	public AudioClip reloadDoneSound;

	//Float determining force
	public float force = 200;


	public Weapon (int ammoCapacity, float fireRate, float maxDamage, float reloadTime, float sphereCastRadius, string weaponName)
	{
		this.ammoCapacity = ammoCapacity;
		this.fireRate = fireRate;
		this.maxDamage = maxDamage;
		this.reloadTime = reloadTime;
		this.sphereCastRadius = sphereCastRadius;
		this.weaponName = weaponName;

	}
		
	void Awake ()
	{
		currentAmmo = ammoCapacity;
		ac = GetComponent<AudioSource>();
	}

	public void useAmmo ()
	{
		ac.PlayOneShot (gunshotSound);
		currentAmmo--;
		if (currentAmmo == 0) 
			StartCoroutine(reload());
	}


	//Watch out with this for networking
	IEnumerator reload()
	{
		ac.PlayOneShot (reloadSound);

		this.transform.Rotate (0, -30, 0);
		yield return new WaitForSeconds (reloadTime);
		this.transform.Rotate (0, 30, 0);

		ac.PlayOneShot (reloadDoneSound);
		yield return new WaitForSeconds (0.15f);
		currentAmmo = ammoCapacity;

	}


	public float damageCalc(float distance)
	{
		return 1 / distance * maxDamage;
	}

		

	public float getRange()
	{
		return this.range;
	}

	public float getForce()
	{
		return this.force;
	}

	public int getCurrentAmmo()
	{
		return this.currentAmmo;
	}



}
