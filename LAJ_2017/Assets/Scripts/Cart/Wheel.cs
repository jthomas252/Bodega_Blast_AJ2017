using UnityEngine;
using System.Collections;

namespace LAJ2017 {
    [RequireComponent (typeof (WheelCollider))]
    public class Wheel : MonoBehaviour {
        private WheelCollider wheelCollider; 
        public  GameObject    wheelMesh;
        public  bool          steerable = true; 

        public float turningRange = 30f; 
        public float maxSpeed     = 15f; 
        public float speedDecay   = 1f;

        private void Awake() {
            if (wheelMesh == null) {
                Debug.LogWarning("Wheel has no mesh attached");
            }
            wheelCollider = GetComponent<WheelCollider>(); 
        }

        public void Update() {
            Debug.Log(wheelCollider.motorTorque);
            Debug.Log(wheelCollider.steerAngle);
            wheelMesh.transform.Rotate(new Vector3(wheelCollider.motorTorque, 0f));
            if (wheelCollider.motorTorque > 0) { 
                wheelCollider.motorTorque -= (speedDecay * Time.deltaTime);
            } else if (wheelCollider.motorTorque < -0.1f) {
                wheelCollider.motorTorque += (speedDecay * Time.deltaTime);
            }
        }

        public void Accelerate(float speed) {
            wheelCollider.motorTorque += speed; 
            if (wheelCollider.motorTorque > maxSpeed) wheelCollider.motorTorque = maxSpeed; 
        }

        public void Turn(float speed) {
            if (steerable) {
                wheelCollider.steerAngle += speed;

                if (wheelCollider.steerAngle > turningRange) {
                    wheelCollider.steerAngle = turningRange;
                } else if (wheelCollider.steerAngle < -turningRange) {
                    wheelCollider.steerAngle = -turningRange; 
                }

                Quaternion q = wheelMesh.transform.localRotation;
                Vector3 v = q.eulerAngles;
                v.y = wheelCollider.steerAngle;
                q.eulerAngles = v;
                wheelMesh.transform.localRotation = q;
            }
        }

        public void Brake(float speed) {
            wheelCollider.motorTorque -= speed;
            if (wheelCollider.motorTorque < -maxSpeed) wheelCollider.motorTorque = -maxSpeed; 
        }
    }
}
