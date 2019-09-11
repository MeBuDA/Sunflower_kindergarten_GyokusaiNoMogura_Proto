using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTrigger : MonoBehaviour
{
    [SerializeField] GameObject[] hitHammerEffects; //ハンマーが当たった時のエフェクト

    void OnCollisionExit(Collision other)
	{
		GameObject Switch = GameObject.Find("StartSwitch");//objectの取得
		if (other.gameObject.CompareTag("Hammer"))//ハンマーに当たった時
		{
            for (int i = 0; i < hitHammerEffects.Length; i++)
            {
                Instantiate(hitHammerEffects[i], this.transform.position, this.transform.rotation); //このオブジェクトと同じ場所にエフェクトを生成
            }
            Switch.gameObject.transform.Translate(-1000,-1000,-1000);//StartSwitchを画面外に吹っ飛ばす
			//Debug.Log("消えたよ");
		}
	}
}
