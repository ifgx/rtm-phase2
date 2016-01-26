using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class HighScoreMenuController : MonoBehaviour {

	public GameObject go;

	RectTransform panelRect;
	float posY;

	// Use this for initialization
	void Start () {

		panelRect = go.transform.Find("Canvas/Panel/PanelText").GetComponent<RectTransform>();

		checkHighScore ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Return(){
		//Application.LoadLevel ("Main_menu");
		MenuController.Animator.SetTrigger("highScoreToMain");
	}

	void checkHighScore() {
		List<HighScore> highScores = GameModel.HighScores;

		posY = 150f;

		for (int i = 0; i < 10; i++) {
			int pos = i+1;
			//GUIText text = new GUIText();
			//RectTransform rect = new RectTransform();
			GameObject tmp = new GameObject("Text_"+pos.ToString());

			tmp.AddComponent<Text>();
			Text text = tmp.GetComponent<Text>();
			RectTransform rect = tmp.GetComponent<RectTransform>();
			tmp.layer = 5;

			tmp.transform.parent = go.transform.Find("Canvas/Panel/PanelText").transform;

			rect.sizeDelta = new Vector2(250, 30);
			rect.localPosition = new Vector3(-8.5f, posY, 0.0f);
			rect.rotation = go.transform.Find("Canvas/Panel/PanelText").transform.rotation;
			rect.localScale = new Vector3(1, 1, 1);
			//rect.position = new Vector3(-8.5f, 152.4f, 0.0f);

			if(i < highScores.Count) {
				text.text = pos.ToString()+"\tName : "+highScores[i].Name+"\t\tScore : "+highScores[i].Score;
			} else {
				text.text = pos.ToString()+"\tEmpty";
			}
			text.fontSize = 18;
			text.font = Resources.Load("fonts/augusta") as Font;
			text.color = Color.black;
			text.alignment = TextAnchor.MiddleLeft;

			posY -= 33.0f;

		}
	}
}
