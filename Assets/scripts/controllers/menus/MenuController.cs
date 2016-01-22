using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {
	private static Animator anim;

	// Use this for initialization
	void Start () {
		anim = GameObject.Find("Main Camera").GetComponent<Animator>();
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
}
