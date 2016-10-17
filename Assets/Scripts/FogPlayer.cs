using UnityEngine;
using System.Collections;

public class FogPlayer : MonoBehaviour {

	public GameObject fogPlane;
	public GameObject player;

	// Update is called once per frame
	void Update () {

		Vector3 screenPos = Camera.main.WorldToScreenPoint (player.transform.position);
		Ray rayToPlayerPos = Camera.main.ScreenPointToRay (screenPos);

		int layerMask = (int)(1<<8);

		RaycastHit hit;
		if (Physics.Raycast (rayToPlayerPos, out hit, 1000, layerMask)) {
			fogPlane.GetComponent<Renderer> ().sharedMaterial.SetVector ("_Player_Pos", hit.point);
		}
	}
}
