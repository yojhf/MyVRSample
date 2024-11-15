using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{
    public class EnemyZone : MonoBehaviour
    {
        public EnemyState enemyState;

        public Transform enemyGun;
        public GameObject enemyZoneOut;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if(enemyGun != null)
                {
                    EnemyGunCon enemyGunCon = enemyGun.GetComponent<EnemyGunCon>();

                    if (enemyGunCon != null)
                    {
                        enemyGunCon.E_SetState(enemyState);
                        enemyZoneOut.SetActive(true);
                        gameObject.SetActive(false);
                    }
                }

             


            }
        }
    }
}