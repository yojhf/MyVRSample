using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{
    public class PickUpObject : MonoBehaviour
    {
        [SerializeField] private float speed = 2.0f;
        [SerializeField] private float rotSpeed = 360f;
        [SerializeField] private float pos = 1f;


        private Vector3 startPos;

        // Start is called before the first frame update
        void Start()
        {
            startPos = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            MoveObject();
        }

        void MoveObject()
        {
            float bobingAnimationPhase = Mathf.Sin(Time.time * speed);

            transform.position = startPos + (Vector3.up * bobingAnimationPhase) / pos;

            transform.Rotate(Vector3.up, rotSpeed * Time.deltaTime, Space.World);
        }

        // æ∆¿Ã≈€ »πµÊ º∫∞¯, Ω«∆– π›»Ø
        protected virtual bool OnPickUp()
        {
            // æ∆¿Ã≈€ »πµÊ


            return true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (OnPickUp())
                {
                    Destroy(gameObject);
                }
            }
        }

    }
}