using UnityEngine;
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
	public GameObject hudCanvasEffect;
	public GameObject hudClassText;


	private Hero hero;

	int actualLevel = 1;

	
	public void setHero(Hero hero) {
		this.hero = hero;
	}

    // Use this for initialization
    /**
     * Initialization
     */
    void Start () {

		if (hero != null)
		{
			string heroClass = hero.GetType().ToString();

			if (heroClass == "Warrior")
			{
				//warrior uses rage not mana, so get the right orb
				Sprite spr = Resources.Load<Sprite>("sprite/orb_fill_right_green");
				
				hudSpecial.GetComponent<Image>().overrideSprite = spr;
			}
		}
    }	


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
			//to enable animation when low hp
			//1+invertedPercent because its relative to life stack
			if (hudLife != null)
				hudLife.GetComponent<Animator>().SetFloat("life_level", 2-(_levelPercent/100f));

        }
        else if (_hudType == HudType.Special)
        {
            hudTarget = hudSpecial;
        }


		//Debug.Log("hudtarget : "+hudTarget+" amount:"+_levelPercent/100);
        if (hudTarget != null)
        {
            //hudTarget.transform.localScale = new Vector3(1, _levelPercent/100, 1);
			hudTarget.GetComponent<Image>().fillAmount =  _levelPercent/100f;
			//Debug.Log("hudtarget : "+hudTarget+" amount:"+_levelPercent/100+" (level percent= "+_levelPercent+")");


        }
    }

    /**
     * Update XP bar to a certain value
     * @param float xpPercent The XP percent from 0 to 100
     * @param int level The level number
     */
	public void updateXP(float xpPercent, int level) {

		//if we upped level, play the animation
		if (level > actualLevel)
		{
			hudCanvasEffect.GetComponent<Animator>().SetTrigger("level_up");
			//Debug.Log("Animator from level "+level+" to "+actualLevel + hudCanvasEffect.GetComponent<Animator>());
			actualLevel = level;
		}

		hudXPText.GetComponentInChildren<Text>().text = level.ToString();
		hudClassText.GetComponentInChildren<Text>().text = hero.GetType().ToString() + " rank ";
		hudXPBar.GetComponent<Image>().fillAmount =  xpPercent / 100.0f;
	}

	public void setRenderCamera(Camera cam) {
		Canvas can = GetComponent<Canvas> ();
		can.worldCamera = cam;
	}


}
