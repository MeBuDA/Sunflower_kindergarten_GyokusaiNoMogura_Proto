using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoguraHitJudge : MonoBehaviour{
    //フラグ
    private bool hitFlag = false;

    //プロパティ
    public bool HitFlag{
        get{
            bool returnVaule = hitFlag;
            hitFlag = false;
            return returnVaule;
        }
    }

    void Start(){
    }

    void Update(){
    }

    //MouguraHitSoundにハンマーの衝突を伝える
    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag ("Hammer")){
            hitFlag = true;
            //Debug.Log("Hit:" + this.name);
        }
    }
}
