using UnityEngine;
using System.Collections;

public class Watcher : MonoBehaviour {

	public GameObject dragon;
	public int sens = 1;
	public bool active = false;
	     private float timeToChangeDirection;

// Use this for initialization
     public void Start () {
         ChangeDirection();
     }
     
     // Update is called once per frame
     public void Update () {
         timeToChangeDirection -= Time.deltaTime;
 
         if (timeToChangeDirection <= 0) {
             ChangeDirection();
         }
 
         GetComponent<Rigidbody>().velocity = -transform.forward * 2;
     }
 
 
 
     private void ChangeDirection() {
         float angle = Random.Range(0f, 360f);
         //Quaternion quat = Quaternion.AngleAxis(angle, Vector3.left);
         Vector3 newUp = Vector3.forward;//quat * -Vector3.forward;
         newUp.z = 0;
         newUp.Normalize();
         transform.up = newUp;
         timeToChangeDirection = 1.5f;
     }
 }