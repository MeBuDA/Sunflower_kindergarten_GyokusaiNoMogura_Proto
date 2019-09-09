using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundSystem;

public class MoguraHitSound : MonoBehaviour{
    //もぐら
    public HammerHitJudge[] mogura;

    //SoundSystem
    public GameSEPlayer mogHitSE;

    void Start(){
        for(int i = 0; i < mogura.Length; i++){
            mogura[i] = mogura[i].GetComponent<HammerHitJudge>();
        }
    }

    void Update(){
        //HammerHitJudgeからもぐらにハンマーが当たったサインを受け取る
        for(int i = 0; i < mogura.Length; i++){
            if(mogura[i] == null){
                Debug.Log("mogura No." + i.ToString() + " Not Found");
            }
            else if(mogura[i].EnterFlag){
                //Debug.Log(i.ToString());
                mogHitSE.PlaySEOneShot3D(i);
            }
        }
    }
}
