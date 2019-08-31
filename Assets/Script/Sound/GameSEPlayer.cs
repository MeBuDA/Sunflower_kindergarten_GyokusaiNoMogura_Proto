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

        //リストにAudioClipが一つしか登録されていないときに使う
        //AudioClipが複数割り当てられている場合、最初の音を再生することも一応できる
        public void Play3D(float playPitch = 1){
            if(gameSEList.Count() != 1){
                Debug.Log("Elements of gameSEList is not one");
            }
            
            if(gameSEList[0] == null){
                Debug.Log("AudioClip Not Found");
            }
            else{
                gameSE.pitch = playPitch;
                gameSE.spatialBlend = 1f;
                gameSE.clip = gameSEList[0];

                gameSE.Play();
            }
        }

        //リストから指定した名前のAudioClipを呼び出し再生
        public void PlaySEOneShot3D(string clipName, float playPitch = 1f){
            if(gameSEList.FirstOrDefault(clip => clip.name == clipName) == null){
                Debug.Log(clipName + " Not Found");
            }

            else{
                gameSE.pitch = playPitch;
                gameSE.spatialBlend = 1f;

                gameSE.PlayOneShot(gameSEList.FirstOrDefault(clip => clip.name == clipName));
            }
        }

        //リストから指定した番号のAudioClipを呼び出し再生
        public void PlaySEOneShot3D(int clipNum, float playPitch = 1f){
            if(gameSEList[clipNum] == null){
                Debug.Log(clipNum.ToString() + " Not Found");
            }
            else{
                gameSE.pitch = playPitch;
                gameSE.spatialBlend = 1f;

                gameSE.PlayOneShot(gameSEList[clipNum]);
            }
        }

        //適用されたAudioSourceの初期化処理
        public void Reset(){
            gameSE = GetComponent<AudioSource>();
            gameSE.playOnAwake = false;
        }
    }
}
