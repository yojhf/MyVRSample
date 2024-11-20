using System.Collections;
using UnityEngine;

namespace MyFPS
{
    public class XRDoorCellExit : SimpleInteractable
    {
        [SerializeField] private string loadScene = "PlayScene";

        public AudioSource openSound;
        public AudioSource mainBgm;

        Animator animator;

        protected override void Start()
        {
            base.Start();
            animator = GetComponent<Animator>();
        }

        protected override void Action()
        {
            animator.SetBool("isOpen", true);
            transform.GetComponent<Collider>().enabled = false;
            openSound.Play();

            StartCoroutine(ChangeSc());
        }

        void ChangeScene()
        {
            mainBgm.Stop();


        }

        IEnumerator ChangeSc()
        {
            mainBgm.Stop();
            SceneFade.instance.FadeOut(null);
            yield return new WaitForSeconds(2f);

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit(); // 어플리케이션 종료
#endif

        }


    }
}