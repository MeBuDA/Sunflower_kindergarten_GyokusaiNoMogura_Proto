using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Stun;

public class HammerHitJudge : MonoBehaviour{
    //フラグ
    private bool enterFlag = false;
    private bool stayFlag = false;
    private bool exitFlag = false;

    //ステータス
    public MoguraAttackStun stun;

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
            if(stun == null){
                enterFlag = true;
                //Debug.Log("Hit1:" + this.name);
            }
            else if(!stun.PlayerStunFlag){
                enterFlag = true;
                //Debug.Log("Hit2:" + this.name);
            }
        }
    }

    void OnCollisionEnter(Collision other){
        if(other.gameObject.CompareTag ("Hammer")){
            if(stun == null){
                enterFlag = true;
            }
            else if(!stun.PlayerStunFlag){
                enterFlag = true;
            }
            //Debug.Log("Hit:" + this.name);
        }
    }

    void OnCollisionExit(Collision other){
        if(other.gameObject.CompareTag ("Hammer")){
            if(stun == null){
                exitFlag = true;
                //Debug.Log("Hit1:" + this.name);
            }
            else if(!stun.PlayerStunFlag){
                exitFlag = true;
                //Debug.Log("Hit2:" + this.name);
            }
            //Debug.Log("Hit:" + this.name);
        }
    }
}
