using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


namespace MyFPS
{
    public class RayCon : MonoBehaviour
    {
        Transform target;
        public static float length = 1f;

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


            if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward), out hit))
            {
                length = hit.distance;

                //if(hit.collider.tag == "Door")
                //{
                //    target = hit.collider.transform;
                //    target.GetComponent<DoorCon>().isOpen = true;
                //}

                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * length, Color.red);

            }
            else
            {
                //if(target != null)
                //{
                //    target.GetComponent<DoorCon>().isOpen = false;
                //}
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