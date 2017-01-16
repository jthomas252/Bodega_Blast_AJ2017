using UnityEngine;
using System.Collections;

namespace LAJ_2017 {
    public class GameHandler : MonoBehaviour {
        private bool _paused;
        public bool paused {
            get {
                return _paused; 
            }
        }

        public float missionTime = 300.00f;

        private void Awake() {
            _paused = false; 
        }

        private void Update() {
            if (!paused) {
                missionTime -= Time.deltaTime;
                Top.interfaceHandler.UpdateTime(missionTime);
            }

            Top.interfaceHandler.UpdateScore(666);
        }
    }
}