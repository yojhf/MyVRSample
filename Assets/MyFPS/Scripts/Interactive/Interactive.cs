using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyFPS
{
    public class Interactive : MonoBehaviour
    {
        [SerializeField] protected GameObject actionUI;
        [SerializeField] protected GameObject crossHair;
        [SerializeField] protected string actionText;

        // true이면 Interactive 기능 정지
        protected bool unInteractive = false;

        private void OnMouseOver()
        {
            if (RayCon.length <= 2f)
            {
                ActiveTrigger();

                //if (Input.GetButtonDown("Action") && unInteractive == false)
                //{
                //    Action();
                //}
            }
        }
        private void OnMouseExit()
        {
            DisActive();
        }


        protected virtual void ActiveTrigger()
        {
            actionUI.SetActive(true);
            crossHair.SetActive(true);
            actionUI.transform.GetChild(1).GetComponent<TMP_Text>().text = actionText;
        }   

        protected virtual void Action()
        {
            actionUI.SetActive(false);
            crossHair.SetActive(false);
        }

        protected virtual void DisActive()
        {
            actionUI.SetActive(false);
            crossHair.SetActive(false);
        }

    }
}