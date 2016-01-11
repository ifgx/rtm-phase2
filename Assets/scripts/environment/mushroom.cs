using UnityEngine;
using System.Collections;

public class mushroom : MonoBehaviour, AudioProcessor.AudioCallbacks {

	private AudioProcessor processor;
	private bool initialized = false;

	private int danceMove = 0;
	// Use this for initialization
	void Start () {
		processor = FindObjectOfType<AudioProcessor>();
		//processor.init ();
	}
	
	// Update is called once per frame
	void Update () {
		if (processor.start) {
			if (!initialized){
				init();
			}else{
				dance();
			}
		}

	}

	private void init (){

		processor.addAudioCallback (this);
		initialized = true;
	}
	
	private void dance() {
		switch (danceMove) {
			case 0:
				transform.localScale = new Vector3(1,1,1);
				break;
			case 1:
				transform.localScale = new Vector3(2,2,2);
				break;
			default:
				break;
		}
	}

	public void onOnbeatDetected()
	{
		Debug.LogWarning("Beat!!!");
		danceMove = (danceMove + 1) % 2;

	}

	public void onSpectrum(float[] spectrum)
	{

	}
}
