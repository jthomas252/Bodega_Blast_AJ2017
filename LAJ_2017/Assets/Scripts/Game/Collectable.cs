using UnityEngine;
using System.Collections;

namespace LAJ_2017 {
    public class Collectable : MonoBehaviour {
        public int value; 

        private void OnTriggerEnter(Collider col) {
            //To-do make this fly into the player cart
            if (col.GetComponent<PlayerCart>()) {
                Top.soundHandler.PlaySound("Pickup");
                Destroy(gameObject);
            }
        }

        private void Update() {

        }
    }
}