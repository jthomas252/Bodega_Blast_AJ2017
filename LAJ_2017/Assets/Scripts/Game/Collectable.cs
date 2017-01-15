using UnityEngine;
using System.Collections;

namespace LAJ_2017 {
    public class Collectable : MonoBehaviour {
        private void OnTriggerEnter() {
            //Change this to fly into the players cart
            Debug.Log("Collected");
            Destroy(this.gameObject); 
        }

        private void Update() {

        }
    }
}