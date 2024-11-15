using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyFPS
{
    public class PlayerCon : MonoBehaviour
    {
        [SerializeField] private GameObject damageEffect;
        [SerializeField] private float maxHealth = 20f;
        private float currentHealth;

        private bool isDeath = false;

        public AudioSource damageSound01;
        public AudioSource damageSound02;
        public AudioSource damageSound03;

        [SerializeField] private string loadScene = "GameOver";

        // ¹«±â
        public GameObject realPistol;


        private void Start()
        {
            currentHealth = maxHealth;

            if (PlayerStats.Instance.HasGun)
            {
                realPistol.SetActive(true);
            }
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;

            StartCoroutine(DamageEffect());
            CinemachinShake.Instance.PlayerHitEffect(1f, 1f, 1f);

            Debug.Log(currentHealth);

            if (currentHealth <= 0 && isDeath == false)
            {
                Die();
            }
        }

        void Die()
        {
            isDeath = true;

            Debug.Log("GAME OVER");

            SceneFade.instance.FadeOut(loadScene);
            transform.GetComponent<Collider>().enabled = false;

        }

        IEnumerator DamageEffect()
        {
            damageEffect.SetActive(true);

            int randNumber = Random.Range(1, 4);

            if (randNumber == 1)
            {
                damageSound01.Play();
            }
            else if (randNumber == 2)
            {
                damageSound02.Play();
            }
            else if (randNumber == 3)
            {
                damageSound03.Play();
            }

            yield return new WaitForSeconds(1f);

            damageEffect.SetActive(false);
        }


    }
}