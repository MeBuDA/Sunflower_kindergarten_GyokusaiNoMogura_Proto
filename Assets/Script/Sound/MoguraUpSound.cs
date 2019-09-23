using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundSystem;

public class MoguraUpSound : MonoBehaviour{
    //SoundSystem
    public GameSEPlayer moguraObject;

    //Eventから呼び出し
    void MoguraUpSoundPlay(){
        moguraObject.PlaySEOneShot3D("MogUp_pri01", 0.5f);
    }
}
