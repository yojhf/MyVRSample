using UnityEngine;

namespace MyFPS
{
    public class XRPickUpAmmoBox : SimpleInteractable
    {
        [SerializeField] private GameObject ammoBoxUI;
        [SerializeField] private GameObject arrow;
        [SerializeField] private int ammoCount = 7;
        public AmmoUI ammoUI;

        protected override void Action()
        {
            base.Action();
            ammoBoxUI.SetActive(true);

            if (arrow != null)
            {
                arrow.SetActive(false);
            }

            PlayerStats.Instance.GetAmmo(ammoCount);

            ammoUI.ShowAmmoUI();

            Destroy(gameObject);
        }
    }
}