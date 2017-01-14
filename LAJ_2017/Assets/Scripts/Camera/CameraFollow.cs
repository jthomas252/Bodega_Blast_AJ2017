using UnityEngine;
using System.Collections;

namespace LAJ_2017 {
    public class CameraFollow : MonoBehaviour {
        public GameObject followObject;

        public Vector3 basePosition;
        public Vector3 baseRotation;

        private void Aware() {
        }

        private void Update() {
            this.transform.position = new Vector3(
                followObject.transform.position.x,
                followObject.transform.position.y + basePosition.y,
                followObject.transform.position.z + basePosition.z
                );

            Quaternion q = followObject.transform.rotation;

            q.eulerAngles = new Vector3(
                followObject.transform.rotation.x + baseRotation.x,
                followObject.transform.rotation.y,
                this.transform.rotation.z
                );

            this.transform.rotation = q;
        }
    }
}