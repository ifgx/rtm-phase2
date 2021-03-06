﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * @author Adrien D
 * @version 1.0
 */

/**
 * This class is made to keep the context between controllers
 */
public class GameModel {

	/**
	 * The hero : mainly to keep the class and XP
	 */
	private static Hero hero;

	private static List<Hero> heros;

	private static List<Hero> herosInGame;

	private static List<Hero> herosSaved;

	private static List<NPC> npcsInGame;

	private static List<Potion> potionsInGame;

	private static Level actualLevel;

	private static List<Level> levels;

	private static int actualLevelId;

	private static List<Save> saves;

	private static bool customLevel;

	private static bool playWithLeap;

	private static List<HighScore> highScores;

	private static int score;

	private static int slot;

	private static bool playWithTuto;

	private static bool onSandBox;
		
	private static List<string> listTutoriel; // permet de prendre en compte les tuto déja passé


	public static int Slot {
		get {
			return slot;
		}
		
		set {
			slot = value;
		}
	}

	public static int Score {
		get {
			return score;
		}
		
		set {
			score = value;
		}
	}

	public static Hero Hero {
		get {
			return hero;
		}

		set {
			hero = value;
		}
	}

	public static List<Hero> Heros {
		get {
			return heros;
		}
		
		set {
			heros = value;
		}
	}

	public static List<Hero> HerosInGame {
		get {
			return herosInGame;
		}
		
		set {
			herosInGame = value;
		}
	}

	public static List<Hero> HerosSaved {
		get {
			return herosSaved;
		}
		
		set {
			herosSaved = value;
		}
	}

	public static List<string> ListTutoriel {
		get {
			return listTutoriel;
		}

		set {
			listTutoriel = value;
		}
	}

	public static List<NPC> NPCsInGame {
		get {
			return npcsInGame;
		}
		
		set {
			npcsInGame = value;
		}
	}

	public static List<Potion> PotionsInGame {
		get {
			return potionsInGame;
		}

		set {
			potionsInGame = value;
		}
	}

	public static Level ActualLevel {
		get {
			return actualLevel;
		}
		
		set {
			actualLevel = value;
		}
	}

	public static int ActualLevelId {
		get {
			return actualLevelId;
		}
		
		set {
			if (value >= 0 && value < levels.Count){
				actualLevelId = value;
				actualLevel = levels[actualLevelId];
			}
		}
	}

	public static bool goToFirstLevel() {
		actualLevelId = -1;
		return goToNextLevel();
	}

	public static bool goToNextLevel() {
		if (actualLevelId+1 >= levels.Count) {
			return false;
		}else{
			while (actualLevelId+1 < levels.Count) {
				ActualLevelId ++;
				//Debug.Log("level : " + ActualLevel.Name);
				if (ActualLevel.Tutorial == playWithTuto){
					return true;
				}
			}
			return false;
		}

	}

	public static List<Level> Levels {
		get {
			return levels;
		}
		
		set {
			levels = value;
		}
	}

	public static int getLevelIdByName(string name){
		int res = -1;

		int size = levels.Count;
		for (int i=0; i<size; i++) {
			if (levels[i].Name == name){
				res = i;
				break;
			}
		}
		return res;
	}

	public static List<Save> Saves {
		get {
			return saves;
		}
		
		set {
			saves = value;
		}
	}

	public static List<HighScore> HighScores {
		get {
			return highScores;
		}
		
		set {
			highScores = value;
		}
	}

	public static Potion getNearestPotion(){
		Potion res = null;

		foreach (Potion p in potionsInGame) {
			
			if (res == null || p.GetPosition().z < res.GetPosition().z) res = p;
		}

		return res;
	}

	public static NPC getNearestNPC(){
		NPC res = null;

		foreach (NPC npc in npcsInGame) {
			if (res == null || npc.GetPosition().z < res.GetPosition().z) res = npc;	
		}

		return res;
	}

	/**
	 * Initialisation of the game model
	 */
	public static void Init(){

		//Debug.Log ("INIT !!!!!!");
		levels = LevelParser.parseAllLevelFiles ("LvlList");

		/*foreach (Level level in levels) {
			//Debug.Log(level.Tutorial);
		}*/

		ActualLevelId = 0;
		
		herosInGame = new List<Hero> ();

		heros = new List<Hero> ();

		playWithTuto=false;	
		//create saves
		saves = SaveParser.parseLevelFile ();

		highScores = HighScoreParser.parseHighScoreFile();

		score = 0;

		playWithLeap = false; // POUR TESTS AVEC LE TUTORIEL

		TutorialManagerController.tutorials = new List<Tutorial> ();
		listTutoriel = new List<string>();

		onSandBox = false;
	}

	public static void resetDataBeforeLevel(){
		npcsInGame = new List<NPC> ();
		potionsInGame = new List<Potion>();
	}

	public static void loadSave(int saveNum){
		saves = SaveParser.parseLevelFile ();
		Save save = saves [saveNum];
		//Debug.LogError("To Load:"+save.Hero.Name+" ,XP:"+save.Hero.XpQuantity);
		hero = save.Hero;
		score = save.Score;
		ActualLevelId = save.LevelId;
	}

	public static void initSandbox() {
		herosInGame = new List<Hero> ();
		npcsInGame = new List<NPC> ();
		potionsInGame = new List<Potion>();
	}
	
	public static void resetSaveSlot(int slot){
		Slot = slot;
		//Debug.LogError("ON RESET:"+Hero.XpQuantity);
		if (saves.Count < 3) {
			saves.Add (new Save (Hero, ActualLevelId, Score));
			SaveParser.addSave(slot, Hero, Score, ActualLevelId);			
		} else {
			Save save = saves [slot];
			save.Hero = Hero;
			save.LevelId = ActualLevelId;
			save.Score = Score;
			SaveParser.addSave(slot, Hero, Score, ActualLevelId);			
		}
	}

	public static bool CustomLevel {
		get {
			return customLevel;
		}
		set {
			customLevel = value;
		}
	}

	/**
	 * Return true if heros count is 2
	 * or false if heros is null
	 */
	public static bool MultiplayerModeOn {
		get {

			if (heros == null)
			{ 
				return false;
			}
			else
			{
				return (heros.Count == 2);
			}

		}

	}


	public static bool PlayWithLeap {
		get {
			return playWithLeap;
		}
		set {
			playWithLeap = value;
		}
	}

	public static bool PlayWithTuto {
		get {
			return playWithTuto;
		}
		set {
			playWithTuto = value;
		}
	}

	public static bool OnSandBox {
		get {
			return onSandBox;
		}
		set {
			onSandBox = value;
		}
	}


	
}
