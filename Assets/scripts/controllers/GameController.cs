using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine.UI;

/**
 * @author Adrien D
 * @version 1.0
 */

namespace Game {

	
	/**
	 * The strong hand for the player
	 */
	public enum HandSide {
		RIGHT_HAND,
		LEFT_HAND,
	};

/**
 * The controller for the Game Scene
 */
public class GameController : MonoBehaviour {

	/**
	 * The game state
	 */
	public enum GameState {
		PLAY,
		PAUSE,
		DEAD,
	};

		

	private Level level;
	/**
	 * Prefabs used in the game
	 */
	private GameObject terrain1;
	private GameObject terrain2;
	private GameObject terrain3;

	private GameObject hud;
	private GameObject deathHud;
	private HudMaster hudMaster;
	private HudMaster hudMaster2 = null;

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

	private GameObject lifePotion;
	private GameObject powerPotion;
	private GameObject invincibilityPotion;
		
	private GameObject leapPrefab;
	private GameObject leapInstance;
	private HandController leapControl;
	private GameObject leapCanvasPrefab;
	private GameObject leapCanvas;

	private GameObject kmManagerPrefab;
	private GameObject kmManager;

	private AudioManager audioManager;
	
	private Hero hero;
	private GameObject heroGameObject;
	private Terrain ter;

	private GameState state;
	private bool pauseFlag = false;
	private GameObject pausedMenu;

	private HandSide handSide;


		private AudioClip soundClosing;


	private float tempsMusique = 240f;

	private float multiplayerHerosOffset = 1.7f;

	private List<GameObject> npcList;

	/**
	 * Timers
	 */

	private float timerEnd = 0.0f;
	private float maxTimerEnd = 3.0f;

	private float timerGeste = 0.0f;
	private float maxTimerGesteAttaque = 1.0f;
	private float maxTimerGesteDefense = 2.0f;
	private LeapControl.ActionState lastState;
	private bool actionDone = false;

	private bool bloque = false;

	private bool deathDone = false;


	/**
	 * During the awakening : we load all the prefabs
	 */
	void Awake(){
		//Debug.Log ("START Awake GameController");

		terrain1 = Resources.Load ("prefabs/Terrain1") as GameObject;
		terrain2 = Resources.Load ("prefabs/Terrain2") as GameObject;
		terrain3 = Resources.Load ("prefabs/Terrain3") as GameObject;

		hud = Resources.Load ("prefabs/hud/hudPrefab") as GameObject;
		deathHud = Resources.Load("prefabs/hud/DeathHud") as GameObject;
		
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

		lifePotion = Resources.Load("prefabs/item/LifePotion") as GameObject;
		powerPotion = Resources.Load("prefabs/item/powerPotion") as GameObject;
		invincibilityPotion = Resources.Load("prefabs/item/InvincibilityPotion") as GameObject;
			
		leapPrefab = Resources.Load("prefabs/leapmotion/LeapMotionScene") as GameObject;
		leapCanvasPrefab = Resources.Load("prefabs/leapmotion/LeapCanvas") as GameObject;

		kmManagerPrefab = Resources.Load ("prefabs/keyboard/KMManager") as GameObject;

		//Debug.Log (" END Awake GameController");
		soundClosing = Resources.Load("sounds/pop-up-close") as AudioClip;

	}

