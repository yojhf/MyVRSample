using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

// ������� �����ϴ� Ŭ����
namespace MyFPS
{
    public class SoundManager : PersistentSingleton<SoundManager>
    {
        public List<Sound> sounds = new List<Sound>();

        public Dictionary<string, Sound> soundsDic = new Dictionary<string, Sound>();

        private string bgmSound = "";       //���� �÷��� �Ǵ� ����� �̸�
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

            //�Ű����� �̸��� ���� Ŭ�� ã��
            foreach (var s in sounds)
            {
                if (s.name == name)
                {
                    sound = s;
                    break;
                }
            }

            //�Ű����� �̸��� ���� Ŭ���� ������
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

            //�Ű����� �̸��� ���� Ŭ�� ã��
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

            //�Ű����� �̸��� ���� Ŭ���� ������
            if (sound == null)
            {
                Debug.Log($"Cannot Find {name}");
                return;
            }

            sound.audioSource.Stop();
        }

        //����� ���
        public void PlayBgm(string name)
        {
            //����� �̸� üũ
            if (bgmSound == name)
            {
                return;
            }

            //����� ����
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

            //�Ű����� �̸��� ���� Ŭ���� ������
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