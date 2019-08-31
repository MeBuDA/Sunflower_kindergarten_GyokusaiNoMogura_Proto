using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundSystem;

public class MoguraHitSound : MonoBehaviour{
    //もぐら
    public MoguraHitJudge[] mogura;

    //SoundSystem
    public GameSEPlayer mogHitSE;

    void Start(){
        for(int i = 0; i < mogura.Length; i++){
            mogura[i] = mogura[i].GetComponent<MoguraHitJudge>();
        }
    }

    void Update(){
        for(int i = 0; i < mogura.Length; i++){
            if(mogura[i] == null){
                Debug.Log("mogura No." + i.ToString() + " Not Found");
            }
            else if(mogura[i].HitFlag){
                //Debug.Log(i.ToString());
                mogHitSE.PlaySEOneShot3D(i);
            }
        }
    }
}
