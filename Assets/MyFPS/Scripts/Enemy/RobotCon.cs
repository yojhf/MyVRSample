using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{
    public enum RobotState
    {
        R_Idle,
        R_Walk,
        R_Attack,
        R_Death
    }


    public class RobotCon : MonoBehaviour, IDamage
    {
        public GameObject player;

        public RobotState robotState;

        private RobotState beforeState;

        [SerializeField] protected float maxHealth = 20f;
        protected float currentHealth;

        protected bool isDeath = false;

        [SerializeField] protected float moveSpeed = 2f;

        [SerializeField] protected float attackRange = 1.5f;
        [SerializeField] protected float attackDamage = 5f;
        [SerializeField] private float attackTimer = 2f;
        private float countDown;

        public AudioSource jumpScare;
        public AudioSource mainBgm;

        protected Animator animator;

        private bool isAttack = false;

        // Start is called before the first frame update
        protected virtual void Start()
        {
            Init();
        }

        // Update is called once per frame
        protected virtual void Update()
        {
            if(isDeath == true)
            {
                return;
            }

            ChangeState();
        }

        protected virtual void Init()
        {
            animator = GetComponent<Animator>();

            SetState(RobotState.R_Idle);

            currentHealth = maxHealth;
        }

        protected virtual void ChangeState()
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);

            if (distance <= attackRange)
            {
                SetState(RobotState.R_Attack);
            }

            switch (robotState)
            {
                case RobotState.R_Idle:

                    break;
                case RobotState.R_Walk:
                        Move();
                        RobotRot();                 
                    break;
                case RobotState.R_Attack:
                    if (distance > attackRange && isAttack == false)
                    {
                        SetState(RobotState.R_Walk);
                    }
                    break;
                //case RobotState.R_Death:
                //    break;

            }
        }

        public void SetState(RobotState state)
        {
            if (robotState == state)
            {
                return;
            }

            robotState = state;
            animator.SetInteger("RobotState", (int)state);
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;

            Debug.Log(currentHealth);

            if(currentHealth <= 0 && isDeath == false)
            {
                Die();
            }
        }

        protected virtual void Die()
        {
            isDeath = true;

            jumpScare.Stop();
            mainBgm.Play();

            SetState(RobotState.R_Death);
            transform.GetComponent<Collider>().enabled = false;
        }

        void Move()
        {
            Vector3 dir = player.transform.position - transform.position;         

            transform.Translate(dir.normalized * Time.deltaTime * moveSpeed, Space.World);    
        }

        protected void RobotRot()
        {
            transform.LookAt(player.transform.position);
        }

        void AttackCoolTime()
        {
            if(countDown > attackTimer)
            {
                countDown = 0;
            }
            countDown += Time.deltaTime;
        }

        public void EnemyAttack()
        {
            PlayerCon playerCon = player.transform.GetComponent<PlayerCon>();

            if (playerCon != null)
            {
                playerCon.TakeDamage(attackDamage);
            }

        }

    }
}