using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    public string scenemoveNextScene;//この変数にSceneの名前を打ち込む

    public GameObject[] hitHammerEffects; //ハンマーが当たった時のエフェクト

    void OnCollisionExit(Collision other)//特定のコリジョンから離れると発動
    {
#if !UNITY_EDITOR
        if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
#endif
        if (other.gameObject.CompareTag("Hammer"))//特定のTagの場合
        {
            for (int i = 0; i < hitHammerEffects.Length; i++)
            {
                Instantiate(hitHammerEffects[i], this.transform.position, this.transform.rotation); //このオブジェクトと同じ場所にエフェクトを生成
            }
            Invoke("SceneTeleport", 1.0f);
        }
        }
#if !UNITY_EDITOR
    }
#endif

    void SceneTeleport()
    {
        SceneManager.LoadScene(scenemoveNextScene);//次のシーンに吹っ飛ぶ
    }
}
