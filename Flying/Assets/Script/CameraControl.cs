using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CameraControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Transform trans = this.transform;
        Rigidbody rigid = this.GetComponent<Rigidbody>();

        float roll = Input.GetAxis("Horizontal")*1.5f;
        if (roll < 0.00001 && roll > -0.00001) {
            roll = CrossPlatformInputManager.GetAxis("Horizontal") * 1.5f;
        }
        float pitch = -Input.GetAxis("Vertical") * 1.5f;
        if (pitch < 0.00001 && pitch > -0.00001) {
            pitch = CrossPlatformInputManager.GetAxis("Vertical") * 1.5f;
        }
        pitch = pitch + 0.05f;
        //
        roll = Mathf.Clamp(roll, -0.1f, 0.1f);
        pitch = Mathf.Clamp(pitch, -0.1f, 0.1f);
        //
        this.transform.Rotate(-pitch, roll, 0);


        /*        if (Input.GetKey(KeyCode.LeftArrow)) {
                    camera.transform.Rotate(0, -10 * Time.deltaTime, 0);
                }
                if (Input.GetKey(KeyCode.RightArrow)) {
                    camera.transform.Rotate(0, 10 * Time.deltaTime, 0);
                }
                if (Input.GetKey(KeyCode.UpArrow)) {
                    camera.transform.Rotate(10 * Time.deltaTime, 0, 0);
                }
                if (Input.GetKey(KeyCode.DownArrow)) {
                    camera.transform.Rotate(-10 * Time.deltaTime, 0, 0);
                } */

        {
            float reducer = 0.95f;
            trans.eulerAngles = new Vector3(trans.eulerAngles.x, trans.eulerAngles.y, trans.eulerAngles.z < 180 ? trans.eulerAngles.z * reducer : 360 - (360 - trans.eulerAngles.z) * reducer);
            {
                float x = trans.eulerAngles.x;
                if (x > 180) {
                    if (x < 300) {
                        x = 300 - (300 - x) * reducer;
                    }
                }
                else if (x > 45) {
                    x = 45 + (x - 45) * reducer;
                }
                trans.eulerAngles = new Vector3(x, trans.eulerAngles.y, trans.eulerAngles.z);
            }
            rigid.angularVelocity *= reducer; // (1-timedelta);
        }
    }



}
