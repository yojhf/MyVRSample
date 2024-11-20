using UnityEngine;

namespace MyFPS
{
    public class XRDoorCellOpen : SimpleInteractable
    {
        [SerializeField] private Transform soundObject;
        public bool isOpen = false;
        Animator animator;

        protected override void Start()
        {
            base.Start();
            animator = GetComponent<Animator>();
        }
        protected override void Action()
        {
            base.Action();
            animator.SetBool("isOpen", true);
            transform.GetComponent<Collider>().enabled = false;
            soundObject.GetComponent<AudioSource>().Play();
        }
    }
}