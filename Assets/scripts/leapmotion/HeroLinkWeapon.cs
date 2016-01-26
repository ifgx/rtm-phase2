using UnityEngine;
using System.Collections;

public class HeroLinkWeapon : MonoBehaviour {

	private Hero hero;

	public Hero Hero{
		get{
			return this.hero;
		}
		set{
			this.hero = value;
		}
	}

	public void Update() {
		Debug.Log("HeroLinkWeapon : hero="+hero.GetType().ToString());
		Debug.Log("HeroLinkWeapon : hero="+hero.Name);
	}

}
