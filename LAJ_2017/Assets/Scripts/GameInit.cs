using UnityEngine;
using System.Collections;

namespace LAJ_2017 {
    public class GameInit : MonoBehaviour {
        private void Awake() {
            Top.gameHandler      = FindObjectOfType<GameHandler>();
            Top.inputHandler     = FindObjectOfType<InputHandler>();
            Top.soundHandler     = FindObjectOfType<SoundHandler>(); 
            Top.interfaceHandler = FindObjectOfType<InterfaceHandler>();
            Destroy(gameObject);
        }
    }
}
