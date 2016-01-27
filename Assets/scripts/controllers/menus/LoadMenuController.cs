using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LoadMenuController : MonoBehaviour {

	public GameObject go;
	public GameObject loadingCanvas;

	Button buttonPlay;
	Button buttonSlot1;
	Button buttonSlot2;
	Button buttonSlot3;

	Image imageSlot1;
	Image imageSlot2;
	Image imageSlot3;

	Sprite spriteNormal;
	Sprite spriteSelect;

	List<Button> buttons;

	int save;

	bool slot1, slot2, slot3;

	// Use this for initialization
	void Start () {

		buttonPlay = go.transform.Find("Canvas/Panel/Play").GetComponent<Button>();

		buttonSlot1 = go.transform.Find("Canvas/Panel/Slot1/ButtonSlot1").GetComponent<Button>();
		buttonSlot2 = go.transform.Find("Canvas/Panel/Slot2/ButtonSlot2").GetComponent<Button>();
		buttonSlot3 = go.transform.Find("Canvas/Panel/Slot3/ButtonSlot3").GetComponent<Button>();

		imageSlot1 = go.transform.Find("Canvas/Panel/Slot1/ButtonSlot1").GetComponent<Image>();
		imageSlot2 = go.transform.Find("Canvas/Panel/Slot2/ButtonSlot2").GetComponent<Image>();
		imageSlot3 = go.transform.Find("Canvas/Panel/Slot3/ButtonSlot3").GetComponent<Image>();

		spriteNormal = Resources.Load <Sprite> ("prefabs/menus/button_sq_normal");
		spriteSelect = Resources.Load <Sprite> ("prefabs/menus/button_square_highlight");

		buttonPlay.interactable = false;
		buttonSlot1.interactable = false;
		buttonSlot2.interactable = false;
		buttonSlot3.interactable = false;

		slot1 = false;
		slot2 = false;
		slot3 = false;

		buttons  = new List<Button>();
		buttons.Add(buttonSlot1);
		buttons.Add(buttonSlot2);
		buttons.Add(buttonSlot3);

		checkSave();
	}
	
	// Update is called once per frame
	void Update () {
		if ((slot1 | slot2 | slot3) == true) {
			buttonPlay.interactable = true;
		} else {
			buttonPlay.interactable = false;
		}
	}

	void checkSave() {
		List<Save> saves = GameModel.Saves;
		for (int i = 0; i < saves.Count; i++) {
			if(saves[i].Hero.Name != null) {
				buttons[i].interactable = true;
				buttons[i].GetComponentInChildren<Text>().text = 
					"Name : "+saves[i].Hero.Name+"\nClass : "+saves[i].Hero.GetType().ToString()+"\nLevel : "+(saves[i].Hero.Level + 1)+"\nLast Level : "+GameModel.Levels[saves[i].LevelId].Name;
				buttons[i].GetComponentInChildren<Text>().alignment = TextAnchor.MiddleLeft;
				buttons[i].GetComponentInChildren<Text>().fontSize = 14;
				buttons[i].GetComponentInChildren<Text>().lineSpacing = 1.6f;
			}
		}
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

	public void Play() {

		loadingCanvas.SetActive(true);
		GameModel.loadSave(save);
		Application.LoadLevel ("GameScene");
	}

	public void Return() {
		MenuController.Animator.SetTrigger("loadToMain");
	}

}
