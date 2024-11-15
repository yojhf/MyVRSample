using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyFPS
{ 
    public class AmmoUI : MonoBehaviour
    {
        public GameObject ammoUI;

        public TMP_Text ammoCount_Text;

        private void Start()
        {
            ShowUI();
        }

        private void Update()
        {
            if (ammoUI != null && ammoUI.activeSelf)
            {
                ammoCount_Text.text = PlayerStats.Instance.AmmoCount.ToString();
            }
        }

        void ShowUI()
        {
            if (PlayerStats.Instance.HasGun)
            {
                ammoUI.SetActive(true);
            }
            else
            {
                ammoUI.SetActive(false);
            }

        }
    }
}