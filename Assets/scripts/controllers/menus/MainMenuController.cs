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
		Application.LoadLevel ("Hero_menu");
	}

	public void Custom() {
		Application.LoadLevel ("Custom_menu");
	}

	public void Load() {
		Application.LoadLevel ("Load_menu");
	}

	public void HighScore() {
		Application.LoadLevel("HighScore_menu");
	}

	public void Exit() {
		Application.Quit();
	}
}
