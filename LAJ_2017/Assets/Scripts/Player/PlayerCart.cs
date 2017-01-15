using UnityEngine;
using System.Collections;

namespace LAJ_2017 {
    public class PlayerCart : MonoBehaviour {
        private const float _minimumTip    = 15f; 
        private const float _tipCorrection = 25f; 

        private WheelSet wheelSet; 

        public float turningSpeed     = 2.5f; 
        public float accelerationRate = 4f; 

        public Material characterSprite; 
        public Texture2D text; 

        public Vector3 collectionPoint; 
        
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
                wheelSet.BrakeAll(accelerationRate);
            } else {
                wheelSet.BrakeAll(0);
            }

            //Clamp rotation axises 
            if ((transform.localEulerAngles.z > 0f + _minimumTip &&
                transform.localEulerAngles.z < 360f - _minimumTip) ||
                (transform.localEulerAngles.x > 0f + _minimumTip &&
                transform.localEulerAngles.x < 360f - _minimumTip)) {
                Vector3 rotation = this.transform.localEulerAngles;

                if (rotation.z > 180f) rotation.z -= 360f;
                if (rotation.x > 180f) rotation.x -= 360f;

                rotation.z = Mathf.Clamp(rotation.z, -_tipCorrection, _tipCorrection);
                rotation.x = Mathf.Clamp(rotation.x, -_tipCorrection, _tipCorrection);
                this.transform.localEulerAngles = rotation;
            }
        }

        private void OnDrawGizmos() {
            Gizmos.color = Color.cyan; 
            Gizmos.DrawSphere(transform.position + collectionPoint, 0.1f); 
        }
    }
}