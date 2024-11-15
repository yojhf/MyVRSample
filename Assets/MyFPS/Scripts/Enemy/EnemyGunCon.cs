using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace MyFPS
{
    public enum EnemyState
    {
        E_Idle,
        E_Walk,
        E_Attack,
        E_Death,
        E_Chase
    }

    public class EnemyGunCon : RobotCon, IDamage
    {
        public EnemyState enemyState;
        private EnemyState e_beforeState;

        public List<Transform> wayPoints = new List<Transform>();
        public Transform wayPoint;
        private int nowWayPoint = 0;

        private Vector3 startPos;

        public float SearchRange = 5f;

        private bool isAiming = false;

        public bool IsAiming
        {
            get 
            {
                return isAiming;
            }
            set
            {
                isAiming = value;
            }
        }

        NavMeshAgent agent;

        protected override void Init()
        {
            agent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();

            player = GameObject.Find("PlayerCapsule").gameObject;
   

            for(int i = 0; i < wayPoint.childCount; i++)
            {
                wayPoints.Add(wayPoint.GetChild(i));  
            }


            currentHealth = maxHealth;


            startPos = transform.position;

            if(wayPoints.Count > 0)
            {
                E_SetState(EnemyState.E_Walk);
                GoNextPoint();
            }
            else
            {
                E_SetState(EnemyState.E_Idle);
            }



        }

        protected override void ChangeState()
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);

            if(SearchRange > 0)
            {
                IsAiming = distance <= SearchRange;
            }

            if (distance <= attackRange)
            {
                E_SetState(EnemyState.E_Attack);
            }
            else if (IsAiming)
            {
                E_SetState(EnemyState.E_Chase);
            }
            else if (!IsAiming)
            {
                E_SetState(EnemyState.E_Walk);
            }


            switch (enemyState)
            {
                case EnemyState.E_Idle:

                    break;
                case EnemyState.E_Walk:
                    if (agent.remainingDistance <= 0.2f)
                    {
                        GoNextPoint();
                    }
                    else
                    {
                        E_SetState(EnemyState.E_Walk);
                    }
                    break;
                case EnemyState.E_Attack:
                    RobotRot();
                    if (distance >= attackRange)
                    {
                        E_SetState(EnemyState.E_Chase);
                        agent.SetDestination(transform.position);
                    }
                    break;
                case EnemyState.E_Chase:    
                    
                    //if(SearchRange > 0 && !IsAiming)
                    //{
                    //    GoNextPoint();
                    //}

                    agent.SetDestination(player.transform.position);
                    break;

            }
        }

        protected override void Die()
        {
            transform.GetComponent<Collider>().enabled = false;

            isDeath = true;

            E_SetState(EnemyState.E_Death);

            Destroy(gameObject, 3f);
        }

        public void E_SetState(EnemyState state)
        {
            if (enemyState == state)
            {
                return;
            }

            e_beforeState = enemyState;

            enemyState = state;

            if(enemyState == EnemyState.E_Chase)
            {
                animator.SetInteger("EnemyGunState", 1);
                animator.SetLayerWeight(1, 1);
            }
            else
            {
                animator.SetInteger("EnemyGunState", (int)state);
                animator.SetLayerWeight(1, 0);
            }

            agent.ResetPath();
        }

        void GoNextPoint()
        {
            nowWayPoint++;

            if(nowWayPoint >= wayPoints.Count)
            {
                nowWayPoint = 0;
            }

            agent.SetDestination(wayPoints[nowWayPoint].position);
        }


        private void OnDrawGizmosSelected()
        {
            if (transform == null)
            {
                return;
            }

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, SearchRange);
        }
    }
}