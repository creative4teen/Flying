using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneAction : MonoBehaviour {

    private bool action = true;
	// Use this for initialization
	void Start () {
        action = true;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (action) { 
            if (transform.localEulerAngles.z < 80 || transform.localEulerAngles.z > 90) {
                transform.Rotate(Vector3.forward * Time.deltaTime * 80);
            }
        }
        else {
            if (transform.localEulerAngles.z > 20 || transform.localEulerAngles.z < 10) {
                transform.Rotate(Vector3.back * Time.deltaTime * 80);
            }
        }
    }

    void OnTriggerEnter(Collider collision) {
        action = true;
    }

    void OnTriggerExit(Collider collision) {
        action = false;
    }

}
