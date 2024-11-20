using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Turning;

namespace MyFPS
{
    public class InGameMenu : MonoBehaviour
    {
        public GameObject gameMenu;
        private Transform head;

        public float yOffset = 1.36f;
        public float distance = 1.5f;

        public InputActionProperty showBtn;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            head = Camera.main.transform;
        }

        // Update is called once per frame
        void Update()
        {
            distance = RayCon.length;

            if (showBtn.action.WasPressedThisFrame())
            {
                Toggle();
            }
        }

        void Toggle()
        {
            gameMenu.SetActive(!gameMenu.activeSelf);

            // show set
            if (gameMenu.activeSelf)
            {
                if (distance < 1.5f)
                {
                    distance -= 0.1f;
                }
                else
                {
                    distance = 1.5f;
                }

                gameMenu.transform.position = head.position + new Vector3(head.forward.x, yOffset, head.forward.z).normalized * distance;

                gameMenu.transform.LookAt(new Vector3(head.position.x, gameMenu.transform.position.y, head.position.z));

                gameMenu.transform.forward *= -1;
            }
        }

        public void Continue()
        {
            gameMenu.SetActive(false);
        }

        public void QuitBtn()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit(); // 어플리케이션 종료
#endif
        }
    }
}