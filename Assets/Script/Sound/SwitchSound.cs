using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SoundSystem;

public class SwitchSound : MonoBehaviour{
    //フラグ
    public bool dontDestroyOnLoad;                      //このスイッチによってシーンが切り替わる場合はtrueにする
    //public bool consoleLog;
    private bool sceneFinished;                         //元居たシーンが破棄されるとtrue

    //SoundSystem
    public GameSEPlayer switchSE;

    //ボタン
    public HammerHitJudge button;

    void Start(){
        //シーン切り替えを行うスイッチの場合、MenueSwitchSoundPlayerをMenueSwitchから切り離し、シーン切り替え後も残るようにする
        if(dontDestroyOnLoad){
            if(this.transform.parent != null){
                this.transform.parent = null;
            }
            DontDestroyOnLoad(this);
        }

        SceneManager.sceneUnloaded += SceneUnloaded;
    }

    void Update(){
        //HammerHitJudgeからスイッチにハンマーが当たったサインを受け取る
        if(button == null){
            Debug.Log("button Not Found");
        }
        else if(button.ExitFlag){
            switchSE.PlaySE3D();
            //Debug.Log("Play");
        }

        //ログを表示
        /*if(consoleLog){
            Debug.Log(sceneFinished.ToString());
        }*/

        //元居たシーンが破棄され、効果音の再生が終了したら、このオブジェクトを破棄
        if(sceneFinished && !(switchSE.gameSE.isPlaying)){
            sceneFinished = false;
            //Debug.Log("Destroy");
            Destroy(this.gameObject);
        }
    }

    void SceneUnloaded(Scene recentScene){
        sceneFinished = true;
    }
}
