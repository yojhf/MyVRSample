using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyFPS
{ 
    public class AmmoUI : WorldMenu
    {
        public float delay = 2f;

        // AmmoUI를 보여주고 2초후에 사라진다
        public void ShowAmmoUI()
        {
            StartCoroutine(ShowUI());
        }



        IEnumerator ShowUI()
        {
            ShowText(PlayerStats.Instance.AmmoCount.ToString());

            yield return new WaitForSeconds(delay);

            HideText();
        }
    }
}