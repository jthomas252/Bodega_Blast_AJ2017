using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace LAJ_2017 {
    [ExecuteInEditMode()]
    public class CameraFollow : MonoBehaviour {
        private List<MeshRenderer> hiddenMeshes;  
        public GameObject followObject;

        public Vector3 basePosition;
        public Vector3 baseRotation;
        public float followDistance = 4f; 

        private void Awake() {
            hiddenMeshes = new List<MeshRenderer>(); 
        }

        private void Update() {
            if (!Top.gameHandler.paused) {
                Vector3 updatedPos = followObject.transform.position -
                    (followObject.transform.forward * followDistance);
                updatedPos.y = basePosition.y;

                Vector3 updatedRot = followObject.transform.localEulerAngles;
                updatedRot.x = baseRotation.x;

                transform.position = updatedPos;
                transform.localEulerAngles = updatedRot;

                //Determine if there's a wall between the player and the camera, if so obscure it
                RaycastHit hitinfo;
                Physics.Linecast(
                    transform.position,
                    followObject.transform.position,
                    out hitinfo,
                    1 << 8);

                if (hitinfo.collider != null) {
                    MeshRenderer[] meshes = hitinfo.collider.transform.parent.GetComponentsInChildren<MeshRenderer>();
                    for (int i = 0; i < meshes.Length; ++i) {
                        hiddenMeshes.Add(meshes[i]);
                        meshes[i].material.color = new Color(1f, 1f, 1f, 0.2f);
                    }
                    //Otherwise remove the fadeout if there's nothing blocking.
                } else {
                    for (int i = 0; i < hiddenMeshes.Count; ++i) {
                        hiddenMeshes[i].material.color = new Color(1f, 1f, 1f, 1f);
                    }
                    hiddenMeshes.Clear();
                }
            }
        }
    }
}