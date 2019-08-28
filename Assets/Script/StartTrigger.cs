using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTrigger : MonoBehaviour
{
	
	void OnCollisionExit(Collision other)
	{
		GameObject Switch = GameObject.Find("StartSwitch");//objectの取得
		if (other.gameObject.CompareTag("Hammer"))//ハンマーに当たった時
		{
			Switch.gameObject.transform.Translate(-1000,-1000,-1000);//StartSwitchを画面外に吹っ飛ばす
			//Debug.Log("消えたよ");
		}
	}
}
