using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Leap;

public class HeroMenuController : MonoBehaviour {

	Controller controllerLM;
	bool LM;
	string userName;
	InputField inputName;
	Text device;
	GameObject deviceInfo;
	Button buttonPlay;
	Button buttonWarrior;
	Button buttonWizard;
	Button buttonMonk;
	bool warrior, wizard, monk;
	Button buttonSlot1;
	Button buttonSlot2;
	Button buttonSlot3;
	bool slot1, slot2, slot3;
	int save;
	ColorBlock cb;
	GameObject menu;
	GameObject loading;

	// Use this for initialization
	void Start () {

		inputName = GameObject.Find("InputName").GetComponent<InputField>();
		inputName.text = "Player 1"; // default name
		userName = "";

		device = GameObject.Find("LabelDevice").GetComponent<Text>();
		deviceInfo = GameObject.Find("LabelDeviceInfo");
		deviceInfo.SetActive(false);

		buttonPlay = GameObject.Find("Play").GetComponent<Button>();
		buttonPlay.interactable = false;

		buttonWarrior = GameObject.Find("Warrior").GetComponent<Button>();
		buttonWizard = GameObject.Find("Wizard").GetComponent<Button>();
		buttonMonk = GameObject.Find("Monk").GetComponent<Button>();
		cb = buttonWarrior.colors;
		cb.normalColor = new Color32(163, 124, 124, 255);
		buttonWarrior.colors = cb;
		warrior = true; // default class
		wizard = false;
		monk = false;

		buttonSlot1 = GameObject.Find("Slot1").GetComponent<Button>();
		buttonSlot2 = GameObject.Find("Slot2").GetComponent<Button>();
		buttonSlot3 = GameObject.Find("Slot3").GetComponent<Button>();
		cb.normalColor = new Color32(163, 124, 124, 255);
		buttonSlot1.colors = cb;
		slot1 = true; // default save slot
		slot2 = false;
		slot3 = false;
		
		menu = GameObject.Find("Menu");
		menu.SetActive(true);
		loading = GameObject.Find("Loading");
		loading.SetActive(false);
		
	}
	
	// Update is called once per frame
	void Update () {
		
		userName = inputName.text;
		
		if(((warrior||wizard||monk) == true) && ((slot1||slot2||slot3) == true) && userName != ""){
			buttonPlay.interactable = true;
		} else buttonPlay.interactable = false;
		
		//If leap is not connected
		controllerLM = new Controller();
		if(controllerLM != null && controllerLM.IsConnected){
			device.text = "Leap Motion";
			deviceInfo.SetActive(false);
			LM = true;
		} else {
			device.text = "Keyboard + Mouse";
			deviceInfo.SetActive(true);
			LM = false;
		}
	}
	
	public void Warrior(){
		cb.normalColor = new Color32(163, 124, 124, 255);
		buttonWarrior.colors = cb;
		warrior = true;
		
		cb.normalColor = Color.white;
		buttonWizard.colors = cb;
		buttonMonk.colors = cb;
		wizard = false;
		monk = false;
		
	}
	
	public void Wizard() {
		cb.normalColor = new Color32(163, 124, 124, 255);
		buttonWizard.colors = cb;
		wizard = true;
		
		cb.normalColor = Color.white;
		buttonWarrior.colors = cb;
		buttonMonk.colors = cb;
		warrior = false;
		monk = false;
	}
	
	public void Monk() {
		cb.normalColor = new Color32(163, 124, 124, 255);
		buttonMonk.colors = cb;
		monk = true;
		
		cb.normalColor = Color.white;
		buttonWarrior.colors = cb;
		buttonWizard.colors = cb;
		warrior = false;
		wizard = false;
		
	}
	
	public void Slot1() {
		cb.normalColor = new Color32(163, 124, 124, 255);
		buttonSlot1.colors = cb;
		slot1 = true;
		
		cb.normalColor = Color.white;
		buttonSlot2.colors = cb;
		buttonSlot3.colors = cb;
		slot2 = false;
		slot3 = false;
		
		save = 0;
	}
	
	public void Slot2() {
		cb.normalColor = new Color32(163, 124, 124, 255);
		buttonSlot2.colors = cb;
		slot2 = true;
		
		cb.normalColor = Color.white;
		buttonSlot1.colors = cb;
		buttonSlot3.colors = cb;
		slot1 = false;
		slot3 = false;
		
		save = 1;
	}
	
	public void Slot3() {
		cb.normalColor = new Color32(163, 124, 124, 255);
		buttonSlot3.colors = cb;
		slot3 = true;
		
		cb.normalColor = Color.white;
		buttonSlot1.colors = cb;
		buttonSlot2.colors = cb;
		slot1 = false;
		slot2 = false;
		
		save = 2;
	}
	
	public void Play(){
		menu.SetActive(false);
		loading.SetActive(true);
		
		if (warrior) GameModel.Hero = new Warrior();
		if (monk) GameModel.Hero = new Monk();
		if (wizard) GameModel.Hero = new Wizard();

		Debug.LogError("HERO INIT:"+GameModel.Hero.XpQuantity);
		
		GameModel.Hero.Name = userName;
		GameModel.PlayWithLeap = LM;
		GameModel.PlayWithTuto = false;
		GameModel.resetSaveSlot(save);
		GameModel.goToFirstLevel();
		Application.LoadLevel("GameScene");
	}

	public void Tutorial(){
		menu.SetActive(false);
		loading.SetActive(true);

		if (warrior) GameModel.Hero = new Warrior();
		if (monk) GameModel.Hero = new Monk();
		if (wizard) GameModel.Hero = new Wizard();

		GameModel.Hero.Name = userName;
		GameModel.PlayWithLeap = LM;
		GameModel.PlayWithTuto = true;
		GameModel.goToFirstLevel();
		Application.LoadLevel("GameScene");
	}
	
	public void Return() {
		Application.LoadLevel("Main_menu");
	}
}
