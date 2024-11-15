using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{
    public class FExitTrigger : MonoBehaviour
    {
        public string loadScene = "MainMenu";

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                EndGame();
            }

        }

        void EndGame()
        {
            Cursor.lockState = CursorLockMode.None;   
            SoundManager.Instance.Stop(null);
            SceneFade.instance.FadeOut(loadScene);
        }
    }
}