using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneAction : MonoBehaviour {
    //
    public float centerX = 0f;
    public float centerY = 0f;
    public float centerZ = 0f;

    public static Vector3 ZERO = new Vector3(0, 0, 0);
    //public float RotationSpeed = 0.1f;
    public float OrbitDegrees = 0.001f;
    //
    public float tiltX = 0f;
    public float tiltY = 1f;
    public float tilt = 0f;
    //
    private bool action = true;
    private float balancedTime;
    private float rotationleft;
    private float rotationSpeed;

    private Collider collider;

    //
    private void Awake() {
        collider = this.GetComponent<Collider>();
        ZERO = new Vector3(centerX, centerY, centerZ);
    }
    // Use this for initialization
    void Start () {
        action = true;
        balancedTime = 0;
        rotationleft = 360 * Random.Range(1, 5);
        rotationSpeed = 160 * Random.Range(0.5f, 1);
    }



    // Update is called once per frame
    void FixedUpdate() {
        CircleAround();
        if (collider != null) {
            CollisionAction();
        }
    }

    //
    private void CollisionAction() { 
        if (action) { 
            if (transform.localEulerAngles.z < 80 || transform.localEulerAngles.z > 90) {
                transform.Rotate(Vector3.forward * Time.deltaTime * 80);
            }
            balancedTime = 0;
            rotationleft = 360 * Random.Range(-3, 4);
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

    //
    private void CircleAround() {
        //transform.Rotate(Vector3.up, RotationSpeed * Time.deltaTime);
        Vector3 line = new Vector3(tiltX, tiltY, tilt);  // up (0, 1, -0.35f).
        transform.RotateAround(ZERO, line, OrbitDegrees * Time.deltaTime);
    }

    void OnTriggerEnter(Collider collision) {
        action = true;
    }

    void OnTriggerExit(Collider collision) {
        action = false;
    }

}
