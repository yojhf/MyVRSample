using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;


namespace MyFPS
{
    public class PistolShoot : MonoBehaviour
    {
        public AmmoUI ammoUI;
        [SerializeField] private Transform hitEffect;
        [SerializeField] private float impactForce = 5f;

        public ParticleSystem pistolFire;
        public AudioSource shootSound;

        //public Transform camera;
        public Transform firePoint;

        private float fireDelay = 0.5f;
        private bool isFire = false;

        [SerializeField] private float attackDamage = 5f;

        Animator animator;



        //

        public GameObject bullet;

        public float bulletSpeed = 20f;



        // Start is called before the first frame update
        void Start()
        {
            //animator = GetComponent<Animator>();

            XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();

            grabInteractable.activated.AddListener(Fire);

        }

        // Update is called once per frame
        void Update()
        {
            //if (InputActManager.Instance.IsRightAct() == true && isFire == false && UIManager.Instance.isPause == false)
            //{
            //    if (PlayerStats.Instance.AmmoCount > 0)
            //    {
            //        StartCoroutine(Shoot());
            //    }


            //}



        }

        void Fire(ActivateEventArgs args)
        {
            if (isFire == false && PlayerStats.Instance.AmmoCount > 0)
            {
                StartCoroutine(Shoot());
            }
        }

        IEnumerator Shoot()
        {
            isFire = true;

            ammoUI.ShowAmmoUI();

            //float maxdis = 100f;

            //RaycastHit hit;

            PlayerStats.Instance.UseAmmo();

            //if (Physics.Raycast(firePoint.position, firePoint.TransformDirection(Vector3.forward), out hit, maxdis))
            //{
            //    Transform tmp_effect = Instantiate(hitEffect, hit.point, Quaternion.identity);

            //    Destroy(tmp_effect.gameObject, 2f);

            //    if (hit.rigidbody != null)
            //    {
            //        hit.rigidbody.AddForce(-hit.normal * impactForce, ForceMode.Impulse);            
            //    }

            //    IDamage iDamage = hit.transform.GetComponent<IDamage>();

            //    if (iDamage != null)
            //    {
            //        iDamage.TakeDamage(attackDamage);
            //    }
            //}


            GameObject _bullet = Instantiate(bullet, firePoint.position, firePoint.rotation);

            _bullet.GetComponent<Rigidbody>().linearVelocity = firePoint.forward * bulletSpeed;

            pistolFire.gameObject.SetActive(true);
            pistolFire.Play();

            //animator.SetTrigger("Fire");

            shootSound.Play();

            yield return new WaitForSeconds(fireDelay);

            pistolFire.Stop();
            pistolFire.gameObject.SetActive(false);

            isFire = false;
        }

        //private void OnDrawGizmosSelected()
        //{
        //    float maxdis = 100f;
        //    RaycastHit hit;
        //    Gizmos.color = Color.red;
        //    bool isHit = Physics.Raycast(firePoint.position, firePoint.TransformDirection(Vector3.forward), out hit);

        //    if (isHit)
        //    {
        //        Gizmos.DrawRay(firePoint.position, firePoint.forward * hit.distance);
        //    }
        //    else
        //    {
        //        Gizmos.DrawRay(transform.position, transform.forward * maxdis);
        //    }
        //}

    }
}