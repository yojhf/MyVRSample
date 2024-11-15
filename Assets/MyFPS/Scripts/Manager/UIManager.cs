using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace MyFPS
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] private Transform pauseUI;
        [SerializeField] private GameObject player;

        public bool isPause = false;
        private float timeScale = 0;

        // Start is called before the first frame update
        void Start()
        {
            player = GameObject.FindWithTag("Player") ;
        }

        // Update is called once per frame
        void Update()
        {
            PauseUI();
        }

        void PauseUI()
        {
            //if (Input.GetKeyDown(KeyCode.Escape))
            //{
            //    Toggle();
            //}
        }

        public void Pause()
        {
            Time.timeScale = timeScale;
        }
        public void ResetPause()
        {
            isPause = false;
            pauseUI.gameObject.SetActive(false);
            // 일시정시 원복
            Time.timeScale = 1.0f;
            Cursor.lockState = CursorLockMode.Locked;
            player.GetComponent<FirstPersonController>().enabled = true;
        }

        public void Toggle()
        {
            pauseUI.gameObject.SetActive(!pauseUI.gameObject.activeSelf);

            if (pauseUI.gameObject.activeSelf)
            {
                isPause = true;
                pauseUI.gameObject.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                player.GetComponent<FirstPersonController>().enabled = false;
                Pause();
            }
            else
            {
                ResetPause();
            }

        }

    }
}