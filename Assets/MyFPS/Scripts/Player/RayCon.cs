using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


namespace MyFPS
{
    public class RayCon : MonoBehaviour
    {
        // interactable Layer üũ
        public LayerMask LayerMask;

        Transform target;
        public static float length = Mathf.Infinity;
        private float toTarget;


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            RayControll();
        }
        

        void RayControll()
        {
            RaycastHit hit;


            if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward), out hit, 100f, LayerMask))
            {
                toTarget = hit.distance;
                length = toTarget;

                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * length, Color.red);

            }
            else
            {
                toTarget = Mathf.Infinity;
                length = toTarget;
            }


        }

        private void OnDrawGizmosSelected()
        {
            float maxdis = 100f;
            RaycastHit hit;
            Gizmos.color = Color.red;
            bool isHit = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit);

            if (isHit)
            {
                Gizmos.DrawRay(transform.position, transform.forward * hit.distance);
            }
            else
            {
                Gizmos.DrawRay(transform.position, transform.forward * maxdis);
            }
        }
    }
}