using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{
    public class BreakObject : MonoBehaviour, IDamage
    {
        [SerializeField] private GameObject breakObj;
        [SerializeField] private GameObject effectObj;
        [SerializeField] private GameObject hiddenObj;

        private bool isBreak = false;
        public bool unBreak = false;

        public void TakeDamage(float damage)
        {
            if(unBreak)
            {
                return;
            }

            if(isBreak == false)
            {
                StartCoroutine(ChangeObj());
            }

        }


        IEnumerator ChangeObj()
        {
            isBreak = true;

            transform.GetComponent<Collider>().enabled = false;
            SoundManager.Instance.PlayBgm("PotterySmash");
            breakObj.SetActive(true);

            if(effectObj != null)
            {
                effectObj.SetActive(true);
            }

            if (hiddenObj != null)
            {
                hiddenObj.SetActive(true);
            }

            Destroy(transform.GetChild(0).gameObject);

            yield return null;  
        }
    }
}