using UnityEngine;
using System.Collections;

public class MusicalParticle : MonoBehaviour, AudioProcessor.AudioCallbacks {
	
	private AudioProcessor processor;
	private bool initialized = false;
	private ParticleSystem particleSys;
	private int switcher = 0;
	private int nbBeat = 0;
	// Use this for initialization
	void Start () {
		particleSys = GetComponent<ParticleSystem>();
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
		//nbBeat++;
		//Debug.Log("Beat!!!");
		//light.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1.0f);
		if (switcher == 0) {
			switcher = 1;
			particleSys.emissionRate = 30;
		} else {
			switcher = 0;
			particleSys.emissionRate = 0;
		}
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
