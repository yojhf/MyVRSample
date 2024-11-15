using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyFPS
{
    public class DoorKeyCon : Interactive
    {
        public TMP_Text tMP_Text;
        public bool isOpen = false;

        [SerializeField] private string lockText = "You have to find key";

        Animator animator;
        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
        }

        protected override void Action()
        {
            if (PlayerStats.Instance.HasPuzzleObject(ItemType.Room01_Key))
            {
                base.Action();
                animator.SetBool("isOpen", true);
                transform.GetComponent<Collider>().enabled = false;
                SoundManager.Instance.PlayBgm("DoorBang");
            }
            else
            {
                StartCoroutine(LockDoor());
            }
        }
        IEnumerator LockDoor()
        {
            unInteractive = true; // 인터렉티브 기능 정지

            SoundManager.Instance.PlayBgm("DoorLocked");

            tMP_Text.gameObject.SetActive(true);
            tMP_Text.text = lockText;

            yield return new WaitForSeconds(2f);

            tMP_Text.gameObject.SetActive(false);
            tMP_Text.text = "";

            unInteractive = false; // 인터렉티브 기능
        }
    }
}