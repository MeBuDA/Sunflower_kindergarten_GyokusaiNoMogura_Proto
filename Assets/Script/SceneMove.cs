using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    public string scenemoveNextScene;//この変数にSceneの名前を打ち込む

    void OnCollisionExit(Collision other)//特定のコリジョンから離れると発動
    {
        if (other.gameObject.CompareTag("Hammer"))//特定のTagの場合
        {
            SceneManager.LoadScene(scenemoveNextScene);//次のシーンに吹っ飛ぶ
        }
    }
}
