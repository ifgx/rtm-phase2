using UnityEngine;
using System.Collections;

public class CreditsMenuController : MonoBehaviour {

	public void Return(){
		//Application.LoadLevel ("Main_menu");
		MenuController.Animator.SetTrigger("creditToMain");
	}
}
