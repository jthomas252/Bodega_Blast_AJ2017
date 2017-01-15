using UnityEngine;
using System.Collections;

namespace LAJ_2017 {
    public class Collectable : MonoBehaviour {
        public int value; 

        private void OnTriggerEnter(Collider col) {
            if (col.GetComponent<PlayerCart>()) {
                Destroy(gameObject);
            }
        }

        private void Update() {

        }
    }
}