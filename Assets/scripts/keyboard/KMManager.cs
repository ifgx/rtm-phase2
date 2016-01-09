﻿using UnityEngine;
using System.Collections;

public class KMManager : MonoBehaviour {

	GameObject leftHand;
	GameObject rightHand;

	GameObject fireballGO;
	GameObject fireball = null;
	GameObject vortexGO;
	GameObject vortex = null;

	Camera cam = null;

	float swordMovTime = 0;
	float shieldMovTime = 0;

	int swordMov = 0;

	float mouseSpeed = 100f;

	string heroClass = "Warrior";

	float movSpeed = 0.05f;

	float screenBoundRatioFactor = 640;
	float screenBoundX;

	Vector3 UP;
	Vector3 DOWN;
	Vector3 LEFT;
	Vector3 RIGHT;


	public void setCamera(Camera camera) {
		this.cam = camera;

	}


	// Use this for initialization
	void Start () {

		GameObject leftHandGO = null;
		GameObject rightHandGO = null;
		if (heroClass == "Warrior") {
			leftHandGO = Resources.Load ("prefabs/leapmotion/Warrior_RH_left") as GameObject;
			rightHandGO = Resources.Load ("prefabs/leapmotion/Warrior_RH_right") as GameObject;

			UP = new Vector3 (0, 1, 0);
			DOWN = new Vector3 (0, -1, 0);
			RIGHT = new Vector3(-1, 0, 0);
			LEFT = new Vector3(1, 0, 0);

		} else if (heroClass == "Wizard"){
			leftHandGO = Resources.Load ("prefabs/leapmotion/Wizard_RH_left") as GameObject;
			rightHandGO = Resources.Load ("prefabs/leapmotion/Wizard_RH_right") as GameObject;

			UP = new Vector3 (0, 1, 0);
			DOWN = new Vector3 (0, -1, 0);
			RIGHT = new Vector3(0, 0, 1);
			LEFT = new Vector3(0, 0, -1);

		}

		fireballGO = Resources.Load ("prefabs/leapmotion/Fireball") as GameObject;

		vortexGO = Resources.Load ("prefabs/leapmotion/Vortex") as GameObject;

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

		if (cam == null)
			cam = cam;

		screenBoundX = cam.pixelWidth / screenBoundRatioFactor;
		leftHand.transform.localScale = new Vector3 (2, 2, 2);
		leftHand.transform.parent = cam.transform;
		rightHand.transform.localScale = new Vector3 (2, 2, 2);
		rightHand.transform.parent = cam.transform;
	}
	

	// Update is called once per frame
	void Update () {

		updatePosition ();

		if (heroClass == "Warrior") {
			WarriorUpdate ();
		} else if (heroClass == "Wizard") {
			WizardUpdate ();
		}



	}

	private void updatePosition() {
		if (Input.GetKey (KeyCode.Z)) {
			leftHand.transform.Translate(movSpeed*UP);
		} else if (Input.GetKey (KeyCode.S)) {
			leftHand.transform.Translate(movSpeed*DOWN);
		}
		//Debug.Log (leftHand.transform.position.x + " | " + screenBoundX);
		if (Input.GetKey (KeyCode.Q) && leftHand.transform.position.x > -screenBoundX) {
			leftHand.transform.Translate(movSpeed*RIGHT);
		} else if (Input.GetKey (KeyCode.D) && leftHand.transform.position.x < screenBoundX) {
			leftHand.transform.Translate(movSpeed*LEFT);
		}

		Vector3 v3 = Input.mousePosition;
		v3.z = 2;
		v3 = cam.ScreenToWorldPoint (v3);
		v3.z = rightHand.transform.position.z;
		
		rightHand.transform.position = v3;
	}

	private void WarriorUpdate(){

		
		if (Input.GetMouseButton (0) && swordMov == 0) {
			Debug.Log("mouse button down");
			swordMov = 1;
		}
		
		
		if (swordMov == 1) {
			
			Debug.Log("sword moving forward");
			//Debug.Log("1 - " + rightHand.transform.position);
			rightHand.transform.Translate(new Vector3(-0.4f,0,0));
			rightHand.transform.Rotate(new Vector3(0,4f,0));
			//Debug.Log("2 - " + rightHand.transform.position);
			
			swordMovTime += Time.deltaTime;
			
			if (swordMovTime >= 0.25) {
				swordMovTime = 0;
				swordMov = 2;
			}
		}else if (swordMov == 2) {
			Debug.Log("sword moving forward");
			//Debug.Log("1 - " + rightHand.transform.position);
			rightHand.transform.Rotate(new Vector3(0,-4f,0));
			rightHand.transform.Translate(new Vector3(0.4f,0,0));
			
			//Debug.Log("2 - " + rightHand.transform.position);
			
			swordMovTime += Time.deltaTime;
			
			if (swordMovTime >= 0.25) {
				swordMovTime = 0;
				swordMov = 0;
			}
		}

			
		
		if (Input.GetKey (KeyCode.Space)) {
			if (shieldMovTime < 0.25f){
				leftHand.transform.Translate(new Vector3(0,0,0.1f));
				shieldMovTime += Time.deltaTime;
			}else{
				shieldMovTime = 0.25f;
			}
		} else {
			if (shieldMovTime > 0) {
				leftHand.transform.Translate(new Vector3(0,0,-0.1f));
				shieldMovTime -= Time.deltaTime;
			}else{
				shieldMovTime = 0;
			}
		}
	}

	private void WizardUpdate() {
		Debug.Log (leftHand.transform.position);
		//Debug.Log (cam.pixelWidth + " -- " + cam.pixelHeight);



		if (Input.GetMouseButton (0) && fireball == null) {
			Debug.Log ("mouse button down");

			fireball = Instantiate (fireballGO);
			fireball.GetComponentInChildren<HeroLinkWeapon> ().Hero = new Wizard ();
			
			fireball.transform.parent = rightHand.transform.FindChild ("HandContainer").transform;
			fireball.transform.localPosition = new Vector3 (0f, 0.05f, 0f);
		} else if (!Input.GetMouseButton (0) && fireball != null){
		
			fireball.transform.parent = null;
			fireball.GetComponentInChildren<CapsuleCollider>().enabled = true;
			fireball.GetComponent<Rigidbody>().isKinematic = false;
		}



		


		if (Input.GetKey(KeyCode.Space) && vortex == null) {
			vortex = Instantiate(vortexGO);
			
			vortex.transform.parent = leftHand.transform.FindChild("HandContainer").transform;
			vortex.transform.localPosition = new Vector3(0f, 0f, 0f);
			
		}else if (!Input.GetKey(KeyCode.Space) && vortex != null) {

			vortex.transform.parent = cam.transform; //attach to camera
			//vortex.transform.localPosition = new Vector3(0f, 0.3f, 1.5f);
			
			vortex.GetComponent<VortexController>().isDropped();
			
			vortex.GetComponentInChildren<CapsuleCollider>().enabled = true;
			//it is dropped so the size is bigger
			vortex.GetComponent<ParticleSystem>().startSize = 0.8f;
		}
	}
}
