using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{
    public class LookAtMouse : MonoBehaviour
    {
        // 마우스가 가르키는 월드 공간 값
        [SerializeField] private Vector3 worldPos;



        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            RotPos();
        }

        void RotPos()
        {
            worldPos = ScreenToWorld();

            transform.LookAt(worldPos);
        }

        Vector3 ScreenToWorld()
        {
            Vector3 mousePos = Input.mousePosition;

            mousePos.z = 3f;

            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);


            return worldPos;
        }

        Vector3 RayToWorld()
        {
            Vector3 worldPos = Vector3.zero;

            Vector3 mousePos = Input.mousePosition;

            Ray ray = Camera.main.ScreenPointToRay(mousePos);

            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                worldPos = hit.point;
            }

            return worldPos;
        }
    }
}