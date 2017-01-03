using UnityEngine;
using System.Collections;


namespace LAJ2017 {
    [RequireComponent (typeof (WheelCollider))]
    public class Wheel : MonoBehaviour {
        private WheelCollider _wheelCollider; 
        public  GameObject    wheelMesh;

        public float turningRange = 30f; 

        private void Awake() {

        }

        public void Acclerate() {

        }
    }
}
