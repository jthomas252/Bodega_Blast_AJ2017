using UnityEngine;
using System.Collections;

namespace LAJ_2017 {
    public class Collectable : MonoBehaviour {
        private void OnTriggerEnter() {
            Debug.Log("Collected");
            Destroy(this.gameObject); 
        }
    }
}