using UnityEngine;
using System.Collections;

/**
* @author HugoLS
* @version 1.0
**/
public class Wizard : Hero {
	
	float specialCapacityCooldown = 30.0f;
	float specialCapacityTimer = 5.0f;
	float shieldSize = 0.0f;
	
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Renderer>().material.color = Color.cyan;
	}
	
	// Update is called once per frame
	void Update () {
		base.Update();
		if(PowerQuantity < MaxPowerQuantity)
		{
			if(base.lastRegenPower + 1 < Time.time)
			{
				base.RegenPower();	
			}
		}
	}

	/**
	* Constructeur de la classe Wizard
	* @version 1.0
	**/
	public Wizard()
		:base(
			HeroConfigurator.wizardRange,
			HeroConfigurator.wizardXpQuantity,
			HeroConfigurator.wizardBlockingPercent,
			"baton",
			HeroConfigurator.wizardPowerQuantity,
			HeroConfigurator.wizardHpRefresh,
			HeroConfigurator.wizardPowerRefresh,
			HeroConfigurator.wizardHp,
			HeroConfigurator.wizardDamage,
			HeroConfigurator.wizardMovementSpeed,
			"distance", 
			"Gandalf"){
	}
	
	/**
	* {@inheritDoc}
	**/
	public override void HasKilled(float XP)
	{
		GiveXP(XP);
		RegenPower();
		RegenPower();
		powerQuantity += HeroConfigurator.wizardRegenAttack;
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
			Damage *= 1.1f;
		}
		else if(level > 3)
		{
			MaxHealthPoint *= 1.1f;
		}
		else if(level > 2)
		{
			Damage *= 1.1f;
		}
		else if(level > 1)
		{
			Damage *= 1.1f;
		}
	}
}