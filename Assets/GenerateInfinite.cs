using UnityEngine;
using System.Collections;

class Tile {

	public GameObject tile;

	public Tile(GameObject t) {
	
		tile = t;
	}
}

public class GenerateInfinite : MonoBehaviour {

	public GameObject plane;
	public GameObject player;

	private int planeSize = 10;
	private int halfTilesX = 10;
	private int halfTilesZ = 10;

	private Vector3 startPos;

	private Hashtable tiles = new Hashtable();

	// Use this for initialization
	void Start () {
	
		this.gameObject.transform.position = Vector3.zero;
		startPos = Vector3.zero;

		for(int x = -halfTilesX; x < halfTilesX; x++){

			for(int z = -halfTilesZ; z < halfTilesZ; z++) {

				Vector3 pos = new Vector3 (
					              (x * planeSize + startPos.x),
					              0,
					              (z * planeSize + startPos.z));

				GameObject t = (GameObject)Instantiate (plane, pos, Quaternion.identity);

				string tilename = "Tile_" + ((int)(pos.x)).ToString () + "_" + ((int)(pos.z)).ToString ();

				t.name = tilename;

				Tile tile = new Tile (t);
				tiles.Add (tilename, tile);
			}
		}
	}

}
