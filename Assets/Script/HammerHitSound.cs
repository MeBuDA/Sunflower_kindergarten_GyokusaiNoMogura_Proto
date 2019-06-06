//もぐらをハンマーでいぢめると音が鳴るよ

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerHitSound : MonoBehaviour{
    private AudioSource hitSuccess;

    void Start(){
        hitSuccess = GetComponent<AudioSource>();
    }

    void OnTriggerEnter (Collider other){
        if(other.gameObject.CompareTag ("Hammer")){
            hitSuccess.Play();
            //Debug.Log ("Hit");                        //ログを出したい気分になったらコメント外してね
        }
    }
}
