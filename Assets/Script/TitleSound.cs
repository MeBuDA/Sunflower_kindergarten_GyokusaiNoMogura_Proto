//タイトルでスタートボタンを押した時に音が鳴る

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSound : MonoBehaviour{
    private AudioSource titleSound;

    void Start(){
        titleSound = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other){              //Exitにすると音が途切れるので一時的にEnterに
        if (other.gameObject.CompareTag("Hammer")){
            titleSound.Play();
        }
    }
}
