using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// �÷��̾��� �����ϸ� �ڵ����� ���ӵ����� ����
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
            // ���� �� ����
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