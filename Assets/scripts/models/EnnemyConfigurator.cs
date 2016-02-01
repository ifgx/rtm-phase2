using UnityEngine;
using System.Collections;
using SimpleJSON;
using System.IO; //pour StreamReader

public class EnnemyConfigurator : MonoBehaviour {
	// GENERAL
	public static float maxMusicSpeedFactor = 5.0f;
	public static float minMusicSpeedFactor = 1.0f;
	
	// ASSASSIN    assassin
	public static string assassinName;
	public static string assassinAttackType;
	public static float assassinMovementSpeed;
	public static float assassinAttackSpeed;
	public static float assassinXpGain;
	public static float assassinHp;
	public static float assassinDamage;
	public static float assassinAggroDistance;
	public static float assassinAttackRange;
	public static float assassinDistanceToDisappear;

	// CANNON   cannon
	public static string cannonName;
	public static string cannonAttackType;
	public static float cannonMovementSpeed;
	public static float cannonAttackSpeed;
	public static float cannonXpGain;
	public static float cannonHp;
	public static float cannonDamage;

	public static float cannonAggroDistance;
	public static float cannonAttackRange;
	public static float cannonDistanceToDisappear;


	public static float cannonRotationSpeed;
	public static float cannonMinAttackRange;

	// BASIC_DRAGONET     basicDragonet
	public static string basicDragonetName;
	public static string basicDragonetAttackType;
	public static float basicDragonetMovementSpeed;
	public static float basicDragonetAttackSpeed;
	public static float basicDragonetXpGain;
	public static float basicDragonetHp;
	public static float basicDragonetDamage;
	public static float basicDragonetAggroDistance;
	public static float basicDragonetAttackRange;
	public static float basicDragonetDistanceToDisappear;

	// FIRE_DRAGONET     fireDragonet
	public static string fireDragonetName;
	public static string fireDragonetAttackType;
	public static float fireDragonetMovementSpeed;
	public static float fireDragonetAttackSpeed;
	public static float fireDragonetXpGain;
	public static float fireDragonetHp;
	public static float fireDragonetDamage;
	public static float fireDragonetAggroDistance;
	public static float fireDragonetAttackRange;
	public static float fireDragonetDistanceToDisappear;

	// ICE_DRAGONET     iceDragonet
	public static string iceDragonetName;
	public static string iceDragonetAttackType;
	public static float iceDragonetMovementSpeed;
	public static float iceDragonetAttackSpeed;
	public static float iceDragonetXpGain;
	public static float iceDragonetHp;
	public static float iceDragonetDamage;
	public static float iceDragonetAggroDistance;
	public static float iceDragonetAttackRange;
	public static float iceDragonetDistanceToDisappear;

	// BASIC_LANCER     basicLancer
	public static string basicLancerName;
	public static string basicLancerAttackType;
	public static float basicLancerMovementSpeed;
	public static float basicLancerAttackSpeed;
	public static float basicLancerXpGain;
	public static float basicLancerHp;
	public static float basicLancerDamage;
	public static float basicLancerAggroDistance;
	public static float basicLancerAttackRange;
	public static float basicLancerDistanceToDisappear;

	// FIRE_LANCER      fireLancer
	public static string fireLancerName;
	public static string fireLancerAttackType;
	public static float fireLancerMovementSpeed;
	public static float fireLancerAttackSpeed;
	public static float fireLancerXpGain;
	public static float fireLancerHp;
	public static float fireLancerDamage;
	public static float fireLancerAggroDistance;
	public static float fireLancerAttackRange;
	public static float fireLancerDistanceToDisappear;

	// ICE_LANCER      iceLancer
	public static string iceLancerName;
	public static string iceLancerAttackType;
	public static float iceLancerMovementSpeed;
	public static float iceLancerAttackSpeed;
	public static float iceLancerXpGain;
	public static float iceLancerHp;
	public static float iceLancerDamage;
	public static float iceLancerAggroDistance;
	public static float iceLancerAttackRange;
	public static float iceLancerDistanceToDisappear;