	/**
	 * Initialisation of the game
	 * Generation of the scene from the level file
	 */
	void Start () {


		//GameModel.Init();
		GameModel.resetDataBeforeLevel ();
		
		if (!GameModel.PlayWithTuto && !GameModel.CustomLevel){
			GameModel.loadSave(GameModel.Slot);
		}
		level = GameModel.ActualLevel;
		//Debug.Log (level.Name+"  --  "+level.MusicPath);
		

		//Debug.Log (level.Name);
		//Debug.Log (level.Tutorial);
		//Debug.Log ("START Start GameController");


		//recupÃ©ration des options
		handSide = HandSide.RIGHT_HAND;

		//lire fichier niveau
		//LevelParser parser = new LevelParser (FILE_PATH);

		//gÃ©nÃ©ration du hÃ©ros

		
		
		if (GameModel.MultiplayerModeOn) {
			initMulti ();
		} else
		{
			initMono ();
			
		}
		
		float vitesseHeros = hero.MovementSpeed;
		


		//GÃ©nÃ©ration de terrain
		//float longueurTerrain = vitesseHeros * tempsMusique;

		/*ter = Instantiate( terrain, new Vector3(0,0,0), Quaternion.identity) as GameObject;
		ter.transform.Rotate (0, -90, 0);
		ter.transform.localScale = new Vector3 (longueurTerrain, 1, 1);
		*/
		//Debug.Log("LEVEL NAME :"+GameModel.ActualLevel.Map+"|");
		switch(GameModel.ActualLevel.Map){
			case "terrain1":
				ter = Instantiate (terrain1, new Vector3 (-100, -2, 0), Quaternion.identity) as Terrain;
				break;
			case "terrain2":
				//Debug.Log("LEVEL NAME :"+GameModel.ActualLevel.Map+"|");
				ter = Instantiate (terrain2, new Vector3 (-100, -2, 0), Quaternion.identity) as Terrain;
				break;
			case "terrain3":
				ter = Instantiate (terrain3, new Vector3 (-100, -2, 0), Quaternion.identity) as Terrain;
				break;
			default:
				//ter = Instantiate (terrain1, new Vector3 (-100, -2, 0), Quaternion.identity) as Terrain;
				break;
			}
		
		//ter.terrainData.size = new Vector3 (1.0f, 1.0f, 1.0f);
		//ter.terrainData.size = new Vector3 (200, 200, 1);



		//gÃ©nÃ©ration des ennemis
		npcList = new List<GameObject> ();
		//Debug.Log (npcList);

		//List<Thing> ennemies = parser.getEnnemies ();
		List<Item> items = level.ItemList;
		//Debug.Log ("FINAL ITEM LIST COUNT : " + items.Count);

		foreach (Item item in items) {
			GameObject go = null;

			if (item.Type == "basicLancer")
				go = basicLancer;
			else if (item.Type == "fireLancer")
				go = fireLancer;
			else if (item.Type == "iceLancer")
				go = iceLancer;
			else if (item.Type == "basicDragonet")
				go = basicDragonet;
			else if (item.Type == "fireDragonet")
				go = fireDragonet;
			else if (item.Type == "iceDragonet")
				go = iceDragonet;
			else if (item.Type == "wall")
				go = wall;
			else if (item.Type == "cannon")
				go = canon;
			else if (item.Type == "assassin")
				go = assassin;
			else if (item.Type == "life")
				go = lifePotion;
			else if (item.Type == "power")
				go = powerPotion;
			else if (item.Type == "invincibility")
				go = invincibilityPotion;

			if (go != null){

				float posX = 0f;
				if (!GameModel.MultiplayerModeOn){
					posX = item.PositionInX;
				}else {
					
					// a gauche ou a droite
					if (item.Type.Contains("Lancer") || item.Type == "assassin" || item.Type == "life" || item.Type == "power" || item.Type == "invincibility") {
						float sign = Mathf.Sign(Random.Range(-1f,1f));
						
						posX = item.PositionInX/2f+sign*2f;
					}else if (item.Type.Contains("Dragonet")){
						posX = item.PositionInX/2f-2f;
						GameObject instancep = Instantiate(go, new Vector3(posX, go.transform.localScale.y/2, vitesseHeros*item.PositionInSeconds), Quaternion.identity) as GameObject;
						NPC npcp = instancep.GetComponent<NPC>();
						GameModel.NPCsInGame.Add(npcp);
						
						posX = item.PositionInX/2f+2f;
					} else {
						posX = item.PositionInX;
					}
				}
				GameObject instance = Instantiate(go, new Vector3(posX, go.transform.localScale.y/2, vitesseHeros*item.PositionInSeconds), Quaternion.identity) as GameObject;
				NPC npc = instance.GetComponent<NPC>();
				Potion potion = instance.GetComponent<Potion>();
				
				if (npc != null)
					GameModel.NPCsInGame.Add(npc);
				if(potion != null) {
					GameModel.PotionsInGame.Add(potion);
				}
				//GameModel.NPCsInGame[GameModel.NPCsInGame.Count-1].transform.Rotate(0, 180, 0);
			}
		}

		
		//Debug.Log ("hudMaster : " + hudMaster);
		
		/*if (state == null)
		{
			//if state has not manually been set to pause, then its play*/
			state = GameState.PLAY;
		//}


		pausedMenu = GameObject.Find("PauseCanvas");
		pausedMenu.SetActive(false);

		deathHud = GameObject.Find ("DeathCanvas");
		deathHud.SetActive (false);

		Time.timeScale = 1.0f;

        audioManager = GameObject.Find("Main Camera").GetComponent<AudioManager>();

            audioManager.SetMusicName (level.MusicPath);
		audioManager.Init ();
		
		GameObject MushGO = Resources.Load("prefabs/environment/DiscoMushroom1") as GameObject;
		Instantiate (MushGO);
		

		//If leap is not connected, Pause game and show warning message
		if (GameModel.PlayWithLeap && !leapControl.IsConnected())
		{
			//pause()
			audioManager.Pause();
			Time.timeScale = 0.0f;
			GameObject detectedCanvas = GameObject.Find("DetectedLeapCanvas");
			detectedCanvas.GetComponent<Canvas>().enabled = true;
		}

		//Debug.Log ("END Start GameController");
		

		//ADD TUTORIAL MANAGER

		if (level.Tutorial) {
			//Debug.Log("ZBRA");
			GameObject tutoGO = Resources.Load("prefabs/controllers/TutorialManager") as GameObject;
		 	Instantiate (tutoGO);
		}

		Cursor.visible = false;
		
	}

