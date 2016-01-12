using UnityEngine;
using System.Collections;

/**
 * Autogeneration the terrain while the hero runs on it
 */
public class TerrainAutoGeneration : MonoBehaviour {


	private bool terrainCreated = false;
	private float middleTerrainZ;
	private float terrainLength;
	private float terrainPosZ;
	private Terrain terrain;

	private GameObject lightPrefab;

	// Use this for initialization
	/**
	 * Initialization
	 */
	void Start () {
		terrain = this.gameObject.GetComponent<Terrain>();
		terrainPosZ = terrain.transform.position.z;
		terrainLength = terrain.terrainData.size [2];
		middleTerrainZ = terrainPosZ + terrainLength/2.0f;
		//Debug.Log (middleTerrainZ);
		lightPrefab = Resources.Load ("prefabs/environment/MusicalLight") as GameObject;
		createMusicalLights ();
	}
	
	
	/**
	 * Update is called once per frame
	 */
	void Update () {
		Hero hero = GameModel.HerosInGame [0];

		if (!terrainCreated) {

			if (hero.GetPosition().z > middleTerrainZ) {

				//Debug.Log ("#### MIDDLE #### " + middleTerrainZ);
				Instantiate(Resources.Load("prefabs/Terrain") as GameObject, new Vector3 (-100, -2, terrainPosZ + terrainLength), Quaternion.identity);
				terrainCreated = true;
			}
		}else if (hero.GetPosition().z > terrainPosZ + terrainLength){
			Destroy(this.gameObject);
		}
	}

	void createMusicalLights (){
		float randomX,randomZ;
		Vector3 randomPos;
		for(int i=0; i<50; i++){
			randomX = Random.Range(-30.0f, 30.0f);
			randomZ = Random.Range(terrainPosZ, terrainPosZ + terrainLength);
			randomPos = new Vector3(randomX,0,randomZ);
			Instantiate (lightPrefab, new Vector3(randomX, terrain.SampleHeight(randomPos)+8, randomZ), Quaternion.identity);
		}
	}
}
