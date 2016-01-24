using UnityEngine;
using System.Collections;

/**
 * @author Adrien D
 * @version 1.0
 */

/**
 * Invincibility potion script
 */
public class InvicibilityPotion : Potion {

	//private float gain = 200.0f;

	/**
	 * Do the effet of the potion on the hero
	 */
	protected override void triggerEffect(Hero hero) {
<<<<<<< HEAD
		hero.makeInvicible (7.0f);
		hero.attachHudPrefab(Resources.Load("prefabs/hud/InvinciblePotionEffect") as GameObject, 7);
=======
		hero.makeInvincible (7.0f);
>>>>>>> d6db3829d7dfcd08c650bc927c99220b5432a6c6
	}
}
