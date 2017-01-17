using UnityEngine;
using System.Collections;

namespace LAJ_2017 {
    public class GameInit : MonoBehaviour {
        private static GameInit original; 
        private bool loaded = false; 

        public void Awake() {
            GameObject.DontDestroyOnLoad(gameObject);
            if (original != null && original != this) {
                original.Awake();
                Destroy(gameObject);
                return;
            }

            original = this;

            Top.gameHandler      = FindObjectOfType<GameHandler>();
            Top.inputHandler     = FindObjectOfType<InputHandler>();
            Top.soundHandler     = FindObjectOfType<SoundHandler>(); 
            Top.interfaceHandler = FindObjectOfType<InterfaceHandler>();

            if (loaded) {
                Top.gameHandler.StartGame();
            } else {
                Top.gameHandler.ShowMainMenu(); 
            }

            loaded = true; 
        }
    }
}
