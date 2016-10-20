using UnityEngine;
using System.Collections;

class Tile {

	public GameObject tile;
	public float creationTime;

	public Tile(GameObject t, float ct) {
	
		tile = t;
		creationTime = ct;
	}
}

public class GenerateInfinite : MonoBehaviour {

	public GameObject plane;
	public GameObject player;
	public GameObject pointLight;


	private int planeSize = 10;
	private int halfTilesX = 6;
	private int halfTilesZ = 6;

	private Vector3 startPos;

	private Hashtable tiles = new Hashtable();

	// Use this for initialization
	void Start () {
	
		this.gameObject.transform.position = Vector3.zero;
		startPos = Vector3.zero;

		float updateTime = Time.realtimeSinceStartup;

		for(int x = -halfTilesX; x < halfTilesX; x++){

			for(int z = -halfTilesZ; z < halfTilesZ; z++) {

				Vector3 pos = new Vector3 (
					              (x * planeSize + startPos.x),
					              0,
					              (z * planeSize + startPos.z));

				GameObject t = (GameObject)Instantiate (plane, pos, Quaternion.identity);
				GenerateTerrain gt = t.GetComponent<GenerateTerrain> ();
				gt.pointLight = this.pointLight;

				string tilename = "Tile_" + ((int)(pos.x)).ToString () + "_" + ((int)(pos.z)).ToString ();

				t.name = tilename;

				Tile tile = new Tile (t, updateTime);
				tiles.Add (tilename, tile);
			}
		}
	}

	void Update() {

		int xMove = (int)(player.transform.position.x - startPos.x);
		int zMove = (int)(player.transform.position.z - startPos.z);

		if(Mathf.Abs(xMove) >= planeSize || Mathf.Abs(zMove) >= planeSize) {

			float updateTime = Time.realtimeSinceStartup;

			int playerX = (int)(Mathf.Floor (player.transform.position.x / planeSize) * planeSize);
			int playerZ = (int)(Mathf.Floor (player.transform.position.z / planeSize) * planeSize);

			for (int x = -halfTilesX; x < halfTilesX; x++) {
				for (int z = -halfTilesZ; z < halfTilesZ; z++) {

					Vector3 pos = new Vector3 (
						(x * planeSize + playerX),
						0,
						(z * planeSize + playerZ));

					string tilename = "Tile_" + ((int)(pos.x)).ToString () + "_" + ((int)(pos.z)).ToString ();

					if (!tiles.ContainsKey (tilename)) {
					
						GameObject t = (GameObject)Instantiate (plane, pos, Quaternion.identity);
						GenerateTerrain gt = t.GetComponent<GenerateTerrain> ();
						gt.pointLight = this.pointLight;

						t.name = tilename;
						Tile tile = new Tile (t, updateTime);
						tiles.Add (tilename, tile);
					} else {
					

						(tiles [tilename] as Tile).creationTime = updateTime;
					}
				}

			}

			Hashtable newTerrain = new Hashtable ();
			foreach (Tile tls in tiles.Values) {
			
				if (tls.creationTime != updateTime) {

					Destroy (tls.tile);
				} else {
				
					newTerrain.Add (tls.tile.name, tls);
				}
			}

			tiles = newTerrain;

			startPos = player.transform.position;
		}
	}

}
