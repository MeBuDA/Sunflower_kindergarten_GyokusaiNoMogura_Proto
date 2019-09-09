using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//シーン移動のため

public class TimeManager : MonoBehaviour
{
	[SerializeField] int TimeLimit = 120; //制限時間（秒単位）
	public GameObject Switch;
	float startDateTime;

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
			if (seconds > TimeLimit)//制限時間が来たら
			{
				SceneManager.LoadScene("TotalScore");//結果発表～
			}
			Debug.Log(time);

		}
	}
}
