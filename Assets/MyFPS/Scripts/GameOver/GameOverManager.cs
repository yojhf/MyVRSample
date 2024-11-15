using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{
    public class GameOverManager : MonoBehaviour
    {
        [SerializeField] private string playScene = "PlayScene";

        // Start is called before the first frame update
        void Start()
        {
            SceneFade.instance.FadeIn(null);
            Cursor.lockState = CursorLockMode.None;
        }

        

        public void PlayScene()
        {
            SceneFade.instance.FadeOut(PlayerStats.Instance.SceneNum);
        }
        public void Menu()
        {
            SceneFade.instance.FadeOut("MainMenu");
        }
    }
}