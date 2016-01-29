using UnityEngine;
using System.Collections;

public class PauseCanvasController : MonoBehaviour {

	AudioSource audioSource;
	AudioClip soundClosing;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		soundClosing = Resources.Load("sounds/pop-up-close") as AudioClip;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDisable() {
		print("script was removed");
		audioSource.PlayOneShot(soundClosing);
	}
}
