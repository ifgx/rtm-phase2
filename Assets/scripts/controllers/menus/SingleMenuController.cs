using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Leap;

public class SingleMenuController : MonoBehaviour {

	public GameObject go;

	Button buttonCampaign;
	Button buttonCustom;
	Button buttonTutorial;
	Button buttonReturn;
	Button buttonPlay;

	GameObject goCampaign;
	GameObject goCustom;
	GameObject goTutorial;

	public GameObject loadingCanvas;

	UnityEngine.UI.Image imageCampaign;
	UnityEngine.UI.Image imageCustom;
	UnityEngine.UI.Image imageTutorial;


	Sprite spriteNormal;
	Sprite spriteSelect;

	Text device;
	GameObject deviceInfo;

	Controller controllerLM;
	bool LM;

	bool campaign, custom, tutorial, cancel, play;

	// Use this for initialization
	void Start () {
		imageCampaign = go.transform.Find("StaticCanvas/Mode/Campaign").GetComponent<UnityEngine.UI.Image>();
		imageCustom = go.transform.Find("StaticCanvas/Mode/Custom").GetComponent<UnityEngine.UI.Image>();
		imageTutorial = go.transform.Find("StaticCanvas/Mode/Tutorial").GetComponent<UnityEngine.UI.Image>();

		buttonCampaign = go.transform.Find("StaticCanvas/Mode/Campaign").GetComponent<Button>();
		buttonCustom = go.transform.Find("StaticCanvas/Mode/Custom").GetComponent<Button>();
		buttonTutorial = go.transform.Find("StaticCanvas/Mode/Tutorial").GetComponent<Button>();
		buttonPlay = go.transform.Find("StaticCanvas/Play").GetComponent<Button>();
		buttonReturn = go.transform.Find("StaticCanvas/Return").GetComponent<Button>();

		goCampaign = GameObject.Find("CampaignGO");
		goCustom = GameObject.Find("CustomGO");
		goTutorial = GameObject.Find("TutorialGO");

		device = go.transform.Find("StaticCanvas/Device/LabelDevice").GetComponent<Text>();
		deviceInfo = GameObject.Find("StaticCanvas/Device/LabelDeviceInfo");
		deviceInfo.SetActive(false);

		spriteNormal = Resources.Load <Sprite> ("prefabs/menus/button_normal");
		spriteSelect = Resources.Load <Sprite> ("prefabs/menus/button_over");

		imageCampaign.sprite = spriteSelect;
		campaign = true;
		custom = false;
		tutorial = false;

	}
	
	// Update is called once per frame
	void Update () {

		goCampaign.SetActive(campaign);
		goCustom.SetActive(custom);
		goTutorial.SetActive(tutorial);

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


		if((campaign && (HeroMenuController.BSlot1 || HeroMenuController.BSlot2 || HeroMenuController.BSlot3) && HeroMenuController.Name != "") ||
			(custom && CustomMenuController.Song != "Empty") ||
			tutorial){
			buttonPlay.interactable = true;
		} else {
			buttonPlay.interactable = false;
		}

		//Debug.Log("Browser is on : "+CustomMenuController.LauncherBrowser);


		if(CustomMenuController.LauncherBrowser) {
			buttonCampaign.interactable = false;
			buttonCustom.interactable = false;
			buttonTutorial.interactable = false;
			buttonPlay.interactable = false;
			buttonReturn.interactable = false;
		} else {
			buttonCampaign.interactable = true;
			buttonCustom.interactable = true;
			buttonTutorial.interactable = true;
			buttonReturn.interactable = true;
		}
	}

	public void Campaign(){

		//buttonCampaign.
		imageCampaign.sprite = spriteSelect;
		imageCustom.sprite = spriteNormal;
		imageTutorial.sprite = spriteNormal;


		campaign = true;
		custom = false;
		tutorial = false;
	}

	public void Custom(){
		imageCampaign.sprite = spriteNormal;
		imageCustom.sprite = spriteSelect;
		imageTutorial.sprite = spriteNormal;

		campaign = false;
		custom = true;
		tutorial = false;
	}

	public void Tutorial(){
		imageCampaign.sprite = spriteNormal;
		imageCustom.sprite = spriteNormal;
		imageTutorial.sprite = spriteSelect;

		campaign = false;
		custom = false;
		tutorial = true;
	}

	public void Play(){

		loadingCanvas.SetActive(true);

		if (campaign) {
			GameModel.goToFirstLevel();
			GameModel.resetSaveSlot(HeroMenuController.Save);
			GameModel.Hero.Name = HeroMenuController.Name;
			GameModel.PlayWithLeap = LM;
			GameModel.PlayWithTuto = false;
			Application.LoadLevel("GameScene");
		} else if (custom) {
			GameModel.PlayWithLeap = LM;
			GameModel.PlayWithTuto = false;
			GameModel.goToFirstLevel();
			Application.LoadLevel("GameScene");
		} else if (tutorial) {
			Debug.Log("Tutorial activate");
			GameModel.PlayWithLeap = LM;
			GameModel.PlayWithTuto = true;
			GameModel.goToFirstLevel();
			Application.LoadLevel("TutoScene");
		}


	}

	public void Return(){
		MenuController.Animator.SetTrigger("singleToClass");
	}
}
