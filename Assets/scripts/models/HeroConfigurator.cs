using UnityEngine;
using System.Collections;
using SimpleJSON;
using System.IO; //pour StreamReader

public class HeroConfigurator : MonoBehaviour {
	

	// WARRIOR
	public static string warriorAttackType;
	public static float warriorXpQuantity;
	public static float warriorBlockingPercent;
	public static float warriorPowerQuantity;
	public static float warriorHpRefresh;
	public static float warriorPowerRefresh;
	public static float warriorHp;
	public static float warriorDamage;
	public static float warriorMovementSpeed;
	public static float warriorRange;

	// MONK
	public static string monkAttackType;
	public static float monkXpQuantity;
	public static float monkBlockingPercent;
	public static float monkPowerQuantity;
	public static float monkHpRefresh;
	public static float monkPowerRefresh;
	public static float monkHp;
	public static float monkDamage;
	public static float monkMovementSpeed;
	public static float monkRange;

	public static float monkSpeedHeal;
	public static float monkPowerHealConsumption;
	public static float monkHpHealed;

	// WIZARD
	public static string wizardAttackType;
	public static float wizardXpQuantity;
	public static float wizardBlockingPercent;
	public static float wizardPowerQuantity;
	public static float wizardHpRefresh;
	public static float wizardPowerRefresh;
	public static float wizardHp;
	public static float wizardDamage;
	public static float wizardMovementSpeed;
	public static float wizardRange;
	public static float wizardAttackCost;
	public static float wizardDefenseCost;
	public static float wizardRegenAttack;



	public static void Init()
	{
		JSONNode root = getJsonFile ("Config/Hero.JSON");

		warriorAttackType = root["warriorAttackType"];
		warriorXpQuantity = root["warriorXpQuantity"].AsFloat;
		warriorBlockingPercent = root["warriorBlockingPercent"].AsFloat;
		warriorPowerQuantity = root["warriorPowerQuantity"].AsFloat;
		warriorHpRefresh = root["warriorHpRefresh"].AsFloat;
		warriorPowerRefresh = root["warriorPowerRefresh"].AsFloat;
		warriorHp = root["warriorHp"].AsFloat;
		warriorDamage = root["warriorDamage"].AsFloat;
		warriorMovementSpeed = root["warriorMovementSpeed"].AsFloat;
		warriorRange = root["warriorRange"].AsFloat;
		monkAttackType = root["monkAttackType"];
		monkXpQuantity = root["monkXpQuantity"].AsFloat;
		monkBlockingPercent = root["monkBlockingPercent"].AsFloat;
		monkPowerQuantity = root["monkPowerQuantity"].AsFloat;
		monkHpRefresh = root["monkHpRefresh"].AsFloat;
		monkPowerRefresh = root["monkPowerRefresh"].AsFloat;
		monkHp = root["monkHp"].AsFloat;
		monkDamage = root["monkDamage"].AsFloat;
		monkMovementSpeed = root["monkMovementSpeed"].AsFloat;
		monkRange = root["monkRange"].AsFloat;
		monkSpeedHeal = root["monkSpeedHeal"].AsFloat;
		monkPowerHealConsumption = root["monkPowerHealConsumption"].AsFloat;
		monkHpHealed = root["monkHpHealed"].AsFloat;
		wizardAttackType = root["wizardAttackType"];
		wizardXpQuantity = root["wizardXpQuantity"].AsFloat;
		wizardBlockingPercent = root["wizardBlockingPercent"].AsFloat;
		wizardPowerQuantity = root["wizardPowerQuantity"].AsFloat;
		wizardHpRefresh = root["wizardHpRefresh"].AsFloat;
		wizardPowerRefresh = root["wizardPowerRefresh"].AsFloat;
		wizardHp = root["wizardHp"].AsFloat;
		wizardDamage = root["wizardDamage"].AsFloat;
		wizardMovementSpeed = root["wizardMovementSpeed"].AsFloat;
		wizardRange = root["wizardRange"].AsFloat;
		wizardAttackCost = root["wizardAttackCost"].AsFloat;
		wizardDefenseCost = root["wizardDefenseCost"].AsFloat;
		wizardRegenAttack = root["wizardRegenAttack"].AsFloat;
	}

	private static JSONNode getJsonFile(string path){
		StreamReader r = new StreamReader (path); // access the json file
		string json = r.ReadToEnd (); // convert its content to a string 

		r.Close();

		return JSON.Parse(json); // return the content as a JSONNode
	}
}
