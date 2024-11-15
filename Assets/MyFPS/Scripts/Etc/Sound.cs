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

        public AudioSource audioSource; // 오디오 소스 컴포넌트
        public AudioClip clip; // 재생할 sound

        [Range(0f, 1f)]
        public float volume; // 소리크기
        [Range(0.1f, 3f)]
        public float pitch; // 재생 속도

        public bool loop = false; // 반복재생
        public bool playOnAwake = false;
      
    }
}