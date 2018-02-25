using UnityEngine;
using System.Collections;

public class AnimationScript : MonoBehaviour {

    public Vector3 rotationAngle = new Vector3(0,90,0);
    public float rotationSpeed = 5f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(rotationAngle * rotationSpeed * Time.deltaTime);
	}

}
