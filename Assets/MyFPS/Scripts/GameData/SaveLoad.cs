using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MyFPS
{
    public static class SaveLoad
    {
        public static void SaveData()
        {
            string path = Application.persistentDataPath + "/playData";

            // 저장데이터 이진화
            BinaryFormatter bf = new BinaryFormatter();

            // 파일접근 - 존재하면 파일 가져오기, 않으면 파일 새로 생성
            FileStream fs = new FileStream(path, FileMode.Create);

            // 저장할 데이터 세팅
            PlayerData playerData = new PlayerData();

            Debug.Log("Save" + playerData.sceneNum);

            // 데이터를 이진화 저장
            bf.Serialize(fs, playerData);

            // 파일 클로즈
            fs.Close();

        }

        public static PlayerData LoadData()
        {
            PlayerData playerData;

            string path = Application.persistentDataPath + "/playData";

            // 지정된 경로에 저장된 파일이 있는지 없는지 체크
            if (File.Exists(path))
            {
                // 파일 있음

                // 저장데이터 이진화
                BinaryFormatter bf = new BinaryFormatter();

                // 파일접근 - 존재하면 파일 가져오기, 않으면 파일 새로 생성
                FileStream fs = new FileStream(path, FileMode.Open);

                // 파일에 이진화로 저장된 데이터를 역이진화 가져온다
                playerData = bf.Deserialize(fs) as PlayerData;

                Debug.Log("Load" + playerData.sceneNum);

                // 파일 클로즈
                fs.Close();

            }
            else
            {
                // 파일 없음
                Debug.Log("Not Found");
                playerData = null;
            }

            return playerData;
        }
    }
}