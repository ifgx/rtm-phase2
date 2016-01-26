using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {
	private static Animator anim;

	AudioSource steel;
	AudioSource earth;

	bool steelBool;
	bool earthBool;

	// Use this for initialization
	void Start () {
		anim = GameObject.Find("Main Camera").GetComponent<Animator>();
		steel = GameObject.Find("AudioSource_steel").GetComponent<AudioSource>();
		earth = GameObject.Find("AudioSource_earth").GetComponent<AudioSource>();

		steelBool = false;
		earthBool = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static Animator Animator {
		get {
			return anim;
		}

		set {
			anim = value;
		}
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "TopConstraint") {
			if (!steelBool) {
				steel.Play();
				steelBool = true;
			}
		} else if (other.gameObject.tag == "BottomConstraint") {
			if(!earthBool) {
				earth.Play();
				earthBool = true;
			}
		}
	}
}
