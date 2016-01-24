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
<<<<<<< HEAD
		hero.HealthPoint += gain;
		hero.attachHudPrefab(Resources.Load("prefabs/hud/LifePotionEffect") as GameObject, 1);
=======
		hero.Heal(gain);
>>>>>>> d6db3829d7dfcd08c650bc927c99220b5432a6c6
	}


}
