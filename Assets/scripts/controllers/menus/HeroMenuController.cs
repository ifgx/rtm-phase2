using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Leap;

public class HeroMenuController : MonoBehaviour {

	public GameObject go;

	private static string userName;
	InputField inputName;

	Sprite spriteNormal;
	Sprite spriteSelect;

	UnityEngine.UI.Image imageSlot1;
	UnityEngine.UI.Image imageSlot2;
	UnityEngine.UI.Image imageSlot3;

	Button buttonSlot1;
	Button buttonSlot2;
	Button buttonSlot3;
	bool slot1, slot2, slot3;

	private static int save;

	//GameObject loading;

	// Use this for initialization
	void Start () {

		inputName = go.transform.Find("CampaignGO/CampaignCanvas/Name/InputName").GetComponent<InputField>();
		inputName.text = "Player 1"; // default name
		userName = "";

		buttonSlot1 = go.transform.Find("CampaignGO/CampaignCanvas/SaveSlots/Slot1").GetComponent<Button>();
		buttonSlot2 = go.transform.Find("CampaignGO/CampaignCanvas/SaveSlots/Slot2").GetComponent<Button>();
		buttonSlot3 = go.transform.Find("CampaignGO/CampaignCanvas/SaveSlots/Slot3").GetComponent<Button>();

		imageSlot1 = go.transform.Find("CampaignGO/CampaignCanvas/SaveSlots/Slot1").GetComponent<UnityEngine.UI.Image>();
		imageSlot2 = go.transform.Find("CampaignGO/CampaignCanvas/SaveSlots/Slot2").GetComponent<UnityEngine.UI.Image>();
		imageSlot3 = go.transform.Find("CampaignGO/CampaignCanvas/SaveSlots/Slot3").GetComponent<UnityEngine.UI.Image>();

		spriteNormal = Resources.Load <Sprite> ("prefabs/menus/button_sq_normal");
		spriteSelect = Resources.Load <Sprite> ("prefabs/menus/button_square_highlight");

		imageSlot1.sprite = spriteSelect;
		slot1 = true; // default save slot
		slot2 = false;
		slot3 = false;
		save = 0;
		
		/*loading = GameObject.Find("Loading");
		loading.SetActive(false);*/
		
	}
	
	// Update is called once per frame
	void Update () {
		
		userName = inputName.text;

	}

	public void Slot1() {

		imageSlot1.sprite = spriteSelect;
		slot1 = true;
		
		imageSlot2.sprite = spriteNormal;
		imageSlot3.sprite = spriteNormal;
		slot2 = false;
		slot3 = false;
		
		save = 0;
	}
	
	public void Slot2() {
		imageSlot2.sprite = spriteSelect;
		slot2 = true;
		
		imageSlot1.sprite = spriteNormal;
		imageSlot3.sprite = spriteNormal;
		slot1 = false;
		slot3 = false;
		
		save = 1;
	}
	
	public void Slot3() {
		imageSlot3.sprite = spriteSelect;
		slot3 = true;
		
		imageSlot1.sprite = spriteNormal;
		imageSlot2.sprite = spriteNormal;
		slot1 = false;
		slot2 = false;
		
		save = 2;
	}
/*<<<<<<< HEAD
	
	public void Play(){
		menu.SetActive(false);
		loading.SetActive(true);
		
		if (warrior) GameModel.Hero = new Warrior();
		if (monk) GameModel.Hero = new Monk();
		if (wizard) GameModel.Hero = new Wizard();

		//Debug.LogError("HERO INIT:"+GameModel.Hero.XpQuantity);
		
		GameModel.Hero.Name = userName;
		GameModel.PlayWithLeap = LM;
		GameModel.resetSaveSlot(save);
		GameModel.PlayWithTuto = false;
		GameModel.goToFirstLevel();
		Application.LoadLevel("GameScene");
	}

	public void Tutorial(){
		menu.SetActive(false);
		loading.SetActive(true);
=======
>>>>>>> 2cac1a97d5849c9bc9b578ae6ee735bb7482aae6*/

	public static string Name {
		get {
			return userName;
		}

		set {
			userName = value;
		}
	}

	public static int Save {
		get {
			return save;
		}

		set {
			save = value;
		}
	}
}
