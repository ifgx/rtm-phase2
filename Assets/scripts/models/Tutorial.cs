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
		if (name == "Lancer" && !GameModel.ListTutoriel.Contains("Lancer")) {
			
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

		} else if (name == "fire" && !GameModel.ListTutoriel.Contains("Fire")) {

			NPC npc = GameModel.getNearestNPC ();
			if(npc != null && npc.GetType().ToString().Contains("Fire") && npc.GetPosition().z-GameModel.HerosInGame[0].GetPosition().z < distTrigger){
				GameModel.ListTutoriel.Add("fire");
				return true;
			}
			return false;
		
		} else if (name == "ice" && !GameModel.ListTutoriel.Contains("Ice")) {

			NPC npc = GameModel.getNearestNPC ();
			if(npc != null && npc.GetType().ToString().Contains("Ice") && npc.GetPosition().z-GameModel.HerosInGame[0].GetPosition().z < distTrigger){
				GameModel.ListTutoriel.Add("ice");
				return true;
			}
			return false;

		} else {
			return false;
		}
	}
}
