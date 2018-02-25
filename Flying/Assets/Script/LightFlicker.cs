using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour {

    private Light spotlight = null;
    private float timer = 0.5f;

    private void Awake() {
        spotlight = this.GetComponent<Light>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	private void FixedUpdate () {
        timer -= Time.deltaTime;

        if (timer < 0) {
            if (spotlight.enabled == true) {
                spotlight.enabled = false;
            }
            else if (spotlight.enabled == false) {
                spotlight.enabled = true;
            }
            timer = 0.5f;
        }
    }


}
