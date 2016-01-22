﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.UI;

/**
 * @author Adrien D & Baptiste V
 * @version 1.0
 */

/**
 * Class made to update game HUD according to values
 */
public class HudMaster : MonoBehaviour {

    public enum HudType { Life, Special };

    public GameObject hudLife;
    public GameObject hudSpecial;
	public GameObject hudXPBar;
	public GameObject hudXPText;
	public GameObject hudShield;

	private bool shieldActivated;

	private float timerShield = 0.0f;
	private float maxTimerShield = 0.5f;

	private Hero hero;

	//private float groundOnCam;

	public void setHero(Hero hero) {
		this.hero = hero;
	}

    // Use this for initialization
    /**
     * Initialization
     */
    void Start () {
       // hudLife = GameObject.Find("hud_life");
       // hudSpecial = GameObject.Find("hud_special");

		string heroClass = hero.GetType().ToString();

		/*if (heroClass == "Wizard" || heroClass == "Monk") 
		{

		} 
		else 
		{
			Sprite spr = Resources.Load ("prefabs/hud/LifePotionEffect");
			
			hudSpecial.GetComponent<Image>().sprite = spr;
		}*/

		if (heroClass == "Warrior")
		{
			//warrior uses rage not mana, so get the right orb
			Sprite spr = Resources.Load<Sprite>("sprite/orb_fill_right_green");

			Debug.Log ("spr="+spr);
			
			hudSpecial.GetComponent<Image>().overrideSprite = spr;
		}



		shieldActivated = false;


		//groundOnCam = Camera.main.WorldToViewportPoint(new Vector3 (0.0f, 0.0f, GameModel.HerosInGame[0].GetPosition().z + 3.0f)).y*this.gameObject.GetComponent<RectTransform>().sizeDelta.y;

    }
	
	
	/**
	 * Update is called once per frame
	 */


	/**
	 * Update life or power bar to a certain value
	 * @param HudType _hudType Is it power HUD or Life HUD
	 * @param float _levelPercent Number between 0 and 100 that will graphically sets the filling percentage of the gauje
	 **/
    public void setLevel(HudType _hudType, float _levelPercent)
    {
        GameObject hudTarget = null;

        if (_hudType == HudType.Life)
        {
            hudTarget = hudLife;
        }
        else if (_hudType == HudType.Special)
        {
            hudTarget = hudSpecial;
        }


		//Debug.Log("hudtarget : "+hudTarget+" amount:"+_levelPercent/100);
        if (hudTarget != null)
        {
            //hudTarget.transform.localScale = new Vector3(1, _levelPercent/100, 1);
			hudTarget.GetComponent<Image>().fillAmount =  _levelPercent/100;
			//Debug.Log("hudtarget : "+hudTarget+" amount:"+_levelPercent/100);
        }
    }

    /**
     * Update XP bar to a certain value
     * @param float xpPercent The XP percent from 0 to 100
     * @param int level The level number
     */
	public void updateXP(float xpPercent, int level) {

		hudXPBar.transform.localScale = new Vector3 (xpPercent / 100.0f, 1.0f, 1.0f);

		//GameObject levelDigit = hudXP.transform.FindChild ("levelText").gameObject;
		hudXPText.GetComponentInChildren<Text>().text = level.ToString();


	}

	/**
	 * Getter Setter for the little shield to activate
	 */
	public bool ShieldActivated {
		get {
			return this.shieldActivated;
		}
		set {
			Vector3 vec = new Vector3(Random.Range(-2.0F, 2.0F), 1.50f, GameModel.HerosInGame[0].GetPosition().z + 3.0f);
			Debug.Log("random : " + vec );
			WorldToShieldPosition( vec );
			this.shieldActivated = value;
			hudShield.SetActive(value);
			timerShield = 0.0f;
		
		}
	}

	public void setRenderCamera(Camera cam) {
		Canvas can = GetComponent<Canvas> ();
		can.worldCamera = cam;
	}
	
	/**
	 * Sets shield position to the screen in function of a world position
	 * @param Vector3 worldPosition
	 */
	public void WorldToShieldPosition (Vector3 worldPosition) {
		//hudShield.transform. position = Camera.main.WorldToScreenPoint (worldPosition);
		//Debug.Log ("screen : " + hudShield.transform.position);
		//Vector3 pos = hudShield.transform.position;
		//pos.y = 0.0f;


//		//this is the ui element
//		RectTransform UI_Element = hudShield.GetComponent<RectTransform>();
//		
//		//first you need the RectTransform component of your canvas
//		RectTransform CanvasRect=this.gameObject.GetComponent<RectTransform>();
//		
//		//then you calculate the position of the UI element
//		//0,0 for the canvas is at the center of the screen, whereas WorldToViewPortPoint treats the lower left corner as 0,0. Because of this, you need to subtract the height / width of the canvas * 0.5 to get the correct position.
//		
//		Vector2 ViewportPosition=Camera.main.WorldToViewportPoint(worldPosition);
//		Vector2 WorldObject_ScreenPosition=new Vector2(
//			(ViewportPosition.x*CanvasRect.sizeDelta.x),
//			(ViewportPosition.y*CanvasRect.sizeDelta.y + groundOnCam));
//		 ////-(CanvasRect.sizeDelta.x*0.5f))
//		 /// //-(CanvasRect.sizeDelta.y*0.5f)));
//		//now you can set the position of the ui element
//		Debug.Log (WorldObject_ScreenPosition);
//		UI_Element.anchoredPosition=WorldObject_ScreenPosition;


		Debug.Log (RectTransformUtility.WorldToScreenPoint (Camera.main, worldPosition));
		Vector2 pos = hudShield.GetComponent<RectTransform> ().anchoredPosition;
		pos = RectTransformUtility.WorldToScreenPoint (Camera.main, worldPosition);
		//pos.y -= -2f;
		hudShield.GetComponent<RectTransform> ().anchoredPosition = pos;
	}


}
