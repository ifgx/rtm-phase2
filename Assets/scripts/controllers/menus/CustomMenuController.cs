using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Leap;

public class CustomMenuController : MonoBehaviour {

	public GameObject go;

	private static string customSong;
	string[] tmp;

	Button buttonSong;
	
	private static Text songText;
	
	GameObject browserMenu, canvas;
	LaunchFileBrowser launchBrowser;

	private static bool browser;
	
	// Use this for initialization
	void Start () {
		
		buttonSong = go.transform.Find("CustomGO/CustomCanvas/Song").GetComponentInChildren<Button>();
		
		songText = go.transform.Find ("CustomGO/CustomCanvas/PathSong").GetComponent<Text>();
		
		canvas = GameObject.Find("CustomGO/CustomCanvas");
		
		browserMenu = GameObject.Find("Browser");
		launchBrowser = (LaunchFileBrowser) GameObject.Find ("Browser").GetComponent(typeof(LaunchFileBrowser));
		browserMenu.SetActive(false);

		customSong = "";
		
		browser = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(launchBrowser.Select){
			customSong = launchBrowser.Output;
			tmp = customSong.Split('\\');
			songText.text = tmp[tmp.Length-1];
			browserMenu.SetActive(false);
			canvas.SetActive(true);
			launchBrowser.Select = false;
			browser = false;
		}
		
		if(launchBrowser.Cancel){
			browserMenu.SetActive(false);
			canvas.SetActive(true);
			launchBrowser.Cancel = false;
			browser = false;
		}		
	}
	
	public void Browser(){
		browserMenu.SetActive(true);
		canvas.SetActive(false);
		browser = true;
	}
	
	public void Return() {
		MenuController.Animator.SetTrigger("customToMain");
	}

	public static bool LauncherBrowser {
		get {
			return browser;
		}

		set {
			browser = value;
		}
	}

	public static string Song {
		get {
			return songText.text;
		}

		set {
			songText.text = value;
		}
	}

	public static string CustomSong {
		get {
			return customSong;
		}

		set {
			customSong = value;
		}
	}
}
