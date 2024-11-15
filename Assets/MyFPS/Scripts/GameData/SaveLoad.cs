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

            // ���嵥���� ����ȭ
            BinaryFormatter bf = new BinaryFormatter();

            // �������� - �����ϸ� ���� ��������, ������ ���� ���� ����
            FileStream fs = new FileStream(path, FileMode.Create);

            // ������ ������ ����
            PlayerData playerData = new PlayerData();

            Debug.Log("Save" + playerData.sceneNum);

            // �����͸� ����ȭ ����
            bf.Serialize(fs, playerData);

            // ���� Ŭ����
            fs.Close();

        }

        public static PlayerData LoadData()
        {
            PlayerData playerData;

            string path = Application.persistentDataPath + "/playData";

            // ������ ��ο� ����� ������ �ִ��� ������ üũ
            if (File.Exists(path))
            {
                // ���� ����

                // ���嵥���� ����ȭ
                BinaryFormatter bf = new BinaryFormatter();

                // �������� - �����ϸ� ���� ��������, ������ ���� ���� ����
                FileStream fs = new FileStream(path, FileMode.Open);

                // ���Ͽ� ����ȭ�� ����� �����͸� ������ȭ �����´�
                playerData = bf.Deserialize(fs) as PlayerData;

                Debug.Log("Load" + playerData.sceneNum);

                // ���� Ŭ����
                fs.Close();

            }
            else
            {
                // ���� ����
                Debug.Log("Not Found");
                playerData = null;
            }

            return playerData;
        }
    }
}