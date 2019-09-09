using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerHitJudge : MonoBehaviour{
    //フラグ
    private bool enterFlag = false;
    private bool stayFlag = false;
    private bool exitFlag = false;

    //プロパティ
    public bool EnterFlag{
        get{
            bool returnVaule = enterFlag;
            enterFlag = false;
            return returnVaule;
        }
    }
    public bool StayFlag{
        get{
            bool returnVaule = stayFlag;
            stayFlag = false;
            return returnVaule;
        }
    }
    public bool ExitFlag{
        get{
            bool returnVaule = exitFlag;
            exitFlag = false;
            return returnVaule;
        }
    }

    void Start(){
    }

    void Update(){
    }

    //再生用スクリプトにハンマーの衝突を伝える
    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag ("Hammer")){
            enterFlag = true;
            //Debug.Log("Hit:" + this.name);
        }
    }

    void OnCollisionEnter(Collision other){
        if(other.gameObject.CompareTag ("Hammer")){
            enterFlag = true;
            //Debug.Log("Hit:" + this.name);
        }
    }

    void OnCollisionExit(Collision other){
        if(other.gameObject.CompareTag ("Hammer")){
            exitFlag = true;
            //Debug.Log("Hit:" + this.name);
        }
    }
}
