using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClassMenuController : MonoBehaviour {

	public GameObject go;

	Button buttonWarrior;
	Button buttonWizard;
	Button buttonMonk;

	// Use this for initialization
	void Start () {
		buttonWarrior = go.transform.Find("Canvas/Warrior").GetComponent<Button>();
		buttonWizard = go.transform.Find("Canvas/Wizard").GetComponent<Button>();
		buttonMonk = go.transform.Find("Canvas/Monk").GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Warrior(){
		GameModel.Hero = new Warrior();
		MenuController.Animator.SetTrigger("classToSingle");
	}

	public void Wizard(){
		GameModel.Hero = new Wizard();
		MenuController.Animator.SetTrigger("classToSingle");
	}

	public void Monk(){
		GameModel.Hero = new Monk();
		MenuController.Animator.SetTrigger("classToSingle");
	}

	public void Return() {
		MenuController.Animator.SetTrigger("classToMain");
	}
}
