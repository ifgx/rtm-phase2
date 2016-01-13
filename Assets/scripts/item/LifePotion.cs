using UnityEngine;
using System.Collections;

/**
 * @author Adrien D
 * @version 1.0
 */

/**
 * Life potion script
 */

public class LifePotion : Potion {

	private float gain = 200.0f;

	/**
	 * Do the effet of the potion on the hero
	 */
	protected override void triggerEffect(Hero hero) {
		hero.HealthPoint += gain;

		//Debug.LogWarning(GameObject.Find("/Resources/prefabs/hud/LifePotionEffect"));

		hero.attachHudPrefab(Resources.Load("prefabs/hud/LifePotionEffect") as GameObject);
	}


}
