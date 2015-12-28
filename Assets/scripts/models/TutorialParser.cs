using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using System.IO; //pour StreamReader

public class TutorialParser : MonoBehaviour {

	static List<Tutorial> tutorials;
	static JSONArray slots;

	public static List<Tutorial> parseTutorials(){
		tutorials = new List<Tutorial> ();

		JSONNode root = getJsonFile ("Saves/tuto.json");
		
		slots = root ["tuto"].AsArray;

		int size = slots.Count;

		for (int i=0; i<size; i++) {
			
			string name = slots[i]["name"];
			string type = slots[i]["type"];
			string desc = slots[i]["desc"];
			string attack = slots[i]["attack"];
			string title = slots[i]["title"];
			
			tutorials.Add(new Tutorial(name, type, title, desc, attack));
		}
		return tutorials;
	}

	private static JSONNode getJsonFile(string path){
		StreamReader r = new StreamReader (path); // access the json file
		string json = r.ReadToEnd (); // convert its content to a string 
		
		r.Close();
		
		return JSON.Parse(json); // return the content as a JSONNode
	}
}
