using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace MyFPS
{
    public class PickUpPuzzleItem : Interactive
    {
        public ItemType itemType;

        public GameObject puzzleUI;
        public Image itemImage;
        public TMP_Text puzzleText;

        public Sprite itemSprite;
        [SerializeField] private string puzzleStr = "Get Item";

        protected override void Action()
        {
            base.Action();

            StartCoroutine(GetPuzzleObject());
        }

        IEnumerator GetPuzzleObject()
        {
            PlayerStats.Instance.GetPuzzleObject(itemType);

            transform.GetChild(0).gameObject.SetActive(false);

            transform.GetComponent<Collider>().enabled = false;

            if (puzzleUI != null)
            {
                puzzleUI.SetActive(true);

                itemImage.sprite = itemSprite;

                puzzleText.text = puzzleStr;

                yield return new WaitForSeconds(2f);

                puzzleUI.SetActive(false);
            }

            Destroy(gameObject);
        }
    }
}


