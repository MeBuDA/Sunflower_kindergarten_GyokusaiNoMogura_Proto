using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SoundSystem{
    public class SoundManager : MonoBehaviour{
        //AudioClip
        public List<AudioClip> systemSE = new List<AudioClip>();

        //AudioSource
        private AudioSource systemAudioSource;

        //プロパティ
        public static SoundManager Instance{
            get;
            private set;
        }

        private void Awake(){
            //シングルトン処理
            if(Instance == null){
                Instance = this;
                //最終的にはDDOLを有効にし、Titleシーン以外のSoundManagerを消去する
                //DontDestroyOnLoad(this);
            }
            else{
                Destroy(this);
                return;
            }

            systemAudioSource = InitializeAudioSource(this.gameObject);
        }

        //指定した名前の音を再生
        public void PlayOneShot_System(string clipName){
            AudioClip audioClip = systemSE.FirstOrDefault(clip => clip.name == clipName);

            if(audioClip == null){
                Debug.Log(clipName + " not found");
                return;
            }

            systemAudioSource.PlayOneShot(audioClip);
        }

        //AduioSource生成
        private AudioSource InitializeAudioSource(GameObject parentGameObject){
            AudioSource audioSource = parentGameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
            audioSource.spatialBlend = 0f;
            return audioSource;
        }
    }
}
