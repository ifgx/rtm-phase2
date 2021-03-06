﻿using UnityEngine;
using System.Collections;

/**
 * @author Adrien D
 * @version 1.0
 */

/**
 * Potion script
 */

public abstract class Potion : MonoBehaviour {
    private AudioManager audioManager;

    public Potion(){

	}

	public Vector3 GetPosition()
	{
		float x = this.transform.position.x;
		float y = this.transform.position.y;
		float z = this.transform.position.z;

		return new Vector3(x,y,z);
	}

	void Update() {

		if (audioManager == null) {
			audioManager = GameObject.Find("Main Camera").GetComponent<AudioManager>();
		}
	
	}

	/**
	 * Triggers the effect on collision with the Hero
	 */
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			Hero hero = other.gameObject.GetComponentInParent<Hero> ();
			triggerEffect (hero);
            
            audioManager.playPotionSound();
            GameModel.PotionsInGame.Remove (this);
			Destroy(this.gameObject);
		}
	}

	/**
	 * Do the effet of the potion on the hero
	 */
	protected abstract void triggerEffect(Hero hero);
}
