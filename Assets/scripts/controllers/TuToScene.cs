using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class TuToScene : MonoBehaviour {

	List<Tutorial> tutorials;

	GameObject basicTuto1, basicTuto2, basicTuto3, loading;
	bool tuto1;


	// Use this for initialization
	void Start () {

		tutorials = TutorialParser.parseTutorials();

		foreach (Tutorial tuto in tutorials) {
			if(GameModel.PlayWithLeap){

				GameObject.Find("HeroDeviceInfo").GetComponent<Text>().text = "LeapMotion";

				if(tuto.Name == "Leap") {
					Sprite spriteTmp = Resources.Load<Sprite>("helpImages/"+tuto.ImagePath);
					GameObject.Find("ImageDevice").GetComponent<Image>().sprite = spriteTmp ;
					GameObject.Find("DescriptionDevice").GetComponent<Text>().text = tuto.Text;
				}

				if(tuto.Name.Contains("Leap")){
					if(tuto.Name.Contains("warrior") && GameModel.Hero.GetType().ToString() == "Warrior"){
						if(tuto.Name.Contains("Attack")){
							Sprite spriteTmp = Resources.Load<Sprite>("helpImages/"+tuto.ImagePath);
							GameObject.Find("ImageAttack").GetComponent<Image>().sprite = spriteTmp ;
							GameObject.Find("DescriptionAttack").GetComponent<Text>().text = tuto.Text;
						} else {
							Sprite spriteTmp = Resources.Load<Sprite>("helpImages/"+tuto.ImagePath);
							GameObject.Find("ImageDefence").GetComponent<Image>().sprite = spriteTmp ;
							GameObject.Find("DescriptionDefence").GetComponent<Text>().text = tuto.Text;
						}
					} else if (tuto.Name.Contains("wizard") && GameModel.Hero.GetType().ToString() == "Wizard"){
						if(tuto.Name.Contains("Attack")){
							Sprite spriteTmp = Resources.Load<Sprite>("helpImages/"+tuto.ImagePath);
							GameObject.Find("ImageAttack").GetComponent<Image>().sprite = spriteTmp ;
							GameObject.Find("DescriptionAttack").GetComponent<Text>().text = tuto.Text;
						} else {
							Sprite spriteTmp = Resources.Load<Sprite>("helpImages/"+tuto.ImagePath);
							GameObject.Find("ImageDefence").GetComponent<Image>().sprite = spriteTmp ;
							GameObject.Find("DescriptionDefence").GetComponent<Text>().text = tuto.Text;
						}
					} else if (tuto.Name.Contains("monk") && GameModel.Hero.GetType().ToString() == "Monk") {
						if(tuto.Name.Contains("Attack")){
							Sprite spriteTmp = Resources.Load<Sprite>("helpImages/"+tuto.ImagePath);
							GameObject.Find("ImageAttack").GetComponent<Image>().sprite = spriteTmp ;
							GameObject.Find("DescriptionAttack").GetComponent<Text>().text = tuto.Text;
						} else {
							Sprite spriteTmp = Resources.Load<Sprite>("helpImages/"+tuto.ImagePath);
							GameObject.Find("ImageDefence").GetComponent<Image>().sprite = spriteTmp ;
							GameObject.Find("DescriptionDefence").GetComponent<Text>().text = tuto.Text;
						}
					}
				}
			} else {

				GameObject.Find("HeroDeviceInfo").GetComponent<Text>().text = "Keyboard & Mouse";

				if(tuto.Name == "Keyboard") {
					Sprite spriteTmp = Resources.Load<Sprite>("helpImages/"+tuto.ImagePath);
					GameObject.Find("ImageDevice").GetComponent<Image>().sprite = spriteTmp ;
					GameObject.Find("DescriptionDevice").GetComponent<Text>().text = tuto.Text;
				}


				if(tuto.Name.Contains("Keyboard")){
					if (tuto.Name.Contains("warrior") && GameModel.Hero.GetType().ToString() == "Warrior"){
						if(tuto.Name.Contains("Attack")){
							Sprite spriteTmp = Resources.Load<Sprite>("helpImages/"+tuto.ImagePath);
							GameObject.Find("ImageAttack").GetComponent<Image>().sprite = spriteTmp ;
							GameObject.Find("DescriptionAttack").GetComponent<Text>().text = tuto.Text;
						} else {
							Sprite spriteTmp = Resources.Load<Sprite>("helpImages/"+tuto.ImagePath);
							GameObject.Find("ImageDefence").GetComponent<Image>().sprite = spriteTmp ;
							GameObject.Find("DescriptionDefence").GetComponent<Text>().text = tuto.Text;
						}
					} else if (tuto.Name.Contains("wizard") && GameModel.Hero.GetType().ToString() == "Wizard"){
						if(tuto.Name.Contains("Attack")){
							Sprite spriteTmp = Resources.Load<Sprite>("helpImages/"+tuto.ImagePath);
							GameObject.Find("ImageAttack").GetComponent<Image>().sprite = spriteTmp ;
							GameObject.Find("DescriptionAttack").GetComponent<Text>().text = tuto.Text;
						} else {
							Sprite spriteTmp = Resources.Load<Sprite>("helpImages/"+tuto.ImagePath);
							GameObject.Find("ImageDefence").GetComponent<Image>().sprite = spriteTmp ;
							GameObject.Find("DescriptionDefence").GetComponent<Text>().text = tuto.Text;
						}
					} else if (tuto.Name.Contains("monk") && GameModel.Hero.GetType().ToString() == "Monk") {
						if(tuto.Name.Contains("Attack")){
							Sprite spriteTmp = Resources.Load<Sprite>("helpImages/"+tuto.ImagePath);
							GameObject.Find("ImageAttack").GetComponent<Image>().sprite = spriteTmp ;
							GameObject.Find("DescriptionAttack").GetComponent<Text>().text = tuto.Text;
						} else {
							Sprite spriteTmp = Resources.Load<Sprite>("helpImages/"+tuto.ImagePath);
							GameObject.Find("ImageDefence").GetComponent<Image>().sprite = spriteTmp ;
							GameObject.Find("DescriptionDefence").GetComponent<Text>().text = tuto.Text;
						}
					}
				}
			}
		}

		basicTuto1 = GameObject.Find("BasicTuto1");
		basicTuto2 = GameObject.Find("BasicTuto2");
		basicTuto3 = GameObject.Find("BasicTuto3");
		loading = GameObject.Find("LoadingCanvas");

		tuto1 = true;

		basicTuto1.SetActive(true);
		basicTuto2.SetActive(false);
		basicTuto3.SetActive(false);
		loading.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {


	}

	public void NextTuto(){
		if (tuto1) {
			basicTuto1.SetActive(false);
			basicTuto2.SetActive(true);
			tuto1 = false;
		} else {
			basicTuto2.SetActive(false);
			basicTuto3.SetActive(true);
		}
	}

	public void Play(){
		basicTuto3.SetActive(false);
		loading.SetActive(true);
		Application.LoadLevel("GameScene");
	}
}
