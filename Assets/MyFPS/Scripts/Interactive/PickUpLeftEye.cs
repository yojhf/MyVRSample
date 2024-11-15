using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{
    public class PickUpLeftEye : PickUpPuzzleItem
    {
        [SerializeField] private GameObject exitDoor;
        [SerializeField] private GameObject fakeDoor;

        protected override void Action()
        {
            base.Action();

            if(exitDoor.activeSelf == false)
            {

                if (PlayerStats.Instance.HasPuzzleObject(ItemType.LeftEye) && PlayerStats.Instance.HasPuzzleObject(ItemType.RightEye))
                {
                    exitDoor.SetActive(true);
                    fakeDoor.SetActive(false);
                }
            }

        }
    }
}