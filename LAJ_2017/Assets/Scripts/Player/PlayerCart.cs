using UnityEngine;
using System.Collections;

namespace LAJ2017 {
    public class PlayerCart : MonoBehaviour {
        
        public float turningSpeed     = 2.5f; 
        public float accelerationRate = 4f; 

        private Wheel[] wheels;

        
        // Use this for initialization
        void Start() {
            wheels = GetComponentsInChildren<Wheel>();
        }

        // Update is called once per frame
        void Update() {
            if (Input.GetKey(KeyCode.W)) {
                for (int i = 0; i < wheels.Length; ++i) {
                    wheels[i].Accelerate(accelerationRate * Time.deltaTime);
                }
            }

            if (Input.GetKey(KeyCode.A)) {
                for (int i = 0; i < wheels.Length; ++i) {
                    wheels[i].Turn(-turningSpeed * Time.deltaTime);
                }
            }

            if (Input.GetKey(KeyCode.S)) {
                for (int i = 0; i < wheels.Length; ++i) {
                    wheels[i].Brake(accelerationRate * Time.deltaTime); 
                }
            }

            if (Input.GetKey(KeyCode.D)) {
                for (int i = 0; i < wheels.Length; ++i) {
                    wheels[i].Turn(turningSpeed * Time.deltaTime); 
                }
            }
        }
    }
}