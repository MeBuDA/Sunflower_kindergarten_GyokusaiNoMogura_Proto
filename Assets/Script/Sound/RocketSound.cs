using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundSystem;

public class RocketSound : MonoBehaviour{
    //SoundSystem
    public GameSEPlayer rocketSE;

    //RocketMoguraFire(Animation)のEventから呼び出す
    void PlayFireSound(){
        rocketSE.PlaySEOneShot3D("FireMog_pri01");
    }

    //RocketMoguraKanUp(Animation)のEventから呼び出す
    void RiftCannonSound(){
        rocketSE.PlaySEOneShot3D("RiftCannon_pri01", 1f, 0.1f);
    }
    void SetCannonSound(){
        rocketSE.PlaySEOneShot3D("SetCannon_pri01", 1f, 0.1f);
    }
}
