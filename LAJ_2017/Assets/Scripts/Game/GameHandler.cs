using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; 

namespace LAJ_2017 {
    public class GameHandler : MonoBehaviour {
        private bool _paused;
        public bool paused {
            get {
                return _paused; 
            }
        }

        private bool  panic     = false; 
        private bool  showMenu  = false;
        private float _gameTime = 0; 
        private int   score     = 0; 

        public float gameTime  = 120.00f;
        public float panicTime = 60f;

        public Vector3 cameraMainMenuPos; 
        public Vector3 cameraMainMenuRot;

        private void Update() {
            if (!paused) {
                _gameTime -= Time.deltaTime;
                Top.interfaceHandler.UpdateTime(_gameTime);
                Top.interfaceHandler.UpdateScore(score); 
            }

            if (Input.GetKeyDown(KeyCode.R)) {
                Reset();
            }

            if (showMenu) {
                Camera.main.transform.Rotate(new Vector3(0f,0.25f,0f)); 
            }
        }

        public void Reset() {
            Scene scene = SceneManager.GetActiveScene(); 
            SceneManager.LoadScene(scene.buildIndex); 
        }

        public void ShowMainMenu() {
            showMenu = true; 
            _paused  = true; 
            Top.soundHandler.PlayMusic("Muzak");
            Camera.main.transform.position    = cameraMainMenuPos;
            Camera.main.transform.eulerAngles = cameraMainMenuRot;
        }

        public void StartGame() {
            score    = 0; 
            _paused  = false; 
            showMenu = false;
            Top.soundHandler.PlayMusic("Main");
        }

        private void OnDrawGizmos() {
            Gizmos.color = Color.red; 
            Gizmos.DrawSphere(cameraMainMenuPos, 0.2f);
        }
    }
}