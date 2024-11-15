using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyFPS
{
    public class Title : MonoBehaviour
    {

        [SerializeField] private Transform anykey_text;
        [SerializeField] private float waitTime = 3f;
        [SerializeField] private float startTime = 0f;
        [SerializeField] private float endTime = 10f;
        [SerializeField] private string mainMenu = "MainMenu";

        void Start()
        {
            //StartCoroutine(GameStart());

            //SceneFade.instance.FadeIn(null);
        }

        private void Update()
        {
            Invoke("SetActive", 3f);
            Invoke("LoadMenu", 10f);


            //Timer();
            StartGame();
        }

        IEnumerator GameStart()
        {
            yield return new WaitForSeconds(waitTime);

            anykey_text.gameObject.SetActive(true);
        }

        void Timer()
        {
            startTime += Time.deltaTime;

            if (startTime >= endTime)
            {
                LoadMenu();
            }
        }

        void StartGame()
        {
            if (anykey_text.gameObject.activeSelf == true)
            {
                if (Input.anyKeyDown)
                {
                    SceneFade.instance.FadeOut(mainMenu);
                }
            }
        }

        void LoadMenu()
        {
            SceneManager.LoadScene(mainMenu);
        }



        void SetActive()
        {
            anykey_text.gameObject.SetActive(true);
        }
    }
}
