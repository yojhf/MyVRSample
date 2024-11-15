using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyFPS
{
    public class PauseUI : MonoBehaviour
    {
        public string playScene = "PlayScene";
        public string menuScene = "MainMenu";

        private void Start()
        {

        }

        private void OnEnable()
        {
            
        }

        public void Retry()
        {
            SceneFade.instance.FadeOut(SceneManager.GetActiveScene().name);
            // 일시정시 원복
            Time.timeScale = 1.0f;

        }
        public void Menu()
        {
            gameObject.SetActive(false);
            SceneFade.instance.FadeOut(menuScene);
            Time.timeScale = 1.0f;
        }
        public void Continue()
        {
            UIManager.Instance.ResetPause();
        }


    }
}
