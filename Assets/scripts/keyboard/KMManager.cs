using UnityEngine;
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
	float staffMovTime = 0;
	
	int swordMov = 0;
	float swordRotateSpeed = 360;
	float swordTranslateSpeed = 10;
	float swordTranslateSpeed2 = 5;
	
	int staffMov = 0;
	float staffRotateSpeed1 = 150;
	float staffRotateSpeed2 = 200;
	float staffTranslateSpeedX1 = 10;
	float staffTranslateSpeedZ = 20;
	float staffTranslateSpeedX2 = 10;
	float staffTranslateSpeedX3 = 30;
	
	
	float shieldTranslateSpeed = 5;
	
	float mouseSpeed = 100f;
	
	Hero hero;
	string heroClass;
	
	float screenBoundX;
	float screenXFactor = 640;
	
	float screenBoundY;
	float screenYFactor = 640;
	float screenBoundYcenter;
	
	float movSpeed = 4f;
	
	
	Vector3 UP;
	Vector3 DOWN;
	Vector3 LEFT;
	Vector3 RIGHT;
	
	
	public void setCamera(Camera camera) {
		this.cam = camera;
		
	}
	
	public void setHero(Hero hero) {
		this.hero = hero;
		heroClass = hero.GetType ().ToString ();
	} 
	
	
	// Use this for initialization
	void Start () {
		
		if (cam == null)
			cam = Camera.main;
		
		GameObject leftHandGO = null;
		GameObject rightHandGO = null;
		if (heroClass == "Warrior") {
			leftHandGO = Resources.Load ("prefabs/leapmotion/Warrior_RH_left") as GameObject;
			rightHandGO = Resources.Load ("prefabs/leapmotion/Warrior_RH_right") as GameObject;
			
			UP = new Vector3 (0, 1, 0);
			DOWN = new Vector3 (0, -1, 0);
			RIGHT = new Vector3 (-1, 0, 0);
			LEFT = new Vector3 (1, 0, 0);
			
			screenBoundX = cam.pixelWidth / screenXFactor;
			screenBoundY = cam.pixelHeight / screenYFactor;
			screenBoundYcenter = -screenBoundY * 1.3f;
			
		} else if (heroClass == "Wizard") {
			leftHandGO = Resources.Load ("prefabs/leapmotion/Wizard_RH_left") as GameObject;
			rightHandGO = Resources.Load ("prefabs/leapmotion/Wizard_RH_right") as GameObject;
			
			UP = new Vector3 (0, 1, 0);
			DOWN = new Vector3 (0, -1, 0);
			RIGHT = new Vector3 (0, 0, 1);
			LEFT = new Vector3 (0, 0, -1);
			
			screenBoundX = cam.pixelWidth / screenXFactor * 0.7f;
			screenBoundY = cam.pixelHeight / screenYFactor * 0.7f;
			screenBoundYcenter = screenBoundY * 0.3f;
			
			fireballGO = Resources.Load ("prefabs/leapmotion/Fireball") as GameObject;
			
			vortexGO = Resources.Load ("prefabs/leapmotion/Vortex") as GameObject;
			
			
		} else if (heroClass == "Monk") {
			leftHandGO = Resources.Load ("prefabs/leapmotion/Monk_RH_left") as GameObject;
			rightHandGO = Resources.Load ("prefabs/leapmotion/Monk_RH_right") as GameObject;
			
			screenBoundX = cam.pixelWidth / screenXFactor /** 0.7f*/;
			screenBoundY = cam.pixelHeight / screenYFactor * 0.7f;
			screenBoundYcenter = -screenBoundY * 1.5f;
			
			UP = new Vector3 (0, 1, 0);
			DOWN = new Vector3 (0, -1, 0);
			RIGHT = new Vector3 (-1, 0, 0);
			LEFT = new Vector3 (1, 0, 0);
		}
		
		
		leftHand = Instantiate (leftHandGO);
		rightHand = Instantiate (rightHandGO);
		
		if (heroClass == "Warrior" || heroClass == "Monk") {
			if (rightHand.GetComponentInChildren<HeroLinkWeapon>() != null) {
				rightHand.GetComponentInChildren<HeroLinkWeapon>().Hero = hero;
			}
		}
		
		
		
		
		leftHand.transform.Translate (RIGHT * -cam.transform.position.x);
		
		
		
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
		} else if (heroClass == "Monk") {
			MonkUpdate ();
		}
		
		
		
	}
	
	private void updatePosition() {
		if (Input.GetKey (KeyCode.Z) && leftHand.transform.localPosition.y < screenBoundY+screenBoundYcenter) {
			leftHand.transform.Translate(movSpeed*UP*Time.deltaTime);
		} else if (Input.GetKey (KeyCode.S) && leftHand.transform.localPosition.y > -screenBoundY+screenBoundYcenter) {
			leftHand.transform.Translate(movSpeed*DOWN*Time.deltaTime);
		}
		//Debug.Log (leftHand.transform.position.x + " | " + screenBoundX);
		if (Input.GetKey (KeyCode.Q) && leftHand.transform.localPosition.x > -screenBoundX) {
			leftHand.transform.Translate(movSpeed*RIGHT*Time.deltaTime);
		} else if (Input.GetKey (KeyCode.D) && leftHand.transform.localPosition.x < screenBoundX) {
			leftHand.transform.Translate(movSpeed*LEFT*Time.deltaTime);
		}
/*<<<<<<< HEAD
		
		
		
		if (swordMov == 0 && staffMov == 0) {
			Vector3 lastPosition = rightHand.transform.position;
			Vector3 v3 = Input.mousePosition;
			
			//NOT A GOOD WAY TO DO MOUSE CLAMPING BUT AT LEAST IT WORKS
			
			
=======*/



		if (swordMov == 0 && staffMov == 0 && Time.timeScale > 0) {
			Vector3 lastPosition = rightHand.transform.position;
			Vector3 v3 = Input.mousePosition;
		
		
		
//>>>>>>> f17bbd7f6cedb82988adc926022f4a48dfb1afca
			v3.z = 2;
			v3 = cam.ScreenToWorldPoint (v3);
			if (v3.x > 1 || !GameModel.MultiplayerModeOn) {
				//Debug.Log (v3);
				v3.z = lastPosition.z;
				
				rightHand.transform.position = v3;
			}
		}
		
		
	}
	
	private void WarriorUpdate(){
		
		
		if (Input.GetMouseButton (0) && swordMov == 0 && Time.timeScale > 0) {
			//Debug.Log("mouse button down");
			swordMov = 1;
		}
		
		
		if (swordMov == 1) {
			
			
			//Debug.Log("1 - " + rightHand.transform.position);
			rightHand.transform.Translate(new Vector3(0,-swordTranslateSpeed2,swordTranslateSpeed)*Time.deltaTime, Space.World);
			rightHand.transform.Rotate(new Vector3(swordRotateSpeed,0,0)*Time.deltaTime, Space.World);
			//Debug.Log("2 - " + rightHand.transform.position);
			
			swordMovTime += Time.deltaTime;
			
			if (swordMovTime >= 0.25) {
				//swordMovTime = 0;
				swordMov = 2;
			}
			//Debug.Log(swordMovTime+" -- sword moving forward");
		}else if (swordMov == 2) {
			
			//Debug.Log("1 - " + rightHand.transform.position);
			rightHand.transform.Rotate(new Vector3(-swordRotateSpeed,0,0)*Time.deltaTime, Space.World);
			rightHand.transform.Translate(new Vector3(0,swordTranslateSpeed2,-swordTranslateSpeed)*Time.deltaTime, Space.World);
			
			//Debug.Log("2 - " + rightHand.transform.position);
			
			swordMovTime -= Time.deltaTime;
			
			if (swordMovTime <= 0) {
				//swordMovTime = 0;
				swordMov = 0;
			}
			//Debug.Log(swordMovTime+" -- sword moving backward");
		}
		
		
		
		if (Input.GetKey (KeyCode.Space)) {
			if (shieldMovTime < 0.25f){
				leftHand.transform.Translate(new Vector3(0,0,shieldTranslateSpeed)*Time.deltaTime);
				shieldMovTime += Time.deltaTime;
			}
		} else {
			if (shieldMovTime > 0) {
				leftHand.transform.Translate(new Vector3(0,0,-shieldTranslateSpeed)*Time.deltaTime);
				shieldMovTime -= Time.deltaTime;
			}
		}
	}
	
	private void WizardUpdate() {
		//Debug.Log (leftHand.transform.position);
		//Debug.Log (cam.pixelWidth + " -- " + cam.pixelHeight);
		
		
		
		if (Input.GetMouseButton (0) && fireball == null && hero.PowerQuantity > HeroConfigurator.wizardAttackCost && Time.timeScale > 0) {
			//Debug.Log ("mouse button down");
			
			fireball = Instantiate (fireballGO);
			//fireball.transform.SetParent(hero);
			fireball.GetComponentInChildren<HeroLinkWeapon> ().Hero = hero;//new Wizard ();
			
			fireball.transform.parent = rightHand.transform.FindChild ("HandContainer").transform;
			fireball.transform.localPosition = new Vector3 (0f, 0.05f, 0f);
		} else if (!Input.GetMouseButton (0) && fireball != null && fireball.transform.parent != null){
			
			fireball.transform.parent = null;
			fireball.GetComponentInChildren<CapsuleCollider>().enabled = true;
			fireball.GetComponent<Rigidbody>().isKinematic = false;
			
			hero.PowerQuantity -= HeroConfigurator.wizardAttackCost;
		}
		
		
		
		
		
		
		if (Input.GetKey(KeyCode.Space) && vortex == null && hero.PowerQuantity > HeroConfigurator.wizardDefenseCost) {
			vortex = Instantiate(vortexGO);
			
			vortex.transform.parent = leftHand.transform.FindChild("HandContainer").transform;
			vortex.transform.localPosition = new Vector3(0f, 0f, 0f);
			
		}else if (!Input.GetKey(KeyCode.Space) && vortex != null && vortex.transform.parent != cam.transform) {
			
			vortex.transform.parent = cam.transform; //attach to camera
			//vortex.transform.localPosition = new Vector3(0f, 0.3f, 1.5f);
			
			vortex.GetComponent<VortexController>().isDropped();
			
			vortex.GetComponentInChildren<CapsuleCollider>().enabled = true;
			//it is dropped so the size is bigger
			vortex.GetComponent<ParticleSystem>().startSize = 0.8f;
			
			hero.PowerQuantity -= HeroConfigurator.wizardDefenseCost;
		}
	}
	
	private void MonkUpdate() {
		//Animator anim = rightHand.GetComponentInChildren<Animator> ();
		((Monk)hero).PrayerMode = Input.GetKey (KeyCode.Space);


		if (Input.GetMouseButton (0) && staffMov == 0 && Time.timeScale > 0) {
			//Debug.Log("mouse button down");
			staffMov = 1;
		}
		Debug.Log (staffMov);
		if (staffMov == 1) {

			rightHand.transform.Rotate (new Vector3(0,-staffRotateSpeed1,0)*Time.deltaTime, Space.World);
			rightHand.transform.Translate(new Vector3(-staffTranslateSpeedX1,0,staffTranslateSpeedX2)*Time.deltaTime, Space.World);

			staffMovTime += Time.deltaTime;
			if (staffMovTime > 0.3f){
				staffMovTime = 0;
				staffMov = 2;
			}
		} else if (staffMov == 2) {

			rightHand.transform.Rotate(new Vector3(0,staffRotateSpeed1*3f,0)*Time.deltaTime, Space.World);
			rightHand.transform.Translate(new Vector3(staffTranslateSpeedX3,0,0)*Time.deltaTime, Space.World);


			staffMovTime += Time.deltaTime;
			if (staffMovTime > 0.2f){
				staffMovTime = 0;
				staffMov = 3;
			}
		} else if (staffMov == 3) {

			rightHand.transform.Rotate (new Vector3(0,-staffRotateSpeed1,0)*Time.deltaTime, Space.World);
			rightHand.transform.Translate(new Vector3(-staffTranslateSpeedX1,0,-staffTranslateSpeedX2)*Time.deltaTime, Space.World);

			staffMovTime += Time.deltaTime;
			if (staffMovTime > 0.3f){
				staffMovTime = 0;
				staffMov = 0;
				Vector3 v3 = rightHand.transform.eulerAngles;
				v3 = new Vector3(0,90,0);
				rightHand.transform.eulerAngles = v3;
			}
		}
	}
}
