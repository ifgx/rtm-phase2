using UnityEngine;
using System.Collections;

/**
 * @author Adrien D
 * @version 1.0
 */

 /**
  * The Loading Controller
  * It is the entry point of the game to initialize the Game Model
  */
public class LoadingController : MonoBehaviour {


	//Fix Unity crash bug if loadlevel on pre-frame
	IEnumerator Start()
	{
		yield return null;
		GameModel.Init ();
		Application.LoadLevel("Main_menu");
	}
}
