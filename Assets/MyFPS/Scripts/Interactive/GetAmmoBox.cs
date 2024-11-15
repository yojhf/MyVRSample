using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{
    public class GetAmmoBox : Interactive
    {
        [SerializeField] private GameObject ammoBoxUI;
        [SerializeField] private GameObject arrow;
        [SerializeField] private int ammoCount = 7;
        protected override void Action()
        {
            base.Action();
            ammoBoxUI.SetActive(true);

            if(arrow != null)
            {
                arrow.SetActive(false);
            }

            PlayerStats.Instance.GetAmmo(ammoCount);

            Destroy(gameObject);
        }
    }
}