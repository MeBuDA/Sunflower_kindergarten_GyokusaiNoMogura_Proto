using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundSystem;

public class RocketFireSound : MonoBehaviour{
    //SoundSystem
    public GameSEPlayer fireSE;

    //RocketMoguraFire(Animation)のEventから呼び出す
    void PlayFireSound(){
        fireSE.PlaySEOneShot3D();
    }
}
