using UnityEngine;
using System.Collections;

namespace LAJ_2017 {
    public class SpriteBillboard : MonoBehaviour {
        private Vector3        baseRotation; 
        private SpriteRenderer spriteRenderer; 

        private void Awake() {
            baseRotation   = transform.localEulerAngles;
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update() {
            if (spriteRenderer.isVisible) {
                Vector3 billboardAngle = Camera.main.transform.eulerAngles;
                billboardAngle.z = 0f;
                billboardAngle.x = 0f;
                transform.eulerAngles = billboardAngle;
            }
        }
    }
}