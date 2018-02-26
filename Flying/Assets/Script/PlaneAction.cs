using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneAction : MonoBehaviour {

    private bool action = true;
    private float balancedTime;
    private float rotationleft;
    private float rotationSpeed;

    // Use this for initialization
    void Start () {
        action = true;
        balancedTime = 0;
        rotationleft = 360 * Random.Range(1, 5);
        rotationSpeed = 160 * Random.Range(0.5f, 1);
    }



    // Update is called once per frame
    void FixedUpdate () {
        if (action) { 
            if (transform.localEulerAngles.z < 80 || transform.localEulerAngles.z > 90) {
                transform.Rotate(Vector3.forward * Time.deltaTime * 80);
            }
            balancedTime = 0;
            rotationleft = 360 * Random.Range(1, 5);
            rotationSpeed = 240 * Random.Range(0.33333f, 1);
        }
        else {
            balancedTime += Time.deltaTime;
            if (balancedTime > 5f && rotationleft > 0) {
                float rotation = rotationSpeed * Time.deltaTime;
                if (rotationleft > rotation) {
                    rotationleft -= rotation;
                }
                else {
                    rotation = rotationleft;
                    rotationleft = 0;
                }
                transform.Rotate(0, 0, rotation);
            }
            else {
                if (transform.localEulerAngles.z > 20 || transform.localEulerAngles.z < 10) {
                    transform.Rotate(Vector3.back * Time.deltaTime * 80);
                }
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
