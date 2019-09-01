using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundSystem;

public class MoguraRocketHitSound : MonoBehaviour{
    public GameSEPlayer hitSE;

    void Start(){
    }

    void OnTriggerEnter (Collider other){
        if(other.gameObject.CompareTag ("Hammer")){
            hitSE.PlaySEOneShot3D();
            //Debug.Log ("Hit");                        //ログを出したい気分になったらコメント外してね
        }
    }
}