	void initMono() 
	{
			//instanciate a hero using the class contained in the model
			Hero modelHero = GameModel.Hero;
			string heroClass = modelHero.GetType().ToString ();
			
			if (heroClass == "Warrior")
				heroGameObject = Instantiate (warrior);
			else if (heroClass == "Monk")
				heroGameObject = Instantiate (monk);
			else if (heroClass == "Wizard")
				heroGameObject = Instantiate (wizard);
			else
				heroGameObject = Instantiate (warrior);

			//Debug.Log (heroGameObject);
			GameModel.HerosInGame.Add (heroGameObject.GetComponent<Hero> ());
			hero = GameModel.HerosInGame [0];

			hero.XpQuantity = modelHero.XpQuantity;

			if (GameModel.PlayWithLeap) {
				//LEAP
				leapInstance = Instantiate (leapPrefab);
				//Debug.Log ("leapInstance : " + leapInstance);
				//the leap motion scene is child of camera so it follow the translation
				leapInstance.transform.parent = Camera.allCameras[0].transform;
				leapInstance.transform.position = new Vector3 (0f, 2.5f, 1.6f);
				//sets the "hand parent" field so the arms also are child of camera and don't flicker
				leapControl = leapInstance.GetComponent<HandController> ();
				leapControl.setModel(handSide, hero);
				leapControl.setGameController(this);
				
				leapControl.handParent = Camera.allCameras[0].transform;
				
				leapCanvas = Instantiate(leapCanvasPrefab);
			}else{
			
				kmManager = Instantiate (kmManagerPrefab);
				
				KMManager keyboardManager = kmManager.GetComponent<KMManager> ();
				keyboardManager.setHero (GameModel.HerosInGame [0]);
				keyboardManager.setCamera (Camera.main);
			}


			Camera.main.transform.parent = heroGameObject.transform;
			Camera.main.transform.position = new Vector3 (0, 2.18f, 0);
			GameObject MainCamera = GameObject.Find("Main Camera");
			hero.HeroCamera = MainCamera;
			//Camera.main.transform.Translate(new Vector3(0, 2.18f, 0));


			//GÃ©nÃ©ration du HUD
			hudMaster = Instantiate (hud).GetComponent<HudMaster>();
			hudMaster.setHero (GameModel.HerosInGame [0]);
			hudMaster.setRenderCamera (Camera.allCameras [0]);
	}

