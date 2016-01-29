using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/**
 * @author Adrien D
 * @version 1.0
 */

 /**
  * Manipulator of a tutorial UI
  */ 
public class TutorialUIManager : MonoBehaviour {

	private Text title;
	private Text attack;
	private Image image;
	private Text desc;


	// Use this for initialization
	/**
	 * Initialization
	 */
	void Awake () {
		title = GameObject.Find("Title").GetComponent<Text>();
		attack = GameObject.Find("Attack").GetComponent<Text>();
		desc = GameObject.Find("Description").GetComponent<Text>();
		//Debug.Log ("text : " + title);
		image = transform.GetComponentsInChildren<Image>()[1];
	}


	/**
	 * Set the title of the tutorial
	 */
	public void setTitle(string newText){
		title.text = newText;
	}

	/**
	 * Set the attack of the tutorial
	 */
	public void setAttack(string newText){
		attack.text = newText;
	}

	/**
	 * Set the description of the tutorial
	 */
	public void setDescription(string newText){
		desc.text = newText;
	}

	/**
	 * Set the image of the tutorial
	 */
	public void setImage(string imageName){
		Sprite sprite = Resources.Load<Sprite>("helpImages/"+imageName) as Sprite;
		//Debug.Log ("helpImages/" + imageName);
		//Debug.Log (sprite.bounds);
		image.sprite = sprite;
	}
}
