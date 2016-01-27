using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Leap;

public class MultiPlayerMenuController : MonoBehaviour {

	public GameObject go;
	public GameObject loadingCanvas;

	string userNamePlayer1;
	InputField inputNamePlayer1;
	Button buttonwarriorPlayer1;
	Button buttonwizardPlayer1;
	Button buttonmonkPlayer1;
	UnityEngine.UI.Image imageWarriorPlayer1;
	UnityEngine.UI.Image imageWizardPlayer1;
	UnityEngine.UI.Image imageMonkPlayer1;
	bool warriorPlayer1, wizardPlayer1, monkPlayer1;

	string userNamePlayer2;
	InputField inputNamePlayer2;
	Button buttonwarriorPlayer2;
	Button buttonwizardPlayer2;
	Button buttonmonkPlayer2;
	UnityEngine.UI.Image imageWarriorPlayer2;
	UnityEngine.UI.Image imageWizardPlayer2;
	UnityEngine.UI.Image imageMonkPlayer2;
	bool warriorPlayer2, wizardPlayer2, monkPlayer2;

	Sprite spriteNormal;
	Sprite spriteSelect;
	Button buttonPlay;
	RectTransform buttonPlayRectTransf;
	Controller controllerLM;
	bool LM;

	ColorBlock cb;
	//GameObject menu;
	//GameObject loading;

	// Use this for initialization
	void Start () {

		spriteNormal = Resources.Load <Sprite> ("prefabs/menus/button_sq_normal");
		spriteSelect = Resources.Load <Sprite> ("prefabs/menus/button_square_highlight");

		inputNamePlayer1 = go.transform.Find("MultiPlayerCanvas/Menu/Player1/Name/InputNamePlayer1").GetComponent<InputField>();
		inputNamePlayer1.text = "Player 1"; // default name
		userNamePlayer1 = "";

		inputNamePlayer2 = go.transform.Find("MultiPlayerCanvas/Menu/Player2/Name/InputNamePlayer2").GetComponent<InputField>();
		inputNamePlayer2.text = "Player 2"; // default name
		userNamePlayer2 = "";

		imageWarriorPlayer1 = go.transform.Find("MultiPlayerCanvas/Menu/Player1/Class/WarriorPlayer1").GetComponent<UnityEngine.UI.Image>();
		imageWizardPlayer1 = go.transform.Find("MultiPlayerCanvas/Menu/Player1/Class/WizardPlayer1").GetComponent<UnityEngine.UI.Image>();
		imageMonkPlayer1 = go.transform.Find("MultiPlayerCanvas/Menu/Player1/Class/MonkPlayer1").GetComponent<UnityEngine.UI.Image>();
		imageWarriorPlayer1.sprite = spriteSelect;

		buttonwarriorPlayer1 = go.transform.Find("MultiPlayerCanvas/Menu/Player1/Class/WarriorPlayer1").GetComponent<Button>();
		buttonwizardPlayer1 = go.transform.Find("MultiPlayerCanvas/Menu/Player1/Class/WizardPlayer1").GetComponent<Button>();
		buttonmonkPlayer1 = go.transform.Find("MultiPlayerCanvas/Menu/Player1/Class/MonkPlayer1").GetComponent<Button>();
		warriorPlayer1 = true; // default class
		wizardPlayer1 = false;
		monkPlayer1 = false;

		imageWarriorPlayer2 = go.transform.Find("MultiPlayerCanvas/Menu/Player2/Class/WarriorPlayer2").GetComponent<UnityEngine.UI.Image>();
		imageWizardPlayer2 = go.transform.Find("MultiPlayerCanvas/Menu/Player2/Class/WizardPlayer2").GetComponent<UnityEngine.UI.Image>();
		imageMonkPlayer2 = go.transform.Find("MultiPlayerCanvas/Menu/Player2/Class/MonkPlayer2").GetComponent<UnityEngine.UI.Image>();
		imageWarriorPlayer2.sprite = spriteSelect;

		buttonwarriorPlayer2 = go.transform.Find("MultiPlayerCanvas/Menu/Player2/Class/WarriorPlayer2").GetComponent<Button>();
		buttonwizardPlayer2 = go.transform.Find("MultiPlayerCanvas/Menu/Player2/Class/WizardPlayer2").GetComponent<Button>();
		buttonmonkPlayer2 = go.transform.Find("MultiPlayerCanvas/Menu/Player2/Class/MonkPlayer2").GetComponent<Button>();
		warriorPlayer2 = true; // default class
		wizardPlayer2 = false;
		monkPlayer2 = false;

		buttonPlay = go.transform.Find("MultiPlayerCanvas/Menu/Play").GetComponent<Button>();
		buttonPlayRectTransf = go.transform.Find("MultiPlayerCanvas/Menu/Play").GetComponent<RectTransform>();
		buttonPlay.interactable = false;
		
		/*menu = GameObject.Find("Menu");
		menu.SetActive(true);
		loading = GameObject.Find("Loading");
		loading.SetActive(false);*/
		
	}
	
	// Update is called once per frame
	void Update () {

		controllerLM = new Controller();
		if(controllerLM != null && !controllerLM.IsConnected){
			LM = false;
			buttonPlayRectTransf.sizeDelta = new Vector2(240,30);
			buttonPlay.GetComponentInChildren<Text>().text = "Play (LM not detected)";
		} else {
			LM = true;
			buttonPlayRectTransf.sizeDelta = new Vector2(70,30);
			buttonPlay.GetComponentInChildren<Text>().text = "Play";
		}

		userNamePlayer1 = inputNamePlayer1.text;
		userNamePlayer2 = inputNamePlayer2.text;
		
		if(LM && (((warriorPlayer1||wizardPlayer1||monkPlayer1) == true) && userNamePlayer1 != "")
			&& (((warriorPlayer2||wizardPlayer2||monkPlayer2) == true) && userNamePlayer2 != "")){
			buttonPlay.interactable = true;
		} else buttonPlay.interactable = false;

	}

	public void WarriorPlayer1(){
		imageWarriorPlayer1.sprite = spriteSelect;
		warriorPlayer1 = true;

		imageWizardPlayer1.sprite = spriteNormal;
		imageMonkPlayer1.sprite = spriteNormal;
		wizardPlayer1 = false;
		monkPlayer1 = false;
	}

	public void WizardPlayer1() {
		imageWizardPlayer1.sprite = spriteSelect;
		wizardPlayer1 = true;

		imageWarriorPlayer1.sprite = spriteNormal;
		imageMonkPlayer1.sprite = spriteNormal;
		warriorPlayer1 = false;
		monkPlayer1 = false;
	}

	public void MonkPlayer1() {
		imageMonkPlayer1.sprite = spriteSelect;
		monkPlayer1 = true;

		imageWarriorPlayer1.sprite = spriteNormal;
		imageWizardPlayer1.sprite = spriteNormal;
		warriorPlayer1 = false;
		wizardPlayer1 = false;
	}

	public void WarriorPlayer2(){
		imageWarriorPlayer2.sprite = spriteSelect;
		warriorPlayer2 = true;
		
		imageWizardPlayer2.sprite = spriteNormal;
		imageMonkPlayer2.sprite = spriteNormal;
		wizardPlayer2 = false;
		monkPlayer2 = false;
	}
	
	public void WizardPlayer2() {
		imageWizardPlayer2.sprite = spriteSelect;
		wizardPlayer2 = true;
		
		imageWarriorPlayer2.sprite = spriteNormal;
		imageMonkPlayer2.sprite = spriteNormal;
		warriorPlayer2 = false;
		monkPlayer2 = false;
	}
	
	public void MonkPlayer2() {
		imageMonkPlayer2.sprite = spriteSelect;
		monkPlayer2 = true;
		
		imageWizardPlayer2.sprite = spriteNormal;
		imageWarriorPlayer2.sprite = spriteNormal;
		warriorPlayer2 = false;
		wizardPlayer2 = false;
	}
	
	public void Play(){
		//menu.SetActive(false);
		//loading.SetActive(true);

		loadingCanvas.SetActive(true);

		Hero hero1 = null;
		if (warriorPlayer1) hero1 = new Warrior();
		if (monkPlayer1) hero1 = new Monk();
		if (wizardPlayer1) hero1 = new Wizard();

		hero1.Name = userNamePlayer1;

		GameModel.Heros.Add (hero1);


		Hero hero2 = null;
		if (warriorPlayer2) hero2 = new Warrior();
		if (monkPlayer2) hero2 = new Monk();
		if (wizardPlayer2) hero2 = new Wizard();
		
		hero2.Name = userNamePlayer2;
		
		GameModel.Heros.Add (hero2);

		GameModel.PlayWithTuto = false;
		GameModel.goToFirstLevel();


		Application.LoadLevel("GameScene");
	}
	
	public void Return() {
		MenuController.Animator.SetTrigger("multiToMain");
	}
}
