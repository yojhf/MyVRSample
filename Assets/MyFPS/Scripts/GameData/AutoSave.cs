using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 플레이씬이 시작하면 자동으로 게임데이터 저장
namespace MyFPS
{
    public class AutoSave : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            AutoSaveData();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void AutoSaveData()
        {
            // 현재 씬 저장
            int playScene = SceneManager.GetActiveScene().buildIndex;
            int curSaveData = PlayerStats.Instance.SceneNum;

            if (playScene > curSaveData)
            {
                PlayerStats.Instance.SceneNum = playScene;

                SaveLoad.SaveData();
            }




        }
    }
}