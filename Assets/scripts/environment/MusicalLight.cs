﻿using UnityEngine;
using System.Collections;

public class MusicalLight : MonoBehaviour, AudioProcessor.AudioCallbacks {

	private AudioProcessor processor;
	private bool initialized = false;
	private Light light;
	// Use this for initialization
	void Start () {
		light = GetComponent<Light>();
		processor = FindObjectOfType<AudioProcessor>();
	}
	void init(){
		
		processor.addAudioCallback(this);
		initialized = true;
	}
	// Update is called once per frame
	void Update () {
		if (processor != null) {
			if (processor.start) {
				if (!initialized) {
					init ();
				}
			}
		}
		if (GameModel.HerosInGame [0].GetPosition ().z > transform.position.z)
			Destroy (this.gameObject);
	}

	public void onOnbeatDetected()
	{
		//Debug.Log("Beat!!!");
		light.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1.0f);
	}
	public void onSpectrum(float[] spectrum)
	{
	}

	void OnDestroy() {
		if (processor != null) {
			processor.removeAudioCallback (this);
		}
	}
}
