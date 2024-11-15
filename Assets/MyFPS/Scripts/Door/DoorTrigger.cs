using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{
    public class DoorTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject enemy;
        [SerializeField] private GameObject door;

        public AudioSource doorBang;
        public AudioSource jumpScare;
        public AudioSource mainBgm;

        Animator animator;
        // Start is called before the first frame update
        void Start()
        {
            animator = door.GetComponent<Animator>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Player"))
            {
                StartCoroutine(DoorOpen());
            }
        }

        IEnumerator DoorOpen()
        {
            animator.SetBool("isOpen", true);
            transform.GetComponent<Collider>().enabled = false;

            mainBgm.Stop();
            doorBang.Play();

            enemy.SetActive(true);

            yield return new WaitForSeconds(1f);


            jumpScare.Play();

            EnemyWalk();

            Destroy(gameObject);

        }

        void EnemyWalk()
        {
            RobotCon robotCon = enemy.transform.GetComponent<RobotCon>();

            if (robotCon != null)
            {
                robotCon.SetState(RobotState.R_Walk);
            }

        }
    }
}