	// WALL        wall
	public static string wallName;
	public static string wallAttackType;
	public static float wallMovementSpeed;
	public static float wallAttackSpeed;
	public static float wallXpGain;
	public static float wallHp;
	public static float wallDamage;
	public static float wallAggroDistance;
	public static float wallAttackRange;
	public static float wallDistanceToDisappear;

	static string conf;



	public static void Init()
	{
		// Lire dans le fichier JSON

		// Hydrater les variables

		JSONNode root = getJsonFile ("Config/Ennemy.JSON");

		assassinName = root["assassinName"];
		assassinAttackType = root["assassinAttackType"];
		assassinMovementSpeed = root["assassinMovementSpeed"].AsFloat;
		assassinAttackSpeed = root["assassinAttackSpeed"].AsFloat;
		assassinXpGain = root["assassinXpGain"].AsFloat;
		assassinHp = root["assassinHp"].AsFloat;
		assassinDamage = root["assassinDamage"].AsFloat;
		assassinAggroDistance = root["assassinAggroDistance"].AsFloat;
		assassinAttackRange = root["assassinAttackRange"].AsFloat;
		assassinDistanceToDisappear = root["assassinDistanceToDisappear"].AsFloat;

		cannonName = root["cannonName"];
		cannonAttackType = root["cannonAttackType"];
		cannonMovementSpeed = root["cannonMovementSpeed"].AsFloat;
		cannonAttackSpeed = root["cannonAttackSpeed"].AsFloat;
		cannonXpGain = root["cannonXpGain"].AsFloat;
		cannonHp = root["cannonHp"].AsFloat;
		cannonDamage = root["cannonDamage"].AsFloat;
		cannonAggroDistance = root["cannonAggroDistance"].AsFloat;
		cannonAttackRange = root["cannonAttackRange"].AsFloat;
		cannonDistanceToDisappear = root["cannonDistanceToDisappear"].AsFloat;
		cannonRotationSpeed = root["cannonRotationSpeed"].AsFloat;
		cannonMinAttackRange = root["cannonMinAttackRange"].AsFloat;

		basicDragonetName = root["basicDragonetName"];
		basicDragonetAttackType = root["basicDragonetAttackType"];
		basicDragonetMovementSpeed = root["basicDragonetMovementSpeed"].AsFloat;
		basicDragonetAttackSpeed = root["basicDragonetAttackSpeed"].AsFloat;
		basicDragonetXpGain = root["basicDragonetXpGain"].AsFloat;
		basicDragonetHp = root["basicDragonetHp"].AsFloat;
		basicDragonetDamage = root["basicDragonetDamage"].AsFloat;
		basicDragonetAggroDistance = root["basicDragonetAggroDistance"].AsFloat;
		basicDragonetAttackRange = root["basicDragonetAttackRange"].AsFloat;
		basicDragonetDistanceToDisappear = root["basicDragonetDistanceToDisappear"].AsFloat;

		fireDragonetName = root["fireDragonetName"];
		fireDragonetAttackType = root["fireDragonetAttackType"];
		fireDragonetMovementSpeed = root["fireDragonetMovementSpeed"].AsFloat;
		fireDragonetAttackSpeed = root["fireDragonetAttackSpeed"].AsFloat;
		fireDragonetXpGain = root["fireDragonetXpGain"].AsFloat;
		fireDragonetHp = root["fireDragonetHp"].AsFloat;
		fireDragonetDamage = root["fireDragonetDamage"].AsFloat;
		fireDragonetAggroDistance = root["fireDragonetAggroDistance"].AsFloat;
		fireDragonetAttackRange = root["fireDragonetAttackRange"].AsFloat;
		fireDragonetDistanceToDisappear = root["fireDragonetDistanceToDisappear"].AsFloat;

		iceDragonetName = root["iceDragonetName"];
		iceDragonetAttackType = root["iceDragonetAttackType"];
		iceDragonetMovementSpeed = root["iceDragonetMovementSpeed"].AsFloat;
		iceDragonetAttackSpeed = root["iceDragonetAttackSpeed"].AsFloat;
		iceDragonetXpGain = root["iceDragonetXpGain"].AsFloat;
		iceDragonetHp = root["iceDragonetHp"].AsFloat;
		iceDragonetDamage = root["iceDragonetDamage"].AsFloat;
		iceDragonetAggroDistance = root["iceDragonetAggroDistance"].AsFloat;
		iceDragonetAttackRange = root["iceDragonetAttackRange"].AsFloat;
		iceDragonetDistanceToDisappear = root["iceDragonetDistanceToDisappear"].AsFloat;

		basicLancerName = root["basicLancerName"];
		basicLancerAttackType = root["basicLancerAttackType"];
		basicLancerMovementSpeed = root["basicLancerMovementSpeed"].AsFloat;
		basicLancerAttackSpeed = root["basicLancerAttackSpeed"].AsFloat;
		basicLancerXpGain = root["basicLancerXpGain"].AsFloat;
		basicLancerHp = root["basicLancerHp"].AsFloat;
		basicLancerDamage = root["basicLancerDamage"].AsFloat;
		basicLancerAggroDistance = root["basicLancerAggroDistance"].AsFloat;
		basicLancerAttackRange = root["basicLancerAttackRange"].AsFloat;
		basicLancerDistanceToDisappear = root["basicLancerDistanceToDisappear"].AsFloat;

		fireLancerName = root["fireLancerName"];
		fireLancerAttackType = root["fireLancerAttackType"];
		fireLancerMovementSpeed = root["fireLancerMovementSpeed"].AsFloat;
		fireLancerAttackSpeed = root["fireLancerAttackSpeed"].AsFloat;
		fireLancerXpGain = root["fireLancerXpGain"].AsFloat;
		fireLancerHp = root["fireLancerHp"].AsFloat;
		fireLancerDamage = root["fireLancerDamage"].AsFloat;
		fireLancerAggroDistance = root["fireLancerAggroDistance"].AsFloat;
		fireLancerAttackRange = root["fireLancerAttackRange"].AsFloat;
		fireLancerDistanceToDisappear = root["fireLancerDistanceToDisappear"].AsFloat;

		iceLancerName = root["iceLancerName"];
		iceLancerAttackType = root["iceLancerAttackType"];
		iceLancerMovementSpeed = root["iceLancerMovementSpeed"].AsFloat;
		iceLancerAttackSpeed = root["iceLancerAttackSpeed"].AsFloat;
		iceLancerXpGain = root["iceLancerXpGain"].AsFloat;
		iceLancerHp = root["iceLancerHp"].AsFloat;
		iceLancerDamage = root["iceLancerDamage"].AsFloat;
		iceLancerAggroDistance = root["iceLancerAggroDistance"].AsFloat;
		iceLancerAttackRange = root["iceLancerAttackRange"].AsFloat;
		iceLancerDistanceToDisappear = root["iceLancerDistanceToDisappear"].AsFloat;

		wallName = root["wallName"];
		wallAttackType = root["wallAttackType"];
		wallMovementSpeed = root["wallMovementSpeed"].AsFloat;
		wallAttackSpeed = root["wallAttackSpeed"].AsFloat;
		wallXpGain = root["wallXpGain"].AsFloat;
		wallHp = root["wallHp"].AsFloat;
		wallDamage = root["wallDamage"].AsFloat;
		wallAggroDistance = root["wallAggroDistance"].AsFloat;
		wallAttackRange = root["wallAttackRange"].AsFloat;
		wallDistanceToDisappear = root["wallDistanceToDisappear"].AsFloat;
	}

	private static JSONNode getJsonFile(string path){
		StreamReader r = new StreamReader (path); // access the json file
		string json = r.ReadToEnd (); // convert its content to a string 

		r.Close();

		return JSON.Parse(json); // return the content as a JSONNode
	}
}
