using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LAJ_2017 {
    public class CashierArea : MonoBehaviour {
        private bool canCheckout = false; 

        private void OnTriggerEnter(Collider c) {
            if (c.GetComponent<PlayerCart>()) {
                canCheckout = true; 
                Top.interfaceHandler.ShowCanCheckout(); 
            }
        }

        private void OnTriggerExit(Collider c) {
            if (c.GetComponent<PlayerCart>()) {
                canCheckout = false; 
                Top.interfaceHandler.HideCanCheckout(); 
            }
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.X) && canCheckout) {
                Top.gameHandler.Checkout(); 
            }
        }
    }
}