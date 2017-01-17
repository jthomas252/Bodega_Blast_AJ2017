using UnityEngine;
using System.Collections;

namespace LAJ_2017 {
    public class PlayerCart : MonoBehaviour {
        private const float _minimumTip    = 12.5f; 
        private const float _tipCorrection = 15f; 
        private const float _collectDist   = 0.05f;
        private const int   maxItems       = 16; 

        private bool     isSkidding;
        private WheelSet wheelSet; 

        public float turningSpeed     = 2.5f; 
        public float accelerationRate = 4f; 

        public Material characterSprite; 
        public Texture2D text; 

        public Vector3 collectionPoint; 
        
        // Use this for initialization
        private void Start() {
            isSkidding     = false; 
            wheelSet       = new WheelSet(); 
            Wheel[] wheels = GetComponentsInChildren<Wheel>();
            wheelSet.SetWheelGroup(wheels); 
        }

        // Update is called once per frame
        private void Update() {
            if (!Top.gameHandler.paused) {
                if (Input.GetKey(KeyCode.W)) {
                    wheelSet.AccelerateAll(accelerationRate);
                } else if (Input.GetKey(KeyCode.S)) {
                    wheelSet.AccelerateAll(-accelerationRate);
                } else {
                    wheelSet.AccelerateAll(0);
                }

                if (Input.GetKey(KeyCode.A)) {
                    wheelSet.TurnAll(-turningSpeed * Time.deltaTime);
                } else if (Input.GetKey(KeyCode.D)) {
                    wheelSet.TurnAll(turningSpeed * Time.deltaTime);
                } else {
                    wheelSet.StopTurn();
                }

                if (Input.GetKey(KeyCode.Space)) {
                    wheelSet.BrakeAll(accelerationRate);
                } else {
                    wheelSet.BrakeAll(0);
                }

                //Clamp rotation axises 
                if ((transform.localEulerAngles.z > 0f + _minimumTip &&
                    transform.localEulerAngles.z < 360f - _minimumTip) ||
                    (transform.localEulerAngles.x > 0f + _minimumTip &&
                    transform.localEulerAngles.x < 360f - _minimumTip)) {
                    Vector3 rotation = this.transform.localEulerAngles;

                    if (rotation.z > 180f) rotation.z -= 360f;
                    if (rotation.x > 180f) rotation.x -= 360f;

                    if (!isSkidding) Top.soundHandler.PlaySound("CartSkid", GetComponent<AudioSource>());
                    isSkidding = true; 

                    rotation.z = Mathf.Clamp(rotation.z, -_tipCorrection, _tipCorrection);
                    rotation.x = Mathf.Clamp(rotation.x, -_tipCorrection, _tipCorrection);
                    this.transform.localEulerAngles = rotation;
                } else {
                    isSkidding = false; 
                }

                Collectable[] items = GetComponentsInChildren<Collectable>();
                for (int i = 0; i < items.Length; ++i) {
                    if (!items[i].collected) {
                        items[i].transform.localPosition = Vector3.Lerp(items[i].transform.localPosition, collectionPoint, Time.deltaTime * 5f);
                        if (Vector3.Distance(items[i].transform.localPosition, collectionPoint) < _collectDist) {
                            items[i].Collect();
                        }
                    }
                }
                if (items.Length > maxItems) {
                    int removeCount = items.Length - maxItems;
                    for (int i = 0; i < removeCount; ++i) {
                        Destroy(items[i].gameObject);
                    }
                }
            }
        }

        private void OnDrawGizmos() {
            Gizmos.color = Color.cyan; 
            Gizmos.DrawSphere(transform.position + collectionPoint, 0.05f); 
        }

        private void OnCollisionEnter(Collision c) {
            Rigidbody _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.AddExplosionForce(20f, c.contacts[0].point, 1f);
            Top.soundHandler.PlaySound("CartCrash", GetComponent<AudioSource>());
        }
    }
}