using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyFPS
{
    // 퍼즐 아이템 획득여부
    public enum ItemType
    {
        Room01_Key,
        Room02_Key,
        Room03_Key,
        LeftEye,
        RightEye,
        Max_Key         // 퍼즐 아이템 갯수
    }


    // 플레이어의 속성 값을 관리하는 (싱글톤, ) 클래스
    public class PlayerStats : PersistentSingleton<PlayerStats>    
    {
        // 게임 퍼즐 아이템 키
        private List<bool> puzzleKeys = new List<bool>();

        public TMP_Text ammoCount_Text;

        private int sceneNum;

        public int SceneNum
        {
            get { return sceneNum; }
            set { sceneNum = value; }
        }

        private int nowSceneNum;
        public int NowSceneNum
        {
            get { return nowSceneNum; }
            set { nowSceneNum = value; }
        }


        private int ammoCount;

        public int AmmoCount
        {
            get { return ammoCount; }
            set { ammoCount = value; }
        }

        // 무기 소지 여부
        private bool hasGun;

        public bool HasGun
        {
            get { return hasGun; }
            set { hasGun = value; }
        }

        // Start is called before the first frame update
        void Start()
        {

            for (int i = 0; i < (int)ItemType.Max_Key; i++)
            {
                puzzleKeys.Add(false);
            }
        }

        // Update is called once per frame
        void Update()
        {
              
        }

        public void GetAmmo(int count)
        {
            AmmoCount += count;
            //ammoCount_Text.text = AmmoCount.ToString();

        }

        public bool UseAmmo(int count)
        {

            if(AmmoCount < count)
            {
                return false;
            }

            
            AmmoCount -= count;
            //ammoCount_Text.text = AmmoCount.ToString();

            return true;
        }

        public int UseAmmo()
        {
            AmmoCount--;
            //ammoCount_Text.text = AmmoCount.ToString();
            return AmmoCount;
        }

        // 퍼즐 아이템 획득
        public void GetPuzzleObject(ItemType key)
        {
            puzzleKeys[(int)key] = true;
        }

        // 퍼즐 아이템 소지 여부
        public bool HasPuzzleObject(ItemType key)
        {
            return puzzleKeys[(int)key];
        }

        public void SetHasGun(bool value)
        {
            HasGun = value;
        }

        public void PlayerStatInit(PlayerData playerData)
        {
            if(playerData != null)
            {
                SceneNum = playerData.sceneNum;
                AmmoCount = playerData.ammoCount;
                HasGun = playerData.hasGun;
            }
            else // 저장된 데이터가 없을 때
            {
                SceneNum = 0;
                AmmoCount = 0;
                HasGun = false;
            }
        }



    }



}