	void initMulti() {

			int i = 0;
			foreach (Hero modelHero in GameModel.Heros) {
				//instanciate a hero using the class contained in the model

				string heroClass = modelHero.GetType ().ToString ();
				
				if (heroClass == "Warrior")
					heroGameObject = Instantiate (warrior);
				else if (heroClass == "Monk")
					heroGameObject = Instantiate (monk);
				else if (heroClass == "Wizard")
					heroGameObject = Instantiate (wizard);
				else
					heroGameObject = Instantiate (warrior);

				heroGameObject.transform.Translate(new Vector3(-multiplayerHerosOffset+i*2*multiplayerHerosOffset,0,0));
				BoxCollider collider = heroGameObject.GetComponent<BoxCollider>();
				Vector3 v3 = collider.size;
				v3.x = 2*multiplayerHerosOffset;
				collider.size = v3;
				//Debug.Log (heroGameObject);
				GameModel.HerosInGame.Add (heroGameObject.GetComponent<Hero> ());
				GameModel.HerosInGame [i].XpQuantity = modelHero.XpQuantity;

				i++;
			}

			hero = GameModel.HerosInGame [0];

			GameObject camL = GameObject.Find ("CameraL");
			//LEAP
			leapInstance = Instantiate (leapPrefab);
			//Debug.Log ("leapInstance : " + leapInstance);
			//the leap motion scene is child of camera so it follow the translation
			leapInstance.transform.parent = camL.transform;
			leapInstance.transform.position = new Vector3 (0f, 2.5f, 1.6f);
			//sets the "hand parent" field so the arms also are child of camera and don't flicker
			leapControl = leapInstance.GetComponent<HandController> ();
			leapControl.setModel(handSide, GameModel.HerosInGame [0]);
			leapControl.setGameController(this);
			
			leapControl.handParent = camL.transform;
			
			leapCanvas = Instantiate(leapCanvasPrefab);
			
			
			
			camL.transform.parent = GameModel.HerosInGame [0].transform;
			camL.transform.position = new Vector3 (GameModel.HerosInGame [0].transform.position.x, 2.18f, 0);
			camL.GetComponent<Camera> ().enabled = true;
			//Camera.main.transform.Translate(new Vector3(0, 2.18f, 0));
			GameModel.HerosInGame[0].HeroCamera = camL;


			//instancier clavier
			GameObject camR = GameObject.Find ("CameraR");

			kmManager = Instantiate (kmManagerPrefab);

			KMManager keyboardManager = kmManager.GetComponent<KMManager> ();
			keyboardManager.setHero (GameModel.HerosInGame [1]);
			keyboardManager.setCamera (camR.GetComponent<Camera> ());

			camR.transform.parent = GameModel.HerosInGame [1].transform;
			camR.transform.position = new Vector3 (GameModel.HerosInGame [1].transform.position.x, 2.18f, 0);
			camR.GetComponent<Camera> ().enabled = true;
			GameModel.HerosInGame [1].HeroCamera = camR;

			Camera.main.enabled = false;

			//GÃ©nÃ©ration du HUD
			hudMaster = Instantiate (hud).GetComponent<HudMaster> ();
			hudMaster.setHero (GameModel.HerosInGame [0]);
			hudMaster.setRenderCamera (camL.GetComponent<Camera> ());

			hudMaster2 = Instantiate (hud).GetComponent<HudMaster> ();
			hudMaster2.setHero (GameModel.HerosInGame [1]);
			hudMaster2.setRenderCamera (camR.GetComponent<Camera> ());
	}
	
	/**
	 * The game loop
	 * Decides what should be done in function of the game state
	 */
	void Update () {

		switch (state) {
		case GameState.PLAY:
			play ();
			break;
		case GameState.PAUSE:
			pause();
			break;
		case GameState.DEAD:
			dead ();
			break;
		default:
			
			//disable by BV to allow gamelaunching via unity editor
			//Cursor.visible = false;
			//play ();

			break;
		}
	}

