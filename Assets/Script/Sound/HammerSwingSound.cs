using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundSystem;

public class HammerSwingSound : MonoBehaviour{
    //コンポーネント
    public Transform hammer;

    //private GameObject hammer;
    //private static CriAtomSource swing;

    //SoundSystem
    public GameSEPlayer hamSound;

    //パラメーター
    private Vector3 recentPos;
    private Vector3 deltaPosition;
    private float speed;
    public float speedThreshold = 13.0f;
    private float playPitch = 0.8f;
    //public int swingCounter = 0;

    void Start(){
        //hammer = GameObject.Find("Head");
        //swing = GetComponent<CriAtomSource>();
    }

    void Update(){
        //直前のフレームと現在のフレームの位置情報から速度を計算
        deltaPosition = (hammer.transform.position - recentPos) / Time.deltaTime;
        speed = deltaPosition.magnitude;

        //速度が閾値異常なら音が鳴る
        if(speed >= speedThreshold){
            //swing.Play();
            //swingCounter++;
            hamSound.PlaySE3D_PrioritizePrevious(1f, playPitch);
        }

        recentPos = hammer.transform.position;
    }
}
