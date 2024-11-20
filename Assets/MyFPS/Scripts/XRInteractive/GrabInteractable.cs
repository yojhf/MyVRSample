using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

namespace MyFPS
{
    public abstract class GrabInteractable : XRGrabAttach
    {
        private float distance;
        [SerializeField] protected GameObject actionUI;
        //[SerializeField] protected GameObject crossHair;
        [SerializeField] protected string actionText;
        // true이면 Interactive 기능 정지
        protected bool unInteractive = false;

        private bool isHover = false;

        private Transform head;

        private Vector3 grabPos;
        public float offset = 0f;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        protected virtual void Start()
        {
            head = Camera.main.transform;
        }

        // Update is called once per frame
        protected virtual void Update()
        {
            if (unInteractive)
                return;

            //distance = RayCon.length;

            distance = GetDistanceFormTarget();
        }

        protected override void OnHoverEntered(HoverEnterEventArgs args)
        {

            base.OnHoverEntered(args);

            if (unInteractive)
                return;

            if (distance < 2.0f)
            {
               
                ActiveTrigger();
            }
            

            ActiveTrigger();

        }
        protected override void OnHoverExited(HoverExitEventArgs args)
        {
            base.OnHoverExited(args);


            DisActive();
        }
        protected override void OnSelectEntered(SelectEnterEventArgs args)
        {
            base.OnSelectEntered(args);

            if (unInteractive)
                return;


            if (distance < 2.0f)
            {

                unInteractive = true;

                Action();
            }
            
        }

        protected override void OnSelectExited(SelectExitEventArgs args)
        {
            base.OnSelectExited(args);

            unInteractive = false;
        }

        protected virtual void ActiveTrigger()
        {
            isHover = true;

            actionUI.SetActive(true);

            // distance와 오브젝트까지의 거리를 계산
            float _distance = Vector3.Distance(head.position, transform.position);

            if (_distance < distance)
            {
                actionUI.transform.position = head.position + new Vector3(head.forward.x, 0f, head.forward.z).normalized * (_distance - 0.02f);

            }
            else
            {
                actionUI.transform.position = head.position + new Vector3(head.forward.x, 0f, head.forward.z).normalized * (distance - 0.02f);
            }

            //crossHair.SetActive(true);
            actionUI.transform.position = head.position + new Vector3(head.forward.x, 0f, head.forward.z).normalized * (distance - 0.02f);
            actionUI.transform.LookAt(new Vector3(head.position.x, head.position.y, head.position.z));
            actionUI.transform.forward *= -1;

            actionUI.transform.GetChild(0).GetChild(0).GetChild(1).GetComponent<TMP_Text>().text = actionText;
        }

        protected virtual void Action()
        {
            isHover = false;
            actionUI.SetActive(false);
            //crossHair.SetActive(false);
        }

        protected virtual void DisActive()
        {
            isHover = false;
            actionUI.SetActive(false);
            //crossHair.SetActive(false);
        }

        float GetDistanceFormTarget()
        {
            float _distance = 0f;
            Vector3 pos = new Vector3(transform.position.x, head.position.y, transform.position.z);
            _distance = Vector3.Distance(pos, head.position);

            return _distance;
        }
    }
}