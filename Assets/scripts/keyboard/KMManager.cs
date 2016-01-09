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

	int swordMov = 0;
	float swordRotateSpeed = 360;
	float swordTranslateSpeed = 10;

	float shieldTranslateSpeed = 5;

	float mouseSpeed = 100f;

	Hero hero;
	string heroClass;

	float screenBoundX;
	float screenXFactor = 640;

	float screenBoundY;
	float screenYFactor = 640;
	float screenBoundYcenter;

	float movSpeed = 0.05f;
	

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
			RIGHT = new Vector3(-1, 0, 0);
			LEFT = new Vector3(1, 0, 0);

			screenBoundX = cam.pixelWidth / screenXFactor;
			screenBoundY = cam.pixelHeight / screenYFactor;
			screenBoundYcenter = -screenBoundY*1.3f;

		} else if (heroClass == "Wizard"){
			leftHandGO = Resources.Load ("prefabs/leapmotion/Wizard_RH_left") as GameObject;
			rightHandGO = Resources.Load ("prefabs/leapmotion/Wizard_RH_right") as GameObject;

			UP = new Vector3 (0, 1, 0);
			DOWN = new Vector3 (0, -1, 0);
			RIGHT = new Vector3(0, 0, 1);
			LEFT = new Vector3(0, 0, -1);

			screenBoundX = cam.pixelWidth / screenXFactor * 0.7f;
			screenBoundY = cam.pixelHeight / screenYFactor * 0.7f;
			screenBoundYcenter = screenBoundY*0.3f;

		}

		fireballGO = Resources.Load ("prefabs/leapmotion/Fireball") as GameObject;

		vortexGO = Resources.Load ("prefabs/leapmotion/Vortex") as GameObject;

		leftHand = Instantiate (leftHandGO);
		rightHand = Instantiate (rightHandGO);

		if (heroClass == "Warrior") {
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
		}



	}

	private void updatePosition() {
		if (Input.GetKey (KeyCode.Z) && leftHand.transform.localPosition.y < screenBoundY+screenBoundYcenter) {
			leftHand.transform.Translate(movSpeed*UP);
		} else if (Input.GetKey (KeyCode.S) && leftHand.transform.localPosition.y > -screenBoundY+screenBoundYcenter) {
			leftHand.transform.Translate(movSpeed*DOWN);
		}
		//Debug.Log (leftHand.transform.position.x + " | " + screenBoundX);
		if (Input.GetKey (KeyCode.Q) && leftHand.transform.localPosition.x > -screenBoundX) {
			leftHand.transform.Translate(movSpeed*RIGHT);
		} else if (Input.GetKey (KeyCode.D) && leftHand.transform.localPosition.x < screenBoundX) {
			leftHand.transform.Translate(movSpeed*LEFT);
		}

		Vector3 lastPosition = rightHand.transform.position;
		Vector3 v3 = Input.mousePosition;

		//NOT A GOOD WAY TO DO MOUSE CLAMPING BUT AT LEAST IT WORKS


			v3.z = 2;
			v3 = cam.ScreenToWorldPoint (v3);
		if (v3.x > 1) {
			//Debug.Log (v3);
			v3.z = lastPosition.z;
		
			rightHand.transform.position = v3;
		}

		/*if (!(rightHand.transform.localPosition.y < screenBoundY+screenBoundYcenter
		    && rightHand.transform.localPosition.y > -screenBoundY+screenBoundYcenter
		    && rightHand.transform.localPosition.x > -screenBoundX
		    && rightHand.transform.localPosition.x < screenBoundX)) {
			rightHand.transform.position = lastPosition;
		}*/
	}

	private void WarriorUpdate(){

		
		if (Input.GetMouseButton (0) && swordMov == 0) {
			//Debug.Log("mouse button down");
			swordMov = 1;
		}
		
		
		if (swordMov == 1) {
			

			//Debug.Log("1 - " + rightHand.transform.position);
			rightHand.transform.Translate(new Vector3(-swordTranslateSpeed,0,-swordTranslateSpeed)*Time.deltaTime);
			rightHand.transform.Rotate(new Vector3(0,swordRotateSpeed,0)*Time.deltaTime);
			//Debug.Log("2 - " + rightHand.transform.position);
			
			swordMovTime += Time.deltaTime;
			
			if (swordMovTime >= 0.25) {
				//swordMovTime = 0;
				swordMov = 2;
			}
			//Debug.Log(swordMovTime+" -- sword moving forward");
		}else if (swordMov == 2) {

			//Debug.Log("1 - " + rightHand.transform.position);
			rightHand.transform.Rotate(new Vector3(0,-swordRotateSpeed,0)*Time.deltaTime);
			rightHand.transform.Translate(new Vector3(swordTranslateSpeed,0,swordTranslateSpeed)*Time.deltaTime);
			
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
		Debug.Log (leftHand.transform.position);
		//Debug.Log (cam.pixelWidth + " -- " + cam.pixelHeight);



		if (Input.GetMouseButton (0) && fireball == null && hero.PowerQuantity > HeroConfigurator.wizardAttackCost) {
			//Debug.Log ("mouse button down");

			fireball = Instantiate (fireballGO);
			fireball.GetComponentInChildren<HeroLinkWeapon> ().Hero = new Wizard ();
			
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
}
