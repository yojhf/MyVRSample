using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using StarterAssets;

namespace MyFPS
{
    public class AOpening : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private TMP_Text openingText;
        [SerializeField] private string opening_text = "I need get out of here";
        [SerializeField] private string opening_text_2 = "... Where am i?";

        public AudioSource line01;
        public AudioSource line02;

        // Start is called before the first frame update
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            StartCoroutine(Opening());
        }

        IEnumerator Opening()
        {
            //0.플레이 캐릭터 비 활성화
            //1.페이드인 연출(1초 대기후 페인드인 효과)
            //2.화면 하단에 시나리오 텍스트 화면 출력(3초)
            //  (I need get out of here)
            //3. 3초후에 시나리오 텍스트 없어진다
            //4.플레이 캐릭터 활성화

            //player.SetActive(false);
            player.transform.GetComponent<FirstPersonController>().enabled = false;
            SceneFade.instance.FadeIn(null, 4f);
            openingText.gameObject.SetActive(true);
            openingText.text = opening_text_2;
            line01.Play();

            yield return new WaitForSeconds(3f);

            openingText.text = opening_text;
            line02.Play();

            yield return new WaitForSeconds(3f);

            openingText.gameObject.SetActive(false);
            player.transform.GetComponent<FirstPersonController>().enabled = true;
            //player.SetActive(true);
        }
    }
}