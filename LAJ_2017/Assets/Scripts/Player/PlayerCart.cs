using UnityEngine;
using System.Collections;

namespace LAJ2017 {
    public class PlayerCart : MonoBehaviour {
        private Rigidbody _rigidbody;
        private WheelCollider[] wheels;

        // Use this for initialization
        void Start() {
            _rigidbody = this.GetComponentInChildren<Rigidbody>();
            wheels = this.GetComponentsInChildren<Wheel>();
        }

        // Update is called once per frame
        void Update() {
            //Move me to InputHandler / callbacks
            if (Input.GetKey(KeyCode.W)) {
                for (int i = 0; i < wheels.Length; ++i) {
                    wheels[i].Accelerate(acceleration);
                }
            }

            if (Input.GetKey(KeyCode.A)) {
                for (int i = 0; i < wheels.Length; ++i) {
                    wheels[i].Turn();
                }
            }

            if (Input.GetKey(KeyCode.S)) {
                for (int i = 0; i < wheels.Length; ++i) {
                    wheels[i].Brake(); 
                }
            }

            if (Input.GetKey(KeyCode.D)) {
                for (int i = 0; i < wheels.Length; ++i) {
                    wheels[i].Turn(); 
                }
            }
        }
    }
}