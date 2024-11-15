using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyFPS
{
    public class DOpening : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private TMP_Text openingText;


        // Start is called before the first frame update
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            StartCoroutine(Opening());
        }

        IEnumerator Opening()
        {

            player.transform.GetComponent<FirstPersonController>().enabled = false;

            SoundManager.Instance.PlayBgm("PlayBgm");

            openingText.text = "";

            yield return new WaitForSeconds(1f);

            SceneFade.instance.FadeIn(null);

            yield return new WaitForSeconds(1f);

            player.transform.GetComponent<FirstPersonController>().enabled = true;



        }
    }
}