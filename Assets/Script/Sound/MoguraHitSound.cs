using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundSystem;

public class MoguraHitSound : MonoBehaviour{
    //もぐら
    public HammerHitJudge[] mogura;

    //animator
    public Animator mogAnimator;

    //SoundSystem
    public GameSEPlayer mogHitSE;

    //flag
    private bool attackFlag;

    void Update(){
        if (mogAnimator.GetCurrentAnimatorStateInfo(0).IsName("MoguraKanState")){
            attackFlag = true;                                                      //攻撃可能状態
        }

        //HammerHitJudgeからもぐらにハンマーが当たったサインを受け取る
        for(int i = 0; i < mogura.Length; i++){
            if(mogura[i] == null){
                Debug.Log("mogura No." + i.ToString() + " Not Found");
            }
            else if(mogura[i].EnterFlag && attackFlag && !(mogAnimator.GetCurrentAnimatorStateInfo(0).IsName("MoguraKanState"))){
                //Debug.Log(i.ToString());
                mogHitSE.PlaySEOneShot3D(i);
                attackFlag = false;
            }
        }
    }
}
