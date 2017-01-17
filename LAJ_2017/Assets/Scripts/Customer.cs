using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LAJ_2017 {
    public class Customer : MonoBehaviour {
        private void OnCollisionEnter() {
            Top.soundHandler.PlaySound("Customer", GetComponent<AudioSource>());
        }
    }
}
