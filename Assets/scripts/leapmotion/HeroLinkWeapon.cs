using UnityEngine;
using System.Collections;

public class HeroLinkWeapon : MonoBehaviour {

	private Hero hero;
	private bool child = false;
	GameObject fireballGO;
	GameObject fireball;

	public Hero Hero{
		get{
			return this.hero;
		}
		set{
			this.hero = value;
		}
	}

	public bool Child{
		get{
			return this.child;
		}
		set{
			this.child = value;
		}
	}

	public void Start(){
		if (hero.GetType().ToString() == "Wizard") {
			float diameter = ((Wizard)hero).fireBallDiameter/2;
			transform.localScale = new Vector3(diameter/2, 0, 0);
			this.GetComponent<ParticleSystem>().startSize = diameter;
		}

		if(child == false){
			if(hero.SpecialCapacityUnlocked)
			{

				fireballGO = Resources.Load ("prefabs/leapmotion/Fireball") as GameObject;
				fireball = Instantiate (fireballGO);
				float factor = 0.000001f;
				float randomX = Random.Range(-1.0F, 1.0F);
				float randomY = Random.Range(-1.0F, 1.0F);
				fireball.GetComponent<ConstantForce>().force = new Vector3(factor*randomX,factor*randomY,factor*10);
				fireball.GetComponentInChildren<HeroLinkWeapon> ().Hero = hero;//new Wizard ();
				fireball.GetComponentInChildren<HeroLinkWeapon> ().Child = true;//new Wizard ();
				fireball.transform.position = this.transform.position;
				fireball.GetComponentInChildren<CapsuleCollider>().enabled = true;
				fireball.GetComponent<Rigidbody>().isKinematic = false;
				
				//hero.PowerQuantity -= HeroConfigurator.wizardAttackCost;
			}
		}
	}

	public void Update() {
		
	}

}
