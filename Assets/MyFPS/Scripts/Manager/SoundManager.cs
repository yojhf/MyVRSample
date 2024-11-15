using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

// 오디오를 관리하는 클래스
namespace MyFPS
{
    public class SoundManager : PersistentSingleton<SoundManager>
    {
        public List<Sound> sounds = new List<Sound>();

        public Dictionary<string, Sound> soundsDic = new Dictionary<string, Sound>();

        private string bgmSound = "";       //현재 플레이 되는 배경음 이름
        public string BgmSound
        {
            get { return bgmSound; }
        }

        public AudioMixer audioMixer;

        protected override void Awake()
        {
            base.Awake();
            Init();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void Init()
        {
            if(audioMixer != null)
            {
                AudioMixerGroup[] audioMixers = audioMixer.FindMatchingGroups("Master");
      



                foreach (var sound in sounds)
                {
                    soundsDic.Add(sound.name, sound);

                    sound.audioSource = this.gameObject.AddComponent<AudioSource>();

                    sound.audioSource.clip = sound.clip;
                    sound.audioSource.volume = sound.volume;
                    sound.audioSource.pitch = sound.pitch;
                    sound.audioSource.loop = sound.loop;


                    if (sound.loop)
                    {
                        sound.audioSource.outputAudioMixerGroup = audioMixers[1];
                    }
                    else
                    {
                        sound.audioSource.outputAudioMixerGroup = audioMixers[2];
                    }
                }

            }
        }


        public void Play(string name)
        {
            Sound sound = null;

            //매개변수 이름과 같은 클립 찾기
            foreach (var s in sounds)
            {
                if (s.name == name)
                {
                    sound = s;
                    break;
                }
            }

            //매개변수 이름과 같은 클립이 없으면
            if (sound == null)
            {
                Debug.Log($"Cannot Find {name}");
                return;
            }

            sound.audioSource.Play();
        }

        public void Stop(string name)
        {
            Sound sound = null;

            //매개변수 이름과 같은 클립 찾기
            foreach (var s in sounds)
            {
                if (s.name == name)
                {
                    sound = s;

                    //
                    if (s.name == bgmSound)
                    {
                        bgmSound = "";
                    }
                    break;
                }
            }

            //매개변수 이름과 같은 클립이 없으면
            if (sound == null)
            {
                Debug.Log($"Cannot Find {name}");
                return;
            }

            sound.audioSource.Stop();
        }

        //배경음 재생
        public void PlayBgm(string name)
        {
            //배경음 이름 체크
            if (bgmSound == name)
            {
                return;
            }

            //배경음 정지
            Stop(bgmSound);

            Sound sound = null;

            foreach (var s in sounds)
            {
                if (s.name == name)
                {
                    bgmSound = s.name;
                    sound = s;
                    break;
                }
            }

            //매개변수 이름과 같은 클립이 없으면
            if (sound == null)
            {
                Debug.Log($"Cannot Find {name}");
                return;
            }

            sound.audioSource.Play();
        }

        public void StopBgm()
        {
            Stop(bgmSound);
        }
    }
}