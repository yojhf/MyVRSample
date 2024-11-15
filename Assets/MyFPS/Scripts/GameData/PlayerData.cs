using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace MyFPS
{
    [Serializable]
    public class PlayerData
    {
        public int sceneNum;
        public int ammoCount;
        public bool hasGun;

        public PlayerData()
        {
            sceneNum = PlayerStats.Instance.SceneNum;
            ammoCount = PlayerStats.Instance.AmmoCount;
            hasGun = PlayerStats.Instance.HasGun;
        }


    }
}
