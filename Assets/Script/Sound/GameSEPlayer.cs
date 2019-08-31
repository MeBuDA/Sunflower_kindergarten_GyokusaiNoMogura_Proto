using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SoundSystem{
    //このスクリプトをゲームオブジェクトに適用した際、AudioSourceも適用されるように設定
    [RequireComponent(typeof(AudioSource))]
    public class GameSEPlayer : MonoBehaviour{
        //コンポーネント
        public AudioSource gameSE;

        //SEリスト
        public List<AudioClip> gameSEList = new List<AudioClip>();

        //リストから指定した名前のAudioClipを呼び出し再生
        public void PlaySEOneShot3D(string clipName, float playPitch = 1f){
            AudioClip soundEffect = gameSEList.FirstOrDefault(clip => clip.name == clipName);

            if(soundEffect != null){
                gameSE.pitch = playPitch;
                gameSE.PlayOneShot(soundEffect);
            }

            else{
                Debug.Log(clipName + " Not Found");
            }
        }

        //リストから指定した番号のAudioClipを呼び出し再生
        public void PlaySEOneShot3D(int clipNum, float playPitch = 1f){
            AudioClip soundEffect = gameSEList[clipNum];

            if(soundEffect == null){
                Debug.Log(clipNum.ToString() + " Not Found");
            }
            else{
                gameSE.pitch = playPitch;
                gameSE.PlayOneShot(soundEffect);
            }
        }

        //適用されたAudioSourceの初期化処理
        public void Reset(){
            gameSE = GetComponent<AudioSource>();
            gameSE.playOnAwake = false;
            gameSE.spatialBlend = 1f;
        }
    }
}
