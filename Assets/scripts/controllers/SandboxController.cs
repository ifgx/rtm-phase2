﻿using UnityEngine;
using System.Collections;
using Game;
using Leap;

/**
 * @author Adrien D
 * @version 1.0
 */

/**
 * Controller of the sandbox
 */
public class SandboxController : MonoBehaviour {

	/**
	 * GameObjects
	 */
	private GameObject terrain;
	
	private GameObject hud;
	private HudMaster hudMaster;
	
	private GameObject basicLancer;
	private GameObject fireLancer;
	private GameObject iceLancer;
	
	private GameObject basicDragonet;
	private GameObject fireDragonet;
	private GameObject iceDragonet;
	
	private GameObject wall;
	private GameObject canon;
	private GameObject assassin;
	
	private GameObject warrior;
	private GameObject monk;
	private GameObject wizard;
	
	private GameObject leapPrefab;
	private GameObject leapInstance;
	private HandController leapControl;

	private GameObject kmManagerPrefab;
	private GameObject kmManager;
	
	private Hero hero;
	private GameObject heroGameObject;

	private bool paused;
	private GameObject pausedMenu;
	
	private HandSide handSide;

    private AudioManager audioManager;

    /**
	 * Load all resources
	 */
    void Awake(){
		terrain = Resources.Load ("prefabs/Terrain1") as GameObject;
		
		hud = Resources.Load ("prefabs/hud/hudPrefab") as GameObject;
		
		basicLancer = Resources.Load("prefabs/npc/BasicLancer") as GameObject;
		fireLancer = Resources.Load("prefabs/npc/FireLancer") as GameObject;
		iceLancer = Resources.Load("prefabs/npc/IceLancer") as GameObject;
		
		basicDragonet = Resources.Load("prefabs/npc/BasicDragonet") as GameObject;
		fireDragonet = Resources.Load("prefabs/npc/FireDragonet") as GameObject;
		iceDragonet = Resources.Load("prefabs/npc/IceDragonet") as GameObject;
		
		wall = Resources.Load("prefabs/npc/Wall") as GameObject;
		canon = Resources.Load("prefabs/npc/Cannon") as GameObject;
		assassin = Resources.Load("prefabs/npc/Assassin") as GameObject;
		
		warrior = Resources.Load("prefabs/hero/Warrior") as GameObject;
		monk = Resources.Load("prefabs/hero/Monk") as GameObject;
		wizard = Resources.Load("prefabs/hero/Wizard") as GameObject;
		
		leapPrefab = Resources.Load("prefabs/leapmotion/LeapMotionScene") as GameObject;

		kmManagerPrefab = Resources.Load ("prefabs/keyboard/KMManager") as GameObject;
	}

	// Use this for initialization
	/**
	 * Initialize all values
	 */
	void Start () {
		GameModel.initSandbox ();
		EnnemyConfigurator.Init();
		HeroConfigurator.Init();

		handSide = HandSide.RIGHT_HAND;

		createHero ("Warrior");

        audioManager = GameObject.Find("Main Camera").GetComponent<AudioManager>();
        audioManager.Init();

        

		Instantiate (terrain, new Vector3 (-100, -2, 0), Quaternion.identity);


	}
	
	// Update is called once per frame
	/**
	 * Main update loop
	 */
	void Update () {

		if (GameModel.HerosInGame.Count > 0) {
			Hero hero = GameModel.HerosInGame [0];

			//update hud state
			//Debug.Log ("H///" + hero.MaxHealthPoint);
			float currentHealthPercent = 100.0f * hero.HealthPoint / hero.MaxHealthPoint;
			float currentPowerPercent = 100.0f * hero.PowerQuantity / hero.MaxPowerQuantity;
			//Debug.Log("Life: " + currentHealthPercent);
		
			hudMaster.setLevel (HudMaster.HudType.Life, currentHealthPercent);
			hudMaster.setLevel (HudMaster.HudType.Special, currentPowerPercent);
			hudMaster.updateXP ((hero.XpQuantityToDisplay()), (int)hero.Level);

			if (Input.GetKeyDown (KeyCode.L)) {
				GameModel.HerosInGame [0].XpQuantity += 100.0f;
			}

			if (Input.GetKeyDown (KeyCode.V)) {
				//Debug.Log ("RETURN");
				GameModel.HerosInGame [0].HealthPoint = GameModel.HerosInGame [0].MaxHealthPoint;
				//Debug.Log (GameModel.HerosInGame[0].MaxHealthPoint);
			}
		}
	}

