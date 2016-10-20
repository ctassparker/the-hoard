using UnityEngine;
using System.Collections;

public class FogPlayer : MonoBehaviour {

	public Transform fogPlane;

	void Start() {
	
	}

	void Update() {

		Vector3 screePos = Camera.main.WorldToScreenPoint (transform.position);

		Ray rayToPlayerPos = Camera.main.ScreenPointToRay (screePos);

		RaycastHit hit;
		if (Physics.Raycast (rayToPlayerPos, out hit, 1000)) {
		
			fogPlane.GetComponent<Renderer> ().material.SetVector ("_Player_Pos", hit.point);
		}
	}
}
