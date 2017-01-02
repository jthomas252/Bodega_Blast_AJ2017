using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    public GameObject followObject; 
    
    public Vector3 basePosition; 
    public Vector3 baseRotation; 

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	    this.transform.position = new Vector3(
            followObject.transform.position.x,
            followObject.transform.position.y + basePosition.y,
            followObject.transform.position.z + basePosition.z
            );

        Quaternion q = followObject.transform.rotation; 

        q.eulerAngles = new Vector3(
            followObject.transform.rotation.x + baseRotation.x,
            followObject.transform.rotation.y,
            this.transform.rotation.z
            );

        this.transform.rotation = q; 
	}
}
