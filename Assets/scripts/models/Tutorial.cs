using UnityEngine;
using System.Collections;

public class Tutorial {

	private float distTrigger = 20.0f;
	private float distPotion = 5.0f;

	private string text;
	private string imagePath;
	private bool played;
	private string name;
	private string attack;
	private string title;

	public Tutorial(string name, string imagePath, string title, string text, string attack) {
		this.text = text;
		this.imagePath = imagePath;
		this.name = name;
		this.attack = attack;
		this.title = title;
	}

	public string Text {
		get {
			return this.text;
		}

		set {
			this.text = value;
		}
	}

	public string Title {
		get {
			return this.title;
		}
		
		set {
			this.title = value;
		}
	}

	public string ImagePath {
		get {
			return this.imagePath;
		}
		
		set {
			this.imagePath = value;
		}
	}

	public bool Played {
		get {
			return this.played;
		}

		set {
			this.played = value;
		}
	}

	public string Attack {
		get {
			return this.attack;
		}
		
		set {
			this.attack = value;
		}
	}

	public string Name {
		get {
			return this.name;
		}
		
		set {
			this.name = value;
		}
	}

	public bool requestTrigger(){
		if (name == "onPop"  && !GameModel.ListTutoriel.Contains("onPop")) {
			
			if(GameModel.HerosInGame [0].GetPosition ().z >= 5.0f) {
				GameModel.ListTutoriel.Add("onPop");
				return true;
			}
			return false;

		} else if (name == "leapMotion" && !GameModel.ListTutoriel.Contains("leapMotion")) {

			if(GameModel.HerosInGame [0].GetPosition ().z >= 7.0f && GameModel.PlayWithLeap == true) {
				GameModel.ListTutoriel.Add("leapMotion");
				return true;
			}
			return false;

		} else if (name == "keyboard" && !GameModel.ListTutoriel.Contains("keyboard")) {

			if(GameModel.HerosInGame [0].GetPosition ().z >= 8.0f && GameModel.PlayWithLeap == false){
				GameModel.ListTutoriel.Add("keyboard");
				return true;
			}
			return false;

		} else if (name == "warriorAttackLeap" && !GameModel.ListTutoriel.Contains("warriorAttackLeap")) {

			if(GameModel.HerosInGame [0].GetPosition ().z >= 10.0f && GameModel.HerosInGame[0].GetType().ToString() == "Warrior" && GameModel.PlayWithLeap == true) {
				GameModel.ListTutoriel.Add("warriorAttaLeap");
				return true;
			}
			return false;

		} else if (name == "warriorDefenceLeap" && !GameModel.ListTutoriel.Contains("warriorDefenceLeap")) {

			if (GameModel.HerosInGame [0].GetPosition ().z >= 15.0f && GameModel.HerosInGame[0].GetType().ToString() == "Warrior" && GameModel.PlayWithLeap == true){
				GameModel.ListTutoriel.Add("warriorDefenceLeap");
				return true;
			}
			return false;

		} else if (name == "wizardAttackLeap" && !GameModel.ListTutoriel.Contains("wizardAttackLeap")) {

			if(GameModel.HerosInGame [0].GetPosition ().z >= 10.0f && GameModel.HerosInGame[0].GetType().ToString() == "Wizard" && GameModel.PlayWithLeap == true){
				GameModel.ListTutoriel.Add("wizardAttackLeap");
				return true;
			}
			return false;

		} else if (name == "wizardDefenceLeap" && !GameModel.ListTutoriel.Contains("wizardDefenceLeap")) {

			if(GameModel.HerosInGame [0].GetPosition ().z >= 15.0f && GameModel.HerosInGame[0].GetType().ToString() == "Wizard" && GameModel.PlayWithLeap == true){
				GameModel.ListTutoriel.Add("wizardDefenceLeap");
				return true;
			}
			return false;

		} else if (name == "monkAttackLeap" && !GameModel.ListTutoriel.Contains("monkAttackLeap")) {

			if(GameModel.HerosInGame [0].GetPosition ().z >= 10.0f && GameModel.HerosInGame[0].GetType().ToString() == "Monk" && GameModel.PlayWithLeap == true){
				GameModel.ListTutoriel.Add("monkAttackLeap");
				return true;
			}
			return false;

		} else if (name == "monkDefenceLeap" && !GameModel.ListTutoriel.Contains("monkDefenceLeap")) {

			if(GameModel.HerosInGame [0].GetPosition ().z >= 15.0f && GameModel.HerosInGame[0].GetType().ToString() == "Monk" && GameModel.PlayWithLeap == true){
				GameModel.ListTutoriel.Add("monkDefenceLeap");
				return true;
			}
			return false;

		} else if (name == "warriorAttackKeyboard" && !GameModel.ListTutoriel.Contains("warriorAttackKeyboard")) {

			if(GameModel.HerosInGame [0].GetPosition ().z >= 10.0f && GameModel.HerosInGame[0].GetType().ToString() == "Warrior" && GameModel.PlayWithLeap == false){
				GameModel.ListTutoriel.Add("warriorAttackKeyboard");
				return true;
			}
			return false;

		} else if (name == "warriorDefenceKeyboard" && !GameModel.ListTutoriel.Contains("warriorDefenceKeyboard")) {

			if(GameModel.HerosInGame [0].GetPosition ().z >= 15.0f && GameModel.HerosInGame[0].GetType().ToString() == "Warrior" && GameModel.PlayWithLeap == false){
				GameModel.ListTutoriel.Add("warriorDefenceKeyboard");
				return true;
			}
			return false;

		} else if (name == "wizardAttackKeyboard" && !GameModel.ListTutoriel.Contains("wizardAttackKeyboard")) {

			if(GameModel.HerosInGame [0].GetPosition ().z >= 10.0f && GameModel.HerosInGame[0].GetType().ToString() == "Wizard" && GameModel.PlayWithLeap == false){
				GameModel.ListTutoriel.Add("wizardAttackKeyboard");
				return true;
			}
			return false;

		} else if (name == "wizardDefenceKeyboard" && !GameModel.ListTutoriel.Contains("wizardDefenceKeyboard")) {

			if(GameModel.HerosInGame [0].GetPosition ().z >= 15.0f && GameModel.HerosInGame[0].GetType().ToString() == "Wizard" && GameModel.PlayWithLeap == false){
				GameModel.ListTutoriel.Add("wizardDefenceKeyboard");
				return true;
			}
			return false;

		} else if (name == "monkAttackKeyboard" && !GameModel.ListTutoriel.Contains("monkAttackKeyboard")) {

			if(GameModel.HerosInGame [0].GetPosition ().z >= 10.0f && GameModel.HerosInGame[0].GetType().ToString() == "Monk" && GameModel.PlayWithLeap == false){
				GameModel.ListTutoriel.Add("monkAttackKeyboard");
				return true;
			}
			return false;

		} else if (name == "monkDefenceKeyboard" && !GameModel.ListTutoriel.Contains("monkDefenceKeyboard")) {

			if(GameModel.HerosInGame [0].GetPosition ().z >= 15.0f && GameModel.HerosInGame[0].GetType().ToString() == "Monk" && GameModel.PlayWithLeap == false){
				GameModel.ListTutoriel.Add("monkDefenceKeyboard");
				return true;
			}
			return false;

		} else if (name == "Lancer" && !GameModel.ListTutoriel.Contains("Lancer")) {
			
			NPC npc = GameModel.getNearestNPC ();
			if (npc != null && npc.GetType().ToString().Contains("Lancer") && npc.GetPosition().z-GameModel.HerosInGame[0].GetPosition().z < distTrigger) {
				GameModel.ListTutoriel.Add("Lancer");
				return true;
			}
			return false;
		
		} else if (name == "Dragonet" && !GameModel.ListTutoriel.Contains("Dragonet")) {

			NPC npc = GameModel.getNearestNPC ();
			if(npc != null && npc.GetType().ToString().Contains("Dragonet") && npc.GetPosition().z-GameModel.HerosInGame[0].GetPosition().z < distTrigger){
				GameModel.ListTutoriel.Add("Dragonet");
				return true;
			}
			return false;

		} else if (name == "Assassin" && !GameModel.ListTutoriel.Contains("Assassin")) {

			NPC npc = GameModel.getNearestNPC ();
			if(npc != null && npc.GetType().ToString().Contains("Assassin") && npc.GetPosition().z-GameModel.HerosInGame[0].GetPosition().z < distTrigger){
				GameModel.ListTutoriel.Add("Assassin");
				return true;
			}
			return false;
		
		} else if (name == "Cannon" && !GameModel.ListTutoriel.Contains("Cannon")) {

			NPC npc = GameModel.getNearestNPC ();
			if(npc != null && npc.GetType().ToString().Contains("Cannon") && npc.GetPosition().z-GameModel.HerosInGame[0].GetPosition().z < distTrigger){
				GameModel.ListTutoriel.Add("Cannon");
				return true;
			}
			return false;
		
		} else if (name == "Wall" && !GameModel.ListTutoriel.Contains("Wall")) {

			NPC npc = GameModel.getNearestNPC ();
			if(npc != null && npc.GetType().ToString().Contains("Wall") && npc.GetPosition().z-GameModel.HerosInGame[0].GetPosition().z < distTrigger){
				GameModel.ListTutoriel.Add("Wall");
				return true;
			}
			return false;

		} else if (name == "LifePotion" && !GameModel.ListTutoriel.Contains("LifePotion")) {

			Potion p = GameModel.getNearestPotion();
			if(p != null && p.GetType().ToString().Contains("LifePotion") && p.GetPosition().z-GameModel.HerosInGame[0].GetPosition().z < distPotion){
				GameModel.ListTutoriel.Add("LifePotion");
				return true;
			}
			return false;
		
		} else if (name == "PowerPotion" && !GameModel.ListTutoriel.Contains("PowerPotion")) {

			Potion p = GameModel.getNearestPotion();
			if(p != null && p.GetType().ToString().Contains("PowerPotion") && p.GetPosition().z-GameModel.HerosInGame[0].GetPosition().z < distPotion){
				GameModel.ListTutoriel.Add("PowerPotion");
				return true;
			}
			return false;

		} else if (name == "InvincibilityPotion" && !GameModel.ListTutoriel.Contains("InvincibilityPotion")) {

			Potion p = GameModel.getNearestPotion();
			if(p != null && p.GetType().ToString().Contains("InvincibilityPotion") && p.GetPosition().z-GameModel.HerosInGame[0].GetPosition().z < distPotion){
				GameModel.ListTutoriel.Add("InvincibilityPotion");
				return true;
			}
			return false;

		} else if (name == "Fire" && !GameModel.ListTutoriel.Contains("Fire")) {

			NPC npc = GameModel.getNearestNPC ();
			if(npc != null && npc.GetType().ToString().Contains("Fire") && npc.GetPosition().z-GameModel.HerosInGame[0].GetPosition().z < distTrigger){
				GameModel.ListTutoriel.Add("Fire");
				return true;
			}
			return false;
		
		} else if (name == "Ice" && !GameModel.ListTutoriel.Contains("Ice")) {

			NPC npc = GameModel.getNearestNPC ();
			if(npc != null && npc.GetType().ToString().Contains("Ice") && npc.GetPosition().z-GameModel.HerosInGame[0].GetPosition().z < distTrigger){
				GameModel.ListTutoriel.Add("Ice");
				return true;
			}
			return false;

		} else {
			return false;
		}
	}
}
