using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Env : MonoBehaviour {

    public GameObject[] planes;

    public GameObject figures;

    private int currentPlaneIndex;
    private GameObject current3DObject;

    private GameObject mainCamera;
    private bool zoom = false;

    private AudioSource music;
    private bool musicOn = true;


    private void Awake() {
        mainCamera = this.transform.Find("VR").gameObject;
        mainCamera.SetActive(true);
        music = this.transform.GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start () {
        currentPlaneIndex = 0;
        current3DObject = planes[currentPlaneIndex];
    }


    // Update is called once per frame
    void FixedUpdate () {
        Vector3 pos = Vector3.zero;

        if (zoom) {
            pos = new Vector3(current3DObject.transform.position.x + 15, current3DObject.transform.position.y + 5, current3DObject.transform.position.z - 10);
        }
        else {
            pos = new Vector3(current3DObject.transform.position.x + 45, current3DObject.transform.position.y + 5, current3DObject.transform.position.z - 35);
        }

        Transform trans = mainCamera.transform;
        trans.position = pos;

    }

    public void switchPlane() {
        currentPlaneIndex = (currentPlaneIndex + 1) % planes.Length;
        current3DObject = planes[currentPlaneIndex];
    }


    public void switchToFigure() {
        current3DObject = figures;
    }


    public void zoomChange() {
        zoom = !zoom;
    }

    public void musicChange() {
        musicOn = !musicOn;
        if (musicOn) {
            music.Play();
        }
        else {
            music.Stop();
        }
    }


}
