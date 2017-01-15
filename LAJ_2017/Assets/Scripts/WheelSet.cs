using UnityEngine;
using System.Collections;

namespace LAJ_2017 {
    public class WheelSet {
        private Wheel[] _wheels;

        public void SetWheelGroup(Wheel[] wheels) {
            _wheels = wheels; 
        }

        public void AccelerateAll(float force) {
            for (int i = 0; i < _wheels.Length; ++i) {
                _wheels[i].Accelerate(force);
            }
        }

        public void BrakeAll(float force) {
            for (int i = 0; i < _wheels.Length; ++i) {
                _wheels[i].Brake(force);
            }
        }

        public void TurnAll(float amount) {
            for (int i = 0; i < _wheels.Length; ++i) {
                _wheels[i].Turn(amount);
            }
        }
    }
}
