using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Env : MonoBehaviour {

    public GameObject[] planes;

    public GameObject[] go100m;

    public GameObject figures;

    private int currentPlaneIndex;
    private GameObject current3DObject;

    private GameObject goVR;
    private Camera mainCamera;
    private int zoom = 1;
    private float[] layerCullDistances;

    private AudioSource music;
    private bool musicOn = true;


    private void Awake() {
        goVR = this.transform.Find("VR").gameObject;
        goVR.SetActive(true); 
            
        mainCamera = goVR.transform.Find("GvrHeadset/Camera").GetComponent<Camera>();

        mainCamera.layerCullDistances[8] = 100;
        music = this.transform.GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start () {
        currentPlaneIndex = 0;
        current3DObject = planes[currentPlaneIndex];
    }


    // Update is called once per frame
    void FixedUpdate () {
        {
            Vector3 pos = Vector3.zero;

            pos = new Vector3(current3DObject.transform.position.x + (1 + zoom) * 2, current3DObject.transform.position.y + (1 + zoom) * 5, current3DObject.transform.position.z - (1 + zoom) * 12);

            goVR.transform.position = pos;
        }
    }

    public void switchPlane() {
        currentPlaneIndex = (currentPlaneIndex + 1) % planes.Length;
        current3DObject = planes[currentPlaneIndex];
    }


    public void switchToFigure() {
        current3DObject = figures;
    }


    public void zoomChange() {
        zoom = (zoom+1) % 6;
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
