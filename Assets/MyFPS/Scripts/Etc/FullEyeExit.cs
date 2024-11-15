using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace MyFPS
{
    public class FullEyeExit : Interactive
    {
        [SerializeField] private GameObject exitDoor;

        [SerializeField] private Material eye;
        
        public TMP_Text tMP_Text;

        [SerializeField] private string lockText = "You have to find Eye";

        MeshRenderer MeshRenderer;
        Animator animator;

        private void Start()
        {
            MeshRenderer = GetComponent<MeshRenderer>();
            animator = exitDoor.GetComponent<Animator>();
        }

        protected override void Action()
        {
            if (PlayerStats.Instance.HasPuzzleObject(ItemType.LeftEye) && PlayerStats.Instance.HasPuzzleObject(ItemType.RightEye))
            {
                base.Action();
                StartCoroutine(ActiveFullEye());
            }
            else
            {
                StartCoroutine(TriggerEye());
            }
        }

        IEnumerator ActiveFullEye()
        {
            MeshRenderer.material = eye;

            transform.GetComponent<Collider>().enabled = false;

            yield return new WaitForSeconds(1f);

            animator.SetBool("isOpen", true);
        }

        IEnumerator TriggerEye()
        {
            unInteractive = true; // 인터렉티브 기능 정지

            tMP_Text.gameObject.SetActive(true);
            tMP_Text.text = lockText;



            yield return new WaitForSeconds(2f);

            tMP_Text.gameObject.SetActive(false);
            tMP_Text.text = "";

            unInteractive = false; // 인터렉티브 기능
        }
    }
}