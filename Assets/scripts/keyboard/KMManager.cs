using UnityEngine;
using System.Collections;

public class KMManager : MonoBehaviour {

	GameObject leftHand;
	GameObject rightHand;

	float movSpeed = 0.2f;
	// Use this for initialization
	void Start () {
		GameObject leftHandGO = Resources.Load ("prefabs/leapmotion/Warrior_RH_left") as GameObject;
		GameObject rightHandGO = Resources.Load ("prefabs/leapmotion/Warrior_RH_right") as GameObject;
		leftHand = Instantiate (leftHandGO);
		rightHand = Instantiate (rightHandGO);

//		Quaternion rot = rightHand.transform.rotation;
//		//rot.x = 90;
//		//rot.SetLookRotation (transform.forward);
//		rightHand.transform.rotation = rot;
//
//		Vector3 pos = rightHand.transform.position;
//		//pos.z = 7;
//		rightHand.transform.position = pos;


	}
	

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Z)) {
			leftHand.transform.Translate(new Vector3(0, movSpeed, 0));
		} else if (Input.GetKey (KeyCode.S)) {
			leftHand.transform.Translate(new Vector3(0, -movSpeed, 0));
		}

		if (Input.GetKey (KeyCode.Q)) {
			leftHand.transform.Translate(new Vector3(-movSpeed, 0, 0));
		} else if (Input.GetKey (KeyCode.D)) {
			leftHand.transform.Translate(new Vector3(movSpeed, 0, 0));

		}

		Vector3 v3 = Input.mousePosition;
		v3.z = 7;
		v3 = Camera.main.ScreenToWorldPoint (v3);

		rightHand.transform.position = v3;
	}
}
