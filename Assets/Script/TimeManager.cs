using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//シーン移動のため

using RocketMoguraPosition;

public class TimeManager : MonoBehaviour
{
    [SerializeField] int RocketUpTime = 60; //砲台が起動するまでの時間（秒単位）※3秒以上にすること
    [SerializeField] int TimeLimit = 120; //制限時間（秒単位）
    public GameObject Switch;
	float startDateTime;

    public RocketMoguraPosition.RocketMogura[] rocketMoguraPosition;
    private GameObject rocketMoguraObject;

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
