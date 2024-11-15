using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyFPS
{
    public class DoorCon : Interactive
    {
        [SerializeField] private Transform soundObject;
        public bool isOpen = false;
        Animator animator;

        // Start is called before the first frame update
        void Start()
        {
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
