using UnityEngine;
using System.Collections;

namespace LAJ_2017 {
    public class Collectable : MonoBehaviour {
        public int value; 
        public bool collected; 

        private void OnTriggerEnter(Collider col) {
            //To-do make this fly into the player cart
            if (col.GetComponent<PlayerCart>()) {
                transform.SetParent(col.transform);
            }
        }

        public void Collect() {
            Top.soundHandler.PlaySound("Pickup");
            collected = true; 
            Top.gameHandler.AddScore(value);
        }
    }
}