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
	private GameObject particlePrefab;
	private GameObject mushroomPrefab1;
	private GameObject mushroomPrefab2;
	private GameObject[] allLights;
	private GameObject[] allMushrooms;
	private GameObject[] allParticles;

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

		mushroomPrefab1 = Resources.Load ("prefabs/environment/DiscoMushroom1") as GameObject;
		mushroomPrefab2 = Resources.Load ("prefabs/environment/DiscoMushroom3") as GameObject;
		particlePrefab = Resources.Load ("prefabs/environment/MusicalParticle") as GameObject;
		createMusicalLights ();
		createMushrooms ();	
		createParticleLights ();
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
		allLights = new GameObject[50];
		for(int i=0; i<50; i++){
			randomX = Random.Range(-30.0f, 30.0f);
			randomZ = Random.Range(terrainPosZ, terrainPosZ + terrainLength);
			randomPos = new Vector3(randomX,0,randomZ);
			allLights[i] = Instantiate (lightPrefab, new Vector3(randomX, terrain.SampleHeight(randomPos)+8, randomZ), Quaternion.identity) as GameObject;
		}
	}
	void createParticleLights (){
		float randomX,randomZ,sign;
		Vector3 randomPos;
		allParticles = new GameObject[20];
		for(int i=0; i<20; i++){
			sign = Random.Range(-1.0f, 1.0f);
			randomX = Random.Range(Mathf.Sign(sign) * 3.0f, Mathf.Sign(sign) * 30.0f);
			randomZ = Random.Range(terrainPosZ, terrainPosZ + terrainLength);
			randomPos = new Vector3(randomX,0,randomZ);
			allParticles[i] = Instantiate (particlePrefab, new Vector3(randomX, terrain.SampleHeight(randomPos), randomZ), Quaternion.identity) as GameObject;
		}
	}

	void createMushrooms () {
		float randomX,randomZ;
		Vector3 randomPos;
		float sign;
		allMushrooms = new GameObject[50];
		for(int i=0; i<50; i++){
			sign = Random.Range(-1.0f,1.0f);
			randomX = Mathf.Sign(sign)*Random.Range(5.0f, 30.0f);
			randomZ = Random.Range(terrainPosZ, terrainPosZ + terrainLength);
			randomPos = new Vector3(randomX,0,randomZ);

			if (Random.Range(0,2) == 0) {
				allMushrooms[i] = Instantiate (mushroomPrefab1) as GameObject;
			}else{
				allMushrooms[i] = Instantiate (mushroomPrefab2) as GameObject;
			}
			allMushrooms[i].transform.position = new Vector3(randomX, terrain.SampleHeight(randomPos)-2.3f, randomZ);
		}
	}
}
