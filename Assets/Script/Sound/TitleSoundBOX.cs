using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TitleSound
{
    public class TitleSoundBOX : MonoBehaviour
    {
        private static AudioSource audioSouse;
        public bool dontDestroyEnabled = true;
        void Start ()
        {
            if (dontDestroyEnabled)
            {
                // Sceneを遷移してもオブジェクトが消えないようにする
                DontDestroyOnLoad (this);
            }
            audioSouse = GetComponent<AudioSource> ();
        }

        public static void OnTitleSound ()///タイトルの音再生
        {
            audioSouse.Play ();
        }

    }
}