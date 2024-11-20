using UnityEngine;

namespace MyFPS
{
    public class XRPickUpPistol : GrabInteractable
    {
        //[SerializeField] private GameObject playerPistol;
        [SerializeField] private GameObject arrow;
        [SerializeField] private GameObject arrow2;
        [SerializeField] private GameObject ammoBox;
        [SerializeField] private GameObject enemyTrigger;

        public AmmoUI ammoUI;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        protected override void Action()
        {
            if (PlayerStats.Instance.HasGun == false)
            {
                base.Action();

                ammoUI.ShowAmmoUI();

                arrow.SetActive(false);
                enemyTrigger.SetActive(true);

                PlayerStats.Instance.SetHasGun(true);

                //playerPistol.SetActive(true);
                arrow2.SetActive(true);
                ammoBox.SetActive(true);


            }

        }
    }
}