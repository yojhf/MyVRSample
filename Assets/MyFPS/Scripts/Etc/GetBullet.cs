using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{
    public class GetBullet : PickUpObject
    {
        [SerializeField] private int giveAmount = 7;

        protected override bool OnPickUp()
        {
            PlayerStats.Instance.GetAmmo(giveAmount);
            return true;
        }
    }
}