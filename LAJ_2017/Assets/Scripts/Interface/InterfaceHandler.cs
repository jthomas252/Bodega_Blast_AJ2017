using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

namespace LAJ_2017 {
    public class InterfaceHandler : MonoBehaviour {
        public Text timeText;
        public Text scoreText; 

        public void UpdateTime(float time) {
            int seconds = (int)time; 
            int minutes = Mathf.FloorToInt(seconds / 60);
            seconds     = seconds % 60; 

            timeText.text = minutes + ":" + (seconds < 10 ? "0" + seconds : "" + seconds); 
        }

        public void UpdateScore(int score) {
            scoreText.text = "$" + ((float)score / 100); 
        }

        public void ShowPauseScreen() {

        }

        public void HidePauseScreen() {

        }
    }
}