	/**
	 * Function called when the game state is "play"
	 * Takes in count player actions on the leap
	 * Makes the AI react
	 * Updates the HUDs
	 */
	void play(){
		//Gestion hÃ©ros
		
		Hero hero = GameModel.HerosInGame [0];
		
		//update hud state
		float currentHealthPercent = 100.0f*hero.HealthPoint/hero.MaxHealthPoint;
		float currentPowerPercent = 100.0f*hero.PowerQuantity/hero.MaxPowerQuantity;
		//Debug.Log("Life: " + currentHealthPercent);
		
		hudMaster.setLevel (HudMaster.HudType.Life, currentHealthPercent);
		hudMaster.setLevel (HudMaster.HudType.Special, currentPowerPercent);
		hudMaster.updateXP (hero.XpQuantityToDisplay(), (int)hero.Level);

		if (hudMaster2 != null) {
			hero = GameModel.HerosInGame [1];
			
			//update hud state
			currentHealthPercent = 100.0f*hero.HealthPoint/hero.MaxHealthPoint;
			currentPowerPercent = 100.0f*hero.PowerQuantity/hero.MaxPowerQuantity;
			//Debug.Log("Life: " + currentHealthPercent);
			
			hudMaster2.setLevel (HudMaster.HudType.Life, currentHealthPercent);
			hudMaster2.setLevel (HudMaster.HudType.Special, currentPowerPercent);
			hudMaster2.updateXP (hero.XpQuantityToDisplay(), (int)hero.Level);
		}

		//Debug.Log (GameModel.NPCsInGame.Count);
		if (GameModel.NPCsInGame.Count == 0) {
//			Debug.Log (timerEnd);
			timerEnd += Time.deltaTime;
			if (timerEnd >= maxTimerEnd){
				NextLevel();
			}
		}

			if(GameModel.HerosInGame[0].HealthPoint <= 0 || (GameModel.MultiplayerModeOn && GameModel.HerosInGame[1].HealthPoint <= 0))
		{
			Time.timeScale = 0;
			//Debug.Log("you are dead");
			state = GameState.DEAD;
		}

		audioManager.Play();

		/*if (Input.GetKeyDown(KeyCode.R)){
			Restart();
		}else */
			if (!Input.GetKey (KeyCode.Escape) && !Input.GetKey (KeyCode.P)) {
				pauseFlag = false;
			}

			if (!pauseFlag && (Input.GetKey(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))){
			state = GameState.PAUSE;
			
			audioManager.Pause();
			Time.timeScale = 0.0f;
			pausedMenu.SetActive(true);
			Cursor.visible = true;

			pauseFlag = true;
		}
	}

	/**
	 * Function called when the game is paused
	 */
	public void pause(){
		if (!Input.GetKey (KeyCode.Escape) && !Input.GetKey (KeyCode.P)) {
			pauseFlag = false;
		}

		if (!pauseFlag && (Input.GetKey(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))){
			/*state = GameState.PLAY;
			Time.timeScale = 1.0f;
			pausedMenu.SetActive(false);
			Cursor.visible = false;
			
			pauseFlag = true;*/
				Resume ();
		}
	}

	/**
	 * Function called when the player is dead
	 */
	void dead(){
		if (!deathDone) {
			deathHud.SetActive(true);
			
			Text scoreTxt = deathHud.transform.Find("CanvasChild/Score").GetComponent<Text>();
			scoreTxt.text = "Score : "+GameModel.Score;
			HighScoreParser.addHighScore(GameModel.Hero.Name, GameModel.Score);
			deathDone = true;
			Cursor.visible = true;
		}
		
	}
		
	/**
	 * Restarts the level
	 * For test purposes
	 */
	public void Restart() {
		Cursor.visible = false;
		Application.LoadLevel ("GameScene");
	}

	/**
	 * Quits the game directly
	 */
	public void Quit() {
		//Debug.Log ("QUIT");
		Application.Quit ();
	}

	/**
	 * Return to the main menu scene
	 */
	public void ReturnToMainMenu() {
		Time.timeScale = 1.0f;
		Application.LoadLevel ("LoadingScene");
	}

	/**
	 * Instant exit game (normal unity termination)
	 */
		public void ExitGame() {
			Application.Quit();
		}


	/**
	 * Trigger the next level scene
	 */
	public void NextLevel(){
		GameModel.ActualLevelId++;
		if(GameModel.HerosInGame.Count < 2)
		{
			GameModel.Score += 1000;
			//Debug.LogError("To save:"+GameModel.HerosInGame[0].Name+" ,XP:"+GameModel.HerosInGame[0].XpQuantity);
			//Debug.LogError("SAVE:"+GameModel.HerosInGame[0].XpQuantity);
			SaveParser.addSave(GameModel.Slot, GameModel.HerosInGame[0], GameModel.Score, GameModel.ActualLevelId);			
		}
		bool nextLevelExists = GameModel.goToNextLevel();
		if (GameModel.PlayWithTuto && !nextLevelExists) {
			Application.LoadLevel ("Main_menu");
		}
		Application.LoadLevel ("NextLevelScene");
	}

	/**
	 * Resume the game scene
	 * for test purposes
	 */
	public void Resume()
	{
		
		(hudMaster.GetComponent<AudioSource>()).PlayOneShot(soundClosing);
		pausedMenu.SetActive(false);
		state = GameState.PLAY;
		Time.timeScale = 1.0f;
		Cursor.visible = false;
		pauseFlag = true;
		//leapControl.setPointerMode(false);
	}
	
}
}
