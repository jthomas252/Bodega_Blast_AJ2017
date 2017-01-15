using UnityEngine;
using System.Collections;

namespace LAJ_2017 {
    public class InterfaceHandler : MonoBehaviour {

        public void UpdateTime(float time) {
            int seconds = (int)time; 
            int minutes = Mathf.FloorToInt(seconds / 60);
            seconds     = seconds % 60; 

            Debug.Log(minutes + ":" + seconds); 
        }

        public void ShowPauseScreen() {

        }

        public void HidePauseScreen() {

        }
    }
}