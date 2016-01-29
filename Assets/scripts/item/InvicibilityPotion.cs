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

	AudioSource audioSource;

	void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}
	//private float gain = 200.0f;

	/**
	 * Do the effet of the potion on the hero
	 */
	protected override void triggerEffect(Hero hero) {

		hero.makeInvincible (7.0f);
		hero.attachHudPrefab(Resources.Load("prefabs/hud/InvinciblePotionEffect") as GameObject, 7);
		audioSource.PlayScheduled(0); //immediate play loaded clip
	}
}
