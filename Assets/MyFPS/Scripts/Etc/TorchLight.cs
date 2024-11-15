using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{
    public class TorchLight : MonoBehaviour
    {
        private List<string> aniArray = new List<string>();
        private Transform torchObject;

        private int index;
        private int randomNum;
        Animator flameAnim;
        // Start is called before the first frame update
        void Start()
        {
            Init();
            //StartCoroutine(RandomAniCo());

            InvokeRepeating("RanAni", 0f, 1f);

        }

        void Init()
        {
            torchObject = transform.GetChild(0).GetChild(0);

            flameAnim = torchObject.GetComponent<Animator>();


        }

        IEnumerator RandomAniCo()
        {
            while (true)
            {
                RanAni();

                yield return new WaitForSeconds(1f);
            }

        }


        void RanAni()
        {
            randomNum = Random.Range(1, 4);

            flameAnim.SetInteger("LightMode", randomNum);
        }
    }
}