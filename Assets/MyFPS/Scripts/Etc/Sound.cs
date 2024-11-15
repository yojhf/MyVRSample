using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace MyFPS
{
    [Serializable]
    public class Sound
    {
        public string name;

        public AudioSource audioSource; // ����� �ҽ� ������Ʈ
        public AudioClip clip; // ����� sound

        [Range(0f, 1f)]
        public float volume; // �Ҹ�ũ��
        [Range(0.1f, 3f)]
        public float pitch; // ��� �ӵ�

        public bool loop = false; // �ݺ����
        public bool playOnAwake = false;
      
    }
}