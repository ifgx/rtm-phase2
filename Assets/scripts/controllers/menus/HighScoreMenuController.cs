using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class HighScoreMenuController : MonoBehaviour {

	GameObject panel;
	RectTransform panelRect;
	float posY;

	// Use this for initialization
	void Start () {

		panel = GameObject.Find("PanelText");
		panelRect = panel.GetComponent<RectTransform>();

		checkHighScore ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Return(){
		Application.LoadLevel ("Main_menu");
	}

	void checkHighScore() {
		List<HighScore> highScores = GameModel.HighScores;

		posY = 150f;

		for (int i = 0; i < highScores.Count; i++) {
			int pos = i+1;
			//GUIText text = new GUIText();
			//RectTransform rect = new RectTransform();
			GameObject tmp = new GameObject("Text_"+pos.ToString());

			tmp.AddComponent<Text>();
			Text text = tmp.GetComponent<Text>();
			RectTransform rect = tmp.GetComponent<RectTransform>();
			tmp.layer = 5;

			tmp.transform.parent = panel.transform;

			rect.sizeDelta = new Vector2(250, 30);
			rect.localPosition = new Vector3(-8.5f, posY, 0.0f);
			//rect.position = new Vector3(-8.5f, 152.4f, 0.0f);

			text.text = pos.ToString()+"\tName : "+highScores[i].Name+"\t\tScore : "+highScores[i].Score;
			text.fontSize = 18;
			text.font = Resources.Load("fonts/augusta") as Font;
			text.color = Color.black;
			text.alignment = TextAnchor.MiddleLeft;

			posY -= 33.0f;

		}
	}
}
