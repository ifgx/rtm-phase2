using UnityEngine;
using System.Collections;

/**
* @author HugoLS
* @version 1.0
**/
public class Warrior : Hero {
	

	float specialCapacityCooldown = 30.0f;
	float specialCapacityTimer = 5.0f;
	
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Renderer>().material.color = Color.magenta;

	}
	
	// Update is called once per frame
	void Update () {
		base.Update();
	}

	/**
	* Constructeur de la classe Warrior
	* @version 1.0
	**/
	public Warrior()
		:base(
			HeroConfigurator.warriorRange,
			HeroConfigurator.warriorXpQuantity,
			HeroConfigurator.warriorBlockingPercent,
			"epee",
			HeroConfigurator.warriorPowerQuantity,
			HeroConfigurator.warriorHpRefresh,
			HeroConfigurator.warriorPowerRefresh,
			HeroConfigurator.warriorHp,
			HeroConfigurator.warriorDamage,
			HeroConfigurator.warriorMovementSpeed,
			"cac", 
			"Aragorn"){
		PowerQuantity = 0;
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
			HpRefresh +=1;
		}
		else if(level > 3)
		{
			HpRefresh +=1;
		}
		else if(level > 2)
		{
			Damage *= 1.1f;
		}
		else if(level > 1)
		{
			MaxHealthPoint *= 1.1f;
		}
	}

	/**
	* FR:
	* Cette fonction permet au héro d'infliger des dégâts en fonction de sa barre de puissance
	* EN:
	* Permits to the hero to do damage according to his power
	* @return Return float
	* @version 1.0
	**/
	public override float Damage {
		get {
			float coeff = (2 - 1) * (PowerQuantity / MaxPowerQuantity) + 1;
			return this.damage * coeff;
		}
		set {
			damage = value;
		}
	}

	/**
	* {@inheritDoc}
	**/
	public override void LostHP(float damageEnemy)
	{
		float damageToLost = 0.0f;

		if(!SpecialCapacity)
		{
			if(Defending)
			{
				damageToLost = damageEnemy - (blockingPercent*damageEnemy/100);
				PowerQuantity += damageEnemy/2.0f;
			}
			else
			{
				damageToLost = damageEnemy;
				PowerQuantity += damageEnemy;
			}
		}
		base.LostHP(damageToLost);
	}


	/**
	* {@inheritDoc}
	**/
	public override void SpecialCapacitySpell()
	{

		if(specialCapacity && LastCapacityUsed + specialCapacityTimer < Time.time)
		{
			specialCapacity = false;
			unmakeInvincible();
		}

		if(!specialCapacity && LastCapacityUsed + specialCapacityCooldown < Time.time) // Si le cooldown est passé
		{
			specialCapacity = true;
			makeInvincible(specialCapacityTimer);
			LastCapacityUsed = Time.time;		
		}
	}

	/**
	* {@inheritDoc}
	**/
	public override void PreAttack()
	{

	}

	/**
	* {@inheritDoc}
	**/
	public override void PostAttack()
	{
		PowerQuantity /= 2;
	}
	
}

