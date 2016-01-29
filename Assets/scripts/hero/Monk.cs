using UnityEngine;
using System.Collections;

/**
* @author HugoLS
* @version 1.0
**/
public class Monk : Hero {
	
	float specialCapacityCooldown = 5.0f;
	float specialCapacityTimer = 0.0f;
	bool prayerMode;
	float lastHeal;
	float speedHeal;
	float powerHealConsumption;
	float hpHealed;
	
	// Use this for initialization
	void Start () {
		//gameObject.GetComponent<Renderer>().material.color = Color.yellow;
	}
	
	// Update is called once per frame
	void Update () {
		base.Update();
		if(prayerMode)
		{
			Pray();
		}
	}

	/**
	* Constructeur de la classe Monk
	* @version 1.0
	**/
	public Monk()
		:base(
			HeroConfigurator.monkRange,
			HeroConfigurator.monkXpQuantity,
			HeroConfigurator.monkBlockingPercent,
			"armeHast",
			HeroConfigurator.monkPowerQuantity,
			HeroConfigurator.monkHpRefresh,
			HeroConfigurator.monkPowerRefresh,
			HeroConfigurator.monkHp,
			HeroConfigurator.monkDamage,
			HeroConfigurator.monkMovementSpeed,
			"semiDistance", 
			"Labbe Pierre"){
		prayerMode = false;
		lastHeal = Time.time;
		speedHeal = HeroConfigurator.monkSpeedHeal;
		powerHealConsumption = HeroConfigurator.monkPowerHealConsumption;
		//Debug.Log("powerHealConsumption:"+powerHealConsumption);// ON A BIEN 50.0f
		hpHealed = HeroConfigurator.monkHpHealed;
	}

	public void Pray()
	{
		//Debug.Log("powerHealConsumption debut prière:"+powerHealConsumption);
		if(PowerQuantity <= 0.0f)
		{
			//Debug.Log("prayerMode = false beacause powerquantity empty");
			if (this.PrayerMode == true)
				PrayerMode = false;
		}
		else
		{
			if(lastHeal + speedHeal < Time.time)
			{
				//Debug.Log("Power Before Praying:"+PowerQuantity);
				//Debug.Log("Consommation en cours de prière:"+powerHealConsumption);
				PowerQuantity -= powerHealConsumption;
                //Debug.Log("Power After Praying:"+PowerQuantity);
                audioManager = GameObject.Find("Main Camera").GetComponent<AudioManager>();
                audioManager.playHealSound();
                if (HealthPoint + hpHealed < maxHp){
                    
                    HealthPoint += hpHealed;
				}
				else
				{
					HealthPoint = maxHp;
				}
				lastHeal = Time.time;
			}
		}
	}

	/**
	* {@inheritDoc}
	**/
	public override void adaptStatAccordingToLevel()
	{
		if(level > 5)
		{
			SpecialCapacityUnlocked = true;
			LastCapacityUsed = Time.time;
		}
		else if(level > 4)
		{
			hpHealed *= 1.5f;
			HpRefresh +=1;
		}
		else if(level > 3)
		{
			Damage *= 1.1f;
		}
		else if(level > 2)
		{
			hpHealed *= 1.25f;
			MaxHealthPoint *= 1.1f;
		}
		else if(level > 1)
		{
			MaxHealthPoint *= 1.1f;
		}
	}

	/**
	* {@inheritDoc}
	**/
	public override void SpecialCapacitySpell()
	{
		if(LastCapacityUsed + specialCapacityCooldown < Time.time) // Si le cooldown est passé
		{
			regenPlayers();
			LastCapacityUsed = Time.time;
		}	/// REND 5 PV TOUTE LES 5 SECONDES
	}

	/**
	 * if setting to false, stop the sound
	 **/
	public bool PrayerMode{
		get{
			return prayerMode;
		}
		set{
			//avoid variable rewrite and spam if same state
			if (prayerMode != value)
			{
				//Debug.Log ("Setter PrayerMode="+value);
				prayerMode = value;

				if (prayerMode == false)
				{
					if (audioManager != null)
						audioManager.stopHealSound();
				}
			}
		}
	}

	public void regenPlayers()
	{
		int hpHealed = 15;
		foreach(Hero hero_ in GameModel.HerosInGame){
			hero_.Heal(hpHealed);
		}
	}
	
}

