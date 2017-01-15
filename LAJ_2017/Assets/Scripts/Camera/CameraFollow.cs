using UnityEngine;
using System.Collections;

namespace LAJ_2017 {
    public class CameraFollow : MonoBehaviour {
        public GameObject followObject;

        public Vector3 basePosition;
        public Vector3 baseRotation;
        public float followDistance = 4f; 

        private void Aware() {
        }

        private void Update() {
            Vector3 updatedPos = followObject.transform.position - 
                (followObject.transform.forward * followDistance); 
            updatedPos.y       = basePosition.y; 

            Vector3 updatedRot = followObject.transform.localEulerAngles;
            updatedRot.x       = baseRotation.x; 

            transform.position         = updatedPos;
            transform.localEulerAngles = updatedRot;
        }
    }
}