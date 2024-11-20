using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

namespace MyFPS
{
    public class BFirstTrigger : WorldMenu
    {
        [SerializeField] private GameObject arrow;
        [SerializeField] private GameObject locomotion;
        [SerializeField] private TMP_Text openingText;
        [SerializeField] private string opening_text = "Looks like a weapon on that table.";


        public AudioSource line03;


        IEnumerator FirstTrigger()
        {
            locomotion.SetActive(false);

            ShowText(opening_text);
            //openingText.text = opening_text;
            //openingText.gameObject.SetActive(true);
            line03.Play();

            yield return new WaitForSeconds(1f);

            arrow.SetActive(true);

            yield return new WaitForSeconds(1f);

            HideText();
            //openingText.text = "";
            //openingText.gameObject.SetActive(false);
            locomotion.SetActive(true);
            GetComponent<Collider>().enabled = false;
            Destroy(gameObject);
 
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                StartCoroutine(FirstTrigger());

            }
        }
    }
}