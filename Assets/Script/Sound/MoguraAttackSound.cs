using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundSystem;

public class MoguraAttackSound : MonoBehaviour{
    //SoundSystem
    public GameSEPlayer attackSEPlayer;

    //コンポーネント
    public Animator attackAnimator;

    //パラメーター
    private float playPitch = 1.2f;

    void Start(){
    }
    void Update(){
    }

    //MoguraAttackアニメーションのEventから呼び出す
    void AttackSEPlay(){
        if(attackAnimator.GetCurrentAnimatorStateInfo(1).IsName("MoguraAttack")){
            attackSEPlayer.PlaySEOneShot3D("HamSwing_pri01", 1f, playPitch);
        }
    }
}