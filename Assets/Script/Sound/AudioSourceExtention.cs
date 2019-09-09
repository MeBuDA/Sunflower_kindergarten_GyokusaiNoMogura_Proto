using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoundSystem{
    public static class AudioSourceExtention{
        //フェードアウトしながら再生を終了させる
        public static IEnumerator StopWithFadeOut(this AudioSource audioSource, float fadeTime){
            float startVolume = audioSource.volume;

            for(float t = 0f; t < fadeTime; t += Time.deltaTime){
                audioSource.volume = Mathf.Lerp(startVolume, 0f, Mathf.Clamp01(t / fadeTime));
                yield return null;
            }
            audioSource.volume = 0f;
            audioSource.Stop();
            yield break;
        }
    }
}