	/**
	 * Add an item (ennemy or potion) at a cartain distance in front of us
	 */
	public void popItem(string type){
		GameObject go = null;
		
		if (type == "basicLancer")
			go = basicLancer;
		else if (type == "fireLancer")
			go = fireLancer;
		else if (type == "iceLancer")
			go = iceLancer;
		else if (type == "basicDragonet")
			go = basicDragonet;
		else if (type == "fireDragonet")
			go = fireDragonet;
		else if (type == "iceDragonet")
			go = iceDragonet;
		else if (type == "wall")
			go = wall;
		else if (type == "cannon")
			go = canon;
		else if (type == "assassin")
			go = assassin;
		
		if (go != null){
			Hero hero = GameModel.HerosInGame[0];
			GameObject instance = Instantiate(go, new Vector3(0, go.transform.localScale.y/2, hero.GetPosition().z + hero.MovementSpeed * 10.0f), Quaternion.identity) as GameObject;
			GameModel.NPCsInGame.Add(instance.GetComponent<NPC>());
			//GameModel.NPCsInGame[GameModel.NPCsInGame.Count-1].transform.Rotate(0, 180, 0);
		}
	}

	/**
	 * Reset life bar at its max value
	 */
	public void resetLife() {
		GameModel.HerosInGame[0].HealthPoint = GameModel.HerosInGame[0].MaxHealthPoint;
	}

	/**
	 * Reset power bar at its max value
	 */
	public void resetPower() {
		GameModel.HerosInGame [0].PowerQuantity = GameModel.HerosInGame [0].MaxPowerQuantity;
	}

	/**
	 * Reset both life and power bar at its max value
	 */
	public void resetBoth() {
		resetLife ();
		resetPower ();
	}

	/**
	 * Resume timeScale
	 */
	public void Resume()
	{
		Time.timeScale = 1.0f;
	}

	public void popHero(string heroClass) {
		deleteHero ();
		createHero (heroClass);
	}

	public void createHero(string heroClass) {
		//GameObject heroGameObject = Instantiate (warrior);
		if (heroClass == "Warrior") heroGameObject = Instantiate (warrior);
		else if (heroClass == "Wizard") heroGameObject = Instantiate (wizard);
		else if (heroClass == "Monk") heroGameObject = Instantiate (monk);
		else heroGameObject = Instantiate (warrior);
		hero = heroGameObject.GetComponent<Hero> ();
		hero.HeroCamera = Camera.main.gameObject;
		GameModel.HerosInGame.Add (hero);
		//string heroClass = hero.GetType ().ToString ();
		//LEAP
		Controller controllerLM = new Controller();
		if (controllerLM != null && controllerLM.IsConnected) {
			leapInstance = Instantiate (leapPrefab);
			//Debug.Log ("leapInstance : " + leapInstance);
			//the leap motion scene is child of camera so it follow the translation
			leapInstance.transform.parent = Camera.main.transform;
			leapInstance.transform.position = new Vector3 (0f, 2.5f, 1.6f);
			//sets the "hand parent" field so the arms also are child of camera and don't flicker
			leapControl = leapInstance.GetComponent<HandController> ();
			leapControl.setModel (handSide, hero);
			leapControl.handParent = Camera.main.transform;

			//If leap is not connected, Pause game and show warning message
			if ( !leapControl.IsConnected())
			{
				//pause()
				Time.timeScale = 0.0f;
				
				GameObject detectedCanvas = GameObject.Find("DetectedLeapCanvas");
				detectedCanvas.GetComponent<Canvas>().enabled = true;
			}
		} else {
			kmManager = Instantiate (kmManagerPrefab);
			
			KMManager keyboardManager = kmManager.GetComponent<KMManager> ();
			keyboardManager.setHero (hero);
			keyboardManager.setCamera (Camera.main);
		}

		Camera.main.transform.parent = heroGameObject.transform;
		Camera.main.transform.position = new Vector3 (0, 2.18f, 0);

		//Génération du HUD
		hudMaster = Instantiate (hud).GetComponent<HudMaster>();
		hudMaster.setHero (hero);


	}

	public void deleteHero(){
		Camera.main.transform.parent = null;

		if (kmManager != null) {
			Destroy(kmManager);
			kmManager = null;
		}

		foreach (Transform child in Camera.main.transform) {
			GameObject.Destroy(child.gameObject);
		}

		Destroy (heroGameObject);
		Destroy (leapInstance);
		Destroy (leapControl);

		GameModel.HerosInGame.Clear ();

		Camera.main.transform.position = new Vector3 (0, 4, 0);

		Destroy (hudMaster.gameObject);
	}
}
