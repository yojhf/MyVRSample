using UnityEngine;
using UnityEngine.InputSystem;

namespace MyVRSample
{
    public class ActiveTeleport : MonoBehaviour
    {
        public GameObject leftRay_TP;
        public GameObject rightRay_TP;

        public InputActionProperty leftAction;
        public InputActionProperty rightAction;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            ShowRay();
        }

        void ShowRay()
        {
            float leftValue = leftAction.action.ReadValue<float>();
            float rightValue = rightAction.action.ReadValue<float>();

            if(leftValue > 0.1f)
            {
                leftRay_TP.SetActive(true);
            }
            else
            {
                leftRay_TP.SetActive(false);
            }
            if (rightValue > 0.1f)
            {
                rightRay_TP.SetActive(true);
            }
            else
            {
                rightRay_TP.SetActive(false);
            }
        }
    }

}
