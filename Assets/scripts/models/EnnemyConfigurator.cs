using UnityEngine;
using System.Collections;

public class EnnemyConfigurator : MonoBehaviour {
	// GENERAL
	public static float maxMusicSpeedFactor = 5.0f;
	public static float minMusicSpeedFactor = 1.0f;
	
	// ASSASSIN    assassin
	public static string assassinName = "Assassin" ;
	public static string assassinAttackType = "CaC";
	public static float assassinMovementSpeed = 8.0f;
	public static float assassinAttackSpeed = 2.0f;
	public static float assassinXpGain = 50.0f;
	public static float assassinHp = 1.0f;
	public static float assassinDamage = 130.0f;
	public static float assassinAggroDistance = 30.0f;
	public static float assassinAttackRange = -1.0f;
	public static float assassinDistanceToDisappear = 2.0f;

	// CANNON   cannon
	public static string cannonName = "Cannon" ;
	public static string cannonAttackType = "Distance";
	public static float cannonMovementSpeed = 0.0f;
	public static float cannonAttackSpeed = 2.0f;
	public static float cannonXpGain = 0.0f;
	public static float cannonHp = 30.0f;
	public static float cannonDamage = 100.0f;

	public static float cannonAggroDistance = 30.0f;
	public static float cannonAttackRange = 27.0f;
	public static float cannonDistanceToDisappear = 2.0f;


	public static float cannonRotationSpeed = 10.0f;
	public static float cannonMinAttackRange = 10.0f;

	// BASIC_DRAGONET     basicDragonet
	public static string basicDragonetName = "BasicDragonet" ;
	public static string basicDragonetAttackType = "CaC";
	public static float basicDragonetMovementSpeed = 5.0f;
	public static float basicDragonetAttackSpeed = 2.0f;
	public static float basicDragonetXpGain = 30.0f;
	public static float basicDragonetHp = 50.0f;
	public static float basicDragonetDamage = 40.0f;
	public static float basicDragonetAggroDistance = 30.0f;
	public static float basicDragonetAttackRange = 2.5f;
	public static float basicDragonetDistanceToDisappear = 2.0f;

	// FIRE_DRAGONET     fireDragonet
	public static string fireDragonetName = "FireDragonet" ;
	public static string fireDragonetAttackType = "CaC";
	public static float fireDragonetMovementSpeed = 5.0f;
	public static float fireDragonetAttackSpeed = 2.0f;
	public static float fireDragonetXpGain = 75.0f;
	public static float fireDragonetHp = 80.0f;
	public static float fireDragonetDamage = 60.0f;
	public static float fireDragonetAggroDistance = 30.0f;
	public static float fireDragonetAttackRange = 2.5f;
	public static float fireDragonetDistanceToDisappear = 2.0f;

	// ICE_DRAGONET     iceDragonet
	public static string iceDragonetName = "IceDragonet" ;
	public static string iceDragonetAttackType = "CaC";
	public static float iceDragonetMovementSpeed = 5.0f;
	public static float iceDragonetAttackSpeed = 2.0f;
	public static float iceDragonetXpGain = 150.0f;
	public static float iceDragonetHp = 180.0f;
	public static float iceDragonetDamage = 80.0f;
	public static float iceDragonetAggroDistance = 30.0f;
	public static float iceDragonetAttackRange = 2.5f;
	public static float iceDragonetDistanceToDisappear = 2.0f;

	// BASIC_LANCER     basicLancer
	public static string basicLancerName = "BasicLancer" ;
	public static string basicLancerAttackType = "CaC";
	public static float basicLancerMovementSpeed = 5.0f;
	public static float basicLancerAttackSpeed = 20.0f;
	public static float basicLancerXpGain = 300.0f;
	public static float basicLancerHp = 20.0f;
	public static float basicLancerDamage = 60.0f;
	public static float basicLancerAggroDistance = 30.0f;
	public static float basicLancerAttackRange = 2.5f;
	public static float basicLancerDistanceToDisappear = 2.0f;

	// FIRE_LANCER      fireLancer
	public static string fireLancerName = "FireLancer" ;
	public static string fireLancerAttackType = "CaC";
	public static float fireLancerMovementSpeed = 5.0f;
	public static float fireLancerAttackSpeed = 20.0f;
	public static float fireLancerXpGain = 400.0f;
	public static float fireLancerHp = 25.0f;
	public static float fireLancerDamage = 80.0f;
	public static float fireLancerAggroDistance = 30.0f;
	public static float fireLancerAttackRange = 4.5f;
	public static float fireLancerDistanceToDisappear = 2.0f;

	// ICE_LANCER      iceLancer
	public static string iceLancerName = "IceLancer" ;
	public static string iceLancerAttackType = "CaC";
	public static float iceLancerMovementSpeed = 5.0f;
	public static float iceLancerAttackSpeed = 20.0f;
	public static float iceLancerXpGain = 500.0f;
	public static float iceLancerHp = 30.0f;
	public static float iceLancerDamage = 110.0f;
	public static float iceLancerAggroDistance = 30.0f;
	public static float iceLancerAttackRange = 4.5f;
	public static float iceLancerDistanceToDisappear = 2.0f;

	// WALL        wall
	public static string wallName = "Wall" ;
	public static string wallAttackType = "DOT";
	public static float wallMovementSpeed = 0.0f;
	public static float wallAttackSpeed = 2.0f;
	public static float wallXpGain = 30.0f;
	public static float wallHp = 30.0f;
	public static float wallDamage = 40.0f;
	public static float wallAggroDistance = 30.0f;
	public static float wallAttackRange = 3.5f;
	public static float wallDistanceToDisappear = 2.0f;


	public void Init()
	{
		// Lire dans le fichier JSON

		// Hydrater les variables
	}
}
