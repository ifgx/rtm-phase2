using UnityEngine;
using System.Collections;

public class mushroom : MonoBehaviour, AudioProcessor.AudioCallbacks {

	private AudioProcessor processor;
	private bool initialized = false;
	Animator animator;

	private int danceMove = Random.Range (0, 3);
	// Use this for initialization
	void Start () {
		processor = FindObjectOfType<AudioProcessor>();
		//processor.init ();
		animator = GetComponent<Animator> ();
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
			//De

	}

	private void init (){

		processor.addAudioCallback (this);
		initialized = true;
	}


	public void onOnbeatDetected()
	{
		//Debug.LogWarning("Beat!!!");
		danceMove = (danceMove + 1) % 3;
		if (danceMove == 2)
			animator.SetTrigger ("dance_trigger");

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
