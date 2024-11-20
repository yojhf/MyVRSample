using TMPro;
using UnityEngine;

namespace MyFPS
{
    public class WorldMenu : MonoBehaviour
    {
        public GameObject worldMenuUI;
        [SerializeField] private TMP_Text textBox;
        private Transform head;
        public float distance;
        public float offset = 0f;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        protected virtual void Start()
        {
            head = Camera.main.transform;

            distance = RayCon.length;
        }

        // Update is called once per frame
        protected virtual void Update()
        {
            distance = RayCon.length;
        }

        protected void ShowText(string sequence = "")
        {
            worldMenuUI.SetActive(true);

            // show set
            if (worldMenuUI.activeSelf)
            {
                if (distance < 1.5f)
                {
                    distance -= 0.1f;
                }
                else
                {
                    distance = 1.5f;
                }

                worldMenuUI.transform.position = head.position + new Vector3(head.forward.x, 0f, head.forward.z).normalized * (distance - offset);

                worldMenuUI.transform.LookAt(new Vector3(head.position.x, worldMenuUI.transform.position.y, head.position.z));

                worldMenuUI.transform.forward *= -1;


            }

            if (textBox != null)
            {
                textBox.text = sequence;
            }
        }

        protected void HideText()
        {
            worldMenuUI.SetActive(false);
            textBox.text = "";
        }
    }

}
