using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//シーン移動のため

using RocketMoguraPosition;
using SoundSystem;								//サウンド追加分 1/3

public class TimeManager : MonoBehaviour
{
    [SerializeField] int RocketUpTime = 60; //砲台が起動するまでの時間（秒単位）※6秒以上にすること
    [SerializeField] int TimeLimit = 120; //制限時間（秒単位）
    public GameObject Switch;
	private float startDateTime;

    public RocketMoguraPosition.RocketMogura[] rocketMoguraPosition;
    private GameObject rocketMoguraObject;

	//flag
	private bool played = false;				//サウンド追加分2/3

	//RocketUpTimeが6秒未満だったら修正する
	void Start(){
		if(RocketUpTime < 6){
			Debug.Log("\"RocketUpTime\" must be over 6.");
			RocketUpTime = 6;
		}
	}

	// Update is called once per frame
	void Update()
	{
		Transform StartPos = Switch.transform;//StartSwitchの位置を取得
		Vector3 pos = StartPos.position;
		if (pos.y > -100)
		{//スタートボタン押してからの時間をはかるため
			startDateTime = Time.time;
		}
		else if (pos.y < -100)//スイッチの位置によってゲーム開始
		{

			// 制限時間		
			var time = Time.time - startDateTime;
			float seconds = (int)time;

			//ロケット警告の再生 サウンド追加分3/3
			if ((seconds == RocketUpTime - 6.0f) && (!played))
            {
	            SoundManager.Instance.PlayOneShot_System("Alert_pri01");
		        played = true;
			}
			//サウンド追加分3/3 終了
			
            if (seconds == RocketUpTime - 3.0f)
            {

                for (int i = 0; i < rocketMoguraPosition.Length; i++)
                {
                    rocketMoguraPosition[i].RocketUp();
                }
            }

            if (seconds == RocketUpTime)
            {
                for (int i = 0; i < rocketMoguraPosition.Length; i++)
                {
                    rocketMoguraPosition[i].RocketUpFinish();
                }
            }

            if (seconds > TimeLimit)//制限時間が来たら
			{
				SceneManager.LoadScene("TotalScore");//結果発表～
			}
			//Debug.Log(time);

		}
	}
}
