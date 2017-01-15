using UnityEngine;
using System.Collections;

namespace LAJ_2017 {
    public class CollectionPoint : MonoBehaviour {
        private void OnDrawGizmos() {
            Gizmos.color = Color.cyan; 
            Gizmos.DrawSphere(this.transform.position, 0.05f);
        }
    }
}