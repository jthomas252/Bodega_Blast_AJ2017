using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    private Rigidbody _rigidbody;

    // Use this for initialization
    void Start() {
        _rigidbody = this.GetComponentInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        //Move me to InputHandler / callbacks
        if (Input.GetKey(KeyCode.W)) {
            _rigidbody.AddForce(this.transform.forward * 1f);
        }

        if (Input.GetKey(KeyCode.A)) {
            Quaternion q = _rigidbody.rotation;
            Vector3 v = q.eulerAngles;
            v.y -= 2.5f;
            q.eulerAngles = v;
            _rigidbody.rotation = q;
        }

        if (Input.GetKey(KeyCode.S)) {
            _rigidbody.AddForce(this.transform.forward * -1f);
        }

        if (Input.GetKey(KeyCode.D)) {
            Quaternion q = _rigidbody.rotation;
            Vector3 v = q.eulerAngles;
            v.y += 2.5f;
            q.eulerAngles = v;
            _rigidbody.rotation = q;
        }
    }
}