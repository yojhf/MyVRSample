using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{
    public class EJumpTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject activeObj;
        [SerializeField] private Transform player; 



        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                StartCoroutine(ActiveTrigger());
            }
        }

        IEnumerator ActiveTrigger()
        {
            transform.GetComponent<Collider>().enabled = false;
            player.GetComponent<FirstPersonController>().enabled = false;

            activeObj.SetActive(true);

            yield return new WaitForSeconds(2f);

            player.GetComponent<FirstPersonController>().enabled = true;
            Destroy(activeObj);
            Destroy(gameObject);
        }

    }
}