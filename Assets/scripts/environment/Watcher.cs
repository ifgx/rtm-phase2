using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Watcher : MonoBehaviour {

    private bool activated = false;
    private Vector3 pointA = new Vector3(0.0f,1.0f,5.0f);
    private Vector3 pointB = new Vector3(0.0f,1.0f,35.0f);
    private Vector3 pointC = new Vector3(28.0f,1.0f,5.0f);
    private List<Vector3> points;
    private int i;
    private int nb_points;

// Use this for initialization
    public void Start () {
        transform.position = new Vector3(28.0f,1.0f,5.0f);
        points = new List<Vector3>();
        points.Add(pointA);
        points.Add(pointB);
        points.Add(pointC);
        
        nb_points = points.Count;
        i = 0;

    }

    // Update is called once per frame
    public void Update () {
        if (Input.GetKey (KeyCode.B) || activated) {
            activated = true;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(transform.position - points[i]), 5.0f*Time.deltaTime);
            transform.position -= transform.forward * 3.0f * Time.deltaTime;

            float dist = Vector3.Distance(points[i], transform.position);
            if(dist < 0.1f)
            {
                if(i == nb_points-1)
                {
                    i=0;
                }else{
                i++;
                }
                
            }
        }
    }


 }