using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MultiPlayerMenuController : MonoBehaviour {

	string userNamePlayer1;
	InputField inputNamePlayer1;
	Button buttonwarriorPlayer1;
	Button buttonwizardPlayer1;
	Button buttonmonkPlayer1;
	bool warriorPlayer1, wizardPlayer1, monkPlayer1;

	string userNamePlayer2;
	InputField inputNamePlayer2;
	Button buttonwarriorPlayer2;
	Button buttonwizardPlayer2;
	Button buttonmonkPlayer2;
	bool warriorPlayer2, wizardPlayer2, monkPlayer2;

	Button buttonPlay;
	ColorBlock cb;
	GameObject menu;
	GameObject loading;

	// Use this for initialization
	void Start () {

		inputNamePlayer1 = GameObject.Find("InputNamePlayer1").GetComponent<InputField>();
		inputNamePlayer1.text = "Player 1"; // default name
		userNamePlayer1 = "";

		inputNamePlayer2 = GameObject.Find("InputNamePlayer2").GetComponent<InputField>();
		inputNamePlayer2.text = "Player 2"; // default name
		userNamePlayer2 = "";

		buttonwarriorPlayer1 = GameObject.Find("WarriorPlayer1").GetComponent<Button>();
		buttonwizardPlayer1 = GameObject.Find("WizardPlayer1").GetComponent<Button>();
		buttonmonkPlayer1 = GameObject.Find("MonkPlayer1").GetComponent<Button>();
		cb = buttonwarriorPlayer1.colors;
		cb.normalColor = new Color32(163, 124, 124, 255);
		buttonwarriorPlayer1.colors = cb;
		warriorPlayer1 = true; // default class
		wizardPlayer1 = false;
		monkPlayer1 = false;

		buttonwarriorPlayer2 = GameObject.Find("WarriorPlayer2").GetComponent<Button>();
		buttonwizardPlayer2 = GameObject.Find("WizardPlayer2").GetComponent<Button>();
		buttonmonkPlayer2 = GameObject.Find("MonkPlayer2").GetComponent<Button>();
		buttonwarriorPlayer2.colors = cb;
		warriorPlayer2 = true; // default class
		wizardPlayer2 = false;
		monkPlayer2 = false;

		buttonPlay = GameObject.Find("Play").GetComponent<Button>();
		buttonPlay.interactable = false;
		
		menu = GameObject.Find("Menu");
		menu.SetActive(true);
		loading = GameObject.Find("Loading");
		loading.SetActive(false);
		
	}
	
	// Update is called once per frame
	void Update () {
		
		userNamePlayer1 = inputNamePlayer1.text;
		userNamePlayer2 = inputNamePlayer2.text;
		
		if((((warriorPlayer1||wizardPlayer1||monkPlayer1) == true) && userNamePlayer1 != "")
			&& (((warriorPlayer2||wizardPlayer2||monkPlayer2) == true) && userNamePlayer2 != "")){
			buttonPlay.interactable = true;
		} else buttonPlay.interactable = false;
	}

	public void WarriorPlayer1(){
		cb.normalColor = new Color32(163, 124, 124, 255);
		buttonwarriorPlayer1.colors = cb;
		warriorPlayer1 = true;

		cb.normalColor = Color.white;
		buttonwizardPlayer1.colors = cb;
		buttonmonkPlayer1.colors = cb;
		wizardPlayer1 = false;
		monkPlayer1 = false;
	}

	public void WizardPlayer1() {
		cb.normalColor = new Color32(163, 124, 124, 255);
		buttonwizardPlayer1.colors = cb;
		wizardPlayer1 = true;

		cb.normalColor = Color.white;
		buttonwarriorPlayer1.colors = cb;
		buttonmonkPlayer1.colors = cb;
		warriorPlayer1 = false;
		monkPlayer1 = false;
	}

	public void MonkPlayer1() {
		cb.normalColor = new Color32(163, 124, 124, 255);
		buttonmonkPlayer1.colors = cb;
		monkPlayer1 = true;

		cb.normalColor = Color.white;
		buttonwarriorPlayer1.colors = cb;
		buttonwizardPlayer1.colors = cb;
		warriorPlayer1 = false;
		wizardPlayer1 = false;
	}

	public void WarriorPlayer2(){
		cb.normalColor = new Color32(163, 124, 124, 255);
		buttonwarriorPlayer2.colors = cb;
		warriorPlayer2 = true;
		
		cb.normalColor = Color.white;
		buttonwizardPlayer2.colors = cb;
		buttonmonkPlayer2.colors = cb;
		wizardPlayer2 = false;
		monkPlayer2 = false;
	}
	
	public void WizardPlayer2() {
		cb.normalColor = new Color32(163, 124, 124, 255);
		buttonwizardPlayer2.colors = cb;
		wizardPlayer2 = true;
		
		cb.normalColor = Color.white;
		buttonwarriorPlayer2.colors = cb;
		buttonmonkPlayer2.colors = cb;
		warriorPlayer2 = false;
		monkPlayer2 = false;
	}
	
	public void MonkPlayer2() {
		cb.normalColor = new Color32(163, 124, 124, 255);
		buttonmonkPlayer2.colors = cb;
		monkPlayer2 = true;
		
		cb.normalColor = Color.white;
		buttonwarriorPlayer2.colors = cb;
		buttonwizardPlayer2.colors = cb;
		warriorPlayer2 = false;
		wizardPlayer2 = false;
	}
	
	public void Play(){
		menu.SetActive(false);
		loading.SetActive(true);

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


		Application.LoadLevel("GameScene");
	}
	
	public void Return() {
		Application.LoadLevel("Main_menu");
	}
}
