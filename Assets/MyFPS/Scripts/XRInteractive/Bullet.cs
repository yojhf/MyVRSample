using UnityEngine;

namespace MyFPS
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float attackDamage = 5f;
        [SerializeField] private Transform hitEffect;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void OnCollisionEnter(Collision collision)
        {
            Transform effect = Instantiate(hitEffect, transform.position, Quaternion.LookRotation(transform.forward * -1));
            Destroy(effect.gameObject, 2f);

            IDamage iDamage = collision.transform.GetComponent<IDamage>();

            if (iDamage != null)
            {
                iDamage.TakeDamage(attackDamage);
            }


            Destroy(gameObject, 3f);

        }
    }


}
