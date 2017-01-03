using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine; 

namespace LAJ2017 {
    public class InputHandler : MonoBehaviour {
        public delegate void InputEvent(bool pressed);

        public InputEvent OnForward;
        public InputEvent OnBackward; 
        public InputEvent OnLeft; 
        public InputEvent OnRight;

        private void Awake() {
            //Bind input events here
        }

        public void Update() {

        }
    }
}
