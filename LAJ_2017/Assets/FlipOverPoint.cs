using UnityEngine;
using System.Collections;

namespace LAJ_2017 {
    public class FlipOverPoint : MonoBehaviour {
        private void OnTriggerEnter() {
            Debug.Log("Hit");
            //GetComponentInParent<Rigidbody>().AddForce(-this.transform.up * 250f, ForceMode.Impulse);
        }

        private void OnDrawGizmos() {
            Debug.DrawLine(this.transform.position, this.transform.position + (this.transform.up * 0.1f), Color.red);
        }
    }
}
