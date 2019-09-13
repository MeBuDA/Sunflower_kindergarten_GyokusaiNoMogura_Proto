using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundSystem;

public class SwitchSound_Stay : MonoBehaviour{
    //SoundSystem
    public GameSEPlayer switchSE;

    //flag
    private bool pushFlag = false;

    void Update(){
        if(pushFlag){
            //switchSE.PlaySEOneShot3D();
            pushFlag = false;
        }
    }

    void OnCollisionEnter(Collision other){
        if(other.gameObject.CompareTag ("Hammer")){
            //pushFlag = true;
            switchSE.PlaySEOneShot3D();
            //Debug.Log("Hit");
        }
    }
}
