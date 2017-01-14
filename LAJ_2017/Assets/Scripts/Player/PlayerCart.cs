using UnityEngine;
using System.Collections;

namespace LAJ_2017 {
    public class PlayerCart : MonoBehaviour {
        private WheelSet wheelSet; 

        public float turningSpeed     = 2.5f; 
        public float accelerationRate = 4f; 
        
        // Use this for initialization
        private void Start() {
            wheelSet       = new WheelSet(); 
            Wheel[] wheels = GetComponentsInChildren<Wheel>();
            wheelSet.SetWheelGroup(wheels); 
        }

        // Update is called once per frame
        private void Update() {
            if (Input.GetKey(KeyCode.W)) {
                wheelSet.AccelerateAll(accelerationRate);
            } else if (Input.GetKey(KeyCode.S)) {
                wheelSet.AccelerateAll(-accelerationRate);
            } else {
                wheelSet.AccelerateAll(0);
            }

            if (Input.GetKey(KeyCode.A)) {
                wheelSet.TurnAll(-turningSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.D)) {
                wheelSet.TurnAll(turningSpeed * Time.deltaTime); 
            }

            if (Input.GetKey(KeyCode.Space)) {

            } else {

            }
        }
    }
}