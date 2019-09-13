using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundSystem;

public class StartSwitchSound : MonoBehaviour{
    //SoundSystem
    public GameSEPlayer switchSE;

    //ボタン
    public HammerHitJudge button;

    //flag
    private bool pushed = false;

    void Update(){
        //HammerHitJudgeからスイッチにハンマーが当たったサインを受け取る
        if(button == null){
            Debug.Log("button Not Found");
        }
        else if(button.EnterFlag){
            switchSE.PlaySE3D();
            pushed = true;
            //Debug.Log("Play");
        }

        //効果音の再生が終了したら、このオブジェクトを破棄
        if(pushed && !(switchSE.gameSE.isPlaying)){
            //Debug.Log("Destroy");
            Destroy(this.gameObject);
        }
    }
}
