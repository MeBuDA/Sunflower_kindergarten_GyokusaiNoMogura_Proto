using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundSystem;

public class MoguraRocketSound : MonoBehaviour{
    //Sound System
    public GameSEPlayer rocketSE;

    //AudioClip
    public AudioClip flySEClip;
    
    //プレイヤー
    public PlayerDevMasChange PDMC;

    //コンポーネント
    public Animator rocketAnimator;
    public Transform rocketTransform;
    private AudioSource flySE;

    //コルーチン
    private IEnumerator fadeOut;

    //パラメーター
    private string animClip, recentAnimClip;
    private float rocketDistSqu, firstRocketDistSqu;
    public float pitchLange;
    public float fadeOutTime;

    //フラグ
    private bool flyEnd = false;
    private bool runningCoroutine = false;

    void Start(){
        //飛翔音用AudioSourceの設定
        flySE = this.gameObject.AddComponent<AudioSource>();
        flySE.playOnAwake = false;
        flySE.loop = true;
        flySE.spatialBlend = 1.0f;
        //flySE.dopplerLevel = 5f;
        flySE.clip = flySEClip;

        firstRocketDistSqu = (rocketTransform.position - GetPlayerPosition(PDMC.oculusGo)).sqrMagnitude;
        recentAnimClip = rocketAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name;
    }

    void Update(){
        //パラメーター取得
        animClip = rocketAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name;

        //再生中のアニメーションクリップをもとに飛翔中の音を再生
        if(!animClip.Equals(recentAnimClip)){
            if(animClip.Equals("RocketMoguraFire")){
                //前のコルーチンが残っている場合はそれを終了
                if(runningCoroutine){
                    StopCoroutine(fadeOut);
                    runningCoroutine = false;
                }
                flySE.volume = 1f;
                flySE.Play();
            }

            //もぐらロケットを叩けなかった場合の終了処理
            if(animClip.Equals("RocketMoguraBack") && flySE.isPlaying){
                //flySE.Stop();
                fadeOut = flySE.StopWithFadeOut(fadeOutTime);
                StartCoroutine(fadeOut);
                runningCoroutine = true;
            }
        }

        if(flySE.isPlaying){
            //ロケットとプレイヤーの距離の二乗を取得し、それに基づいてピッチを変更
            rocketDistSqu = (rocketTransform.position - GetPlayerPosition(PDMC.oculusGo)).sqrMagnitude;
            flySE.pitch = (1f - pitchLange) + ((rocketDistSqu / firstRocketDistSqu) * pitchLange);

            //もぐらロケットを叩いた時の終了処理
            if(flyEnd){
                //flySE.Stop();
                fadeOut = flySE.StopWithFadeOut(fadeOutTime);
                StartCoroutine(fadeOut);
                runningCoroutine = true;
                flyEnd = false;
            }
        }

        recentAnimClip = animClip;
    }

    void OnTriggerEnter (Collider other){
        //もぐらロケットがハンマーで殴られたときの音
        if(other.gameObject.CompareTag ("Hammer")){
            rocketSE.PlaySEOneShot3D(0);
            flyEnd = true;
            //Debug.Log ("Hit");
        }
    }

    //PlayerdevMasChangeから現在のプレイデバイスを取得し、それに合ったオブジェクトからプレイヤーの位置情報を取得
    private Vector3 GetPlayerPosition(bool oculusFlag){
        if(oculusFlag){
            return PDMC.oculusGoplayer.transform.position;
        }
        else{
            return PDMC.mousePlayer.transform.position;
        }
    }
}
