using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * @author Adrien D
 * @version 1.0
 */

/**
 * Controller used to manage tutorials screens
 */
public class TutorialManagerController : MonoBehaviour {

	/**
	 * Tutorial states
	 */
	public enum TutorialState {
		FREEZE,
		NORMAL,
	};

	/**
	 * The global list of tutorials
	 */
	public static List<Tutorial> tutorials;

	/**
	 * the time scale on FREEZE mode
	 */
	private float freezeTimeScale = 0;

	/**
	 * Max timers
	 */
	private float maxTimerFreeze = 3.0f;
	private float maxTimerNormal = 3.0f;

	/**
	 * Timers
	 */
	private float timerFreeze = 0.0f;
	private float timerNormal = 0.0f;

	/**
	 * Game Objects
	 */
	private GameObject tutoUIPrefab;
	private GameObject tutoUIInstance;


	private TutorialState state = TutorialState.NORMAL;

	// Use this for initialization
	/**
	 * Initialization
	 */
	void Start () {
		maxTimerFreeze *= freezeTimeScale;

		tutoUIPrefab = Resources.Load("prefabs/hud/BasicTutorial") as GameObject;

		tutorials = TutorialParser.parseTutorials();
		Debug.Log(tutorials.Count);


	}
	
	// Update is called once per frame
	/**
	 * Update according to the state
	 */
	void Update () {
		if (state == TutorialState.NORMAL)
			normal ();
		else if (state == TutorialState.FREEZE)
			freeze ();
	}

	/**
	 * The update method when we are on FREEZE mode
	 */
	private void freeze(){
//		timerFreeze += Time.deltaTime;
//		//Debug.Log (timerFreeze);
//		if (timerFreeze >= maxTimerFreeze) {
//			Destroy(tutoUIInstance);
//
//			state = TutorialState.NORMAL;
//			Time.timeScale = 1.0f;
//			timerFreeze = 0.0f;
//		}

		if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton (0)) {
			Destroy(tutoUIInstance);
			state = TutorialState.NORMAL;
			Time.timeScale = 1.0f;
		}
	}

	/**
	 * The update method when we are on NORMAL mode
	 */
	private void normal(){
		timerNormal += Time.deltaTime;


		foreach (Tutorial tuto in tutorials) {
			if (!tuto.Played && tuto.requestTrigger()) {
				launchFreeze(tuto.Title,tuto.ImagePath, tuto.Text, tuto.Attack);
				tuto.Played = true;
			}
		}

		
		
	}

	/**
	 * Launch the FREEZE mode, adding the tutorial on te screen
	 */
	private void launchFreeze(string title, string imagePath, string text, string attack) {
		tutoUIInstance = Instantiate(tutoUIPrefab) as GameObject;
		TutorialUIManager uiMan = tutoUIInstance.GetComponent<TutorialUIManager> ();
		uiMan.setTitle (title);
		uiMan.setAttack (attack);
		uiMan.setDescription (text);
		uiMan.setImage (imagePath);
		
		state = TutorialState.FREEZE;
		Time.timeScale = freezeTimeScale;
		timerNormal = 0.0f;
		

	}
	
	/**
	 * Reset time scale when destroyed to avoid errors
	 */
	void OnDestroy(){
		Time.timeScale = 1.0f;
	}
}
