using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectSound : MonoBehaviour{
    //コンポーネント
    private AudioSource lvSelect;

    void Start(){
        lvSelect = GetComponent<AudioSource>();
    }

    void Update(){
    }

    void OnCollisionExit(Collision other){
        if(other.gameObject.tag == "Hammer"){
            lvSelect.Play();
        }
    }
}
