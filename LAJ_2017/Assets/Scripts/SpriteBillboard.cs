using UnityEngine;
using System.Collections;

namespace LAJ_2017 {
    public class SpriteBillboard : MonoBehaviour {
        private Vector3 baseRotation; 

        private void Awake() {
            baseRotation = transform.localEulerAngles; 
        }

        private void Update() {
            Vector3 billboardAngle     = Camera.main.transform.localEulerAngles;
            billboardAngle.z          += baseRotation.z;
            billboardAngle.x          += baseRotation.x;
            transform.localEulerAngles  = billboardAngle;
            Debug.Log(billboardAngle);
        }
    }
}