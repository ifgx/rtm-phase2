using UnityEngine;
using System.Collections;

public class CrashTestMain : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject kmManagerPrefab = Resources.Load ("prefabs/keyboard/KMManager") as GameObject;
		KMManager manager = Instantiate (kmManagerPrefab).GetComponent<KMManager>();

		manager.setHero (new Wizard ());
		manager.setCamera (Camera.allCameras [0]);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
