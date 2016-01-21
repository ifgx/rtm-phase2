using UnityEngine;
using System.Collections;

/**
 * @author Adrien D / Kevin R
 * @version 1.1
 */

/**
 * Controller for the main menu of the game
 */
public class MainMenuController : MonoBehaviour {

	public void Play() {
		MenuController.Animator.SetTrigger("mainToClass");
		//Debug.Log("Menu single player");
		//Application.LoadLevel ("Hero_menu");
	}

	public void Tutorial() {
		Application.LoadLevel ("Hero_menu");
	}

	public void Custom() {
		
		//Application.LoadLevel ("Custom_menu");
	}

	public void Load() {
		MenuController.Animator.SetTrigger("mainToLoad");
		//Application.LoadLevel ("Load_menu");
	}

	public void MultiPlayer() {
		MenuController.Animator.SetTrigger("mainToMulti");
		//Application.LoadLevel ("MultiPlayer_Menu");
	}

	public void HighScore() {
		MenuController.Animator.SetTrigger("mainToHighScore");
		//Application.LoadLevel("HighScore_menu");

	}

	public void Exit() {
		Application.Quit();
	}
}
