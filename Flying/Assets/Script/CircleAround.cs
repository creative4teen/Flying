using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GOTERRAIN {

    public class CircleAround : MonoBehaviour {
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

        private void Awake() {
            ZERO = new Vector3(centerX, centerY, centerZ);
        }

        // Use this for initialization
        void Start() {
        }

        // Update is called once per frame
        void FixedUpdate() {
            //transform.Rotate(Vector3.up, RotationSpeed * Time.deltaTime);
            Vector3 line = new Vector3(tiltX, tiltY, tilt);  // up (0, 1, -0.35f).
            transform.RotateAround(ZERO, line, OrbitDegrees * Time.deltaTime);
        }

    }


}