using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

namespace LAJ_2017 {
    public class InterfaceHandler : MonoBehaviour {
        public Text timeText;
        public Text scoreText; 
        public Text canCheckoutText; 

        public RectTransform interfacePause; 
        public RectTransform interfaceGame;
        public RectTransform interfaceMainMenu;
        public RectTransform interfaceHowToPlay;
        public RectTransform interfaceCredits;
        public RectTransform interfaceGameOver;
        public RectTransform interfaceCheckout; 
        
        public Text gameOverText;
        public Text checkoutText; 

        public void UpdateTime(float time) {
            int seconds = (int)time; 
            int minutes = Mathf.FloorToInt(seconds / 60);
            seconds     = seconds % 60; 

            timeText.text = minutes + ":" + (seconds < 10 ? "0" + seconds : "" + seconds); 
        }

        public void UpdateScore(int score) {
            scoreText.text = string.Format("{0:C}",((float)score / 100)); 
        }

        public void ShowPauseScreen() {
            interfacePause.gameObject.SetActive(true);
            interfaceGame.gameObject.SetActive(false);
        }

        public void HidePauseScreen() {
            interfacePause.gameObject.SetActive(false);
            interfaceGame.gameObject.SetActive(true);
        }

        public void ShowMainMenu() {
            interfaceMainMenu.gameObject.SetActive(true);
            interfaceGame.gameObject.SetActive(false);
        }

        public void HideMainMenu() {
            interfaceMainMenu.gameObject.SetActive(false);
            interfaceGame.gameObject.SetActive(true);
        }

        public void ShowHowToPlay() {
            interfaceHowToPlay.gameObject.SetActive(true);
        }

        public void HideHowToPlay() {
            interfaceHowToPlay.gameObject.SetActive(false); 
        }

        public void ShowCredits() {
            interfaceCredits.gameObject.SetActive(true);
        }

        public void HideCredits() {
            interfaceCredits.gameObject.SetActive(false); 
        }

        public void ShowGameOver(int score) {
            interfaceGameOver.gameObject.SetActive(true);
            string scoreText = string.Format("{0:C}", ((float)score / 100)); 
            gameOverText.text = "You didn't manage to check out in time but you still ended up with " + scoreText + " worth of items.\nWant to give it another shot?"; 
        }

        public void ShowCheckout(int score, float time) {
            interfaceCheckout.gameObject.SetActive(true);
            string scoreText = string.Format("{0:C}", ((float)score / 100)); 

            int seconds = (int)time; 
            int minutes = Mathf.FloorToInt(seconds / 60);
            seconds     = seconds % 60; 

            string checkoutTime = minutes + ":" + (seconds < 10 ? "0" + seconds : "" + seconds); 

            checkoutText.text = "You managed to checkout with " + scoreText + " worth of stuff and " + checkoutTime + " left on the clock.\nWant to give it another shot?";
        }

        public void ShowCanCheckout() {
            canCheckoutText.gameObject.SetActive(true);
        }

        public void HideCanCheckout() {
            canCheckoutText.gameObject.SetActive(false);
        }
    }
}