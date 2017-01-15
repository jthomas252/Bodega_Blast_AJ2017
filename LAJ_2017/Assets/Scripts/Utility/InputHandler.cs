using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine; 

namespace LAJ_2017 {
    public class InputHandler : MonoBehaviour {
        public delegate void InputEvent(bool pressed, float analog = 0f);

        public InputEvent OnForward;
        public InputEvent OnBackward; 
        public InputEvent OnLeft; 
        public InputEvent OnRight;

        public struct InputBind {

        }
        public InputBind[] inputs; 

        private void Awake() {
            //Bind input events here
        }

        public void Update() {

        }
    }
}
