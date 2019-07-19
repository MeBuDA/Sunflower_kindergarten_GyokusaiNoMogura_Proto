//タイトルでスタートボタンを押した時に音が鳴る

using System.Collections;
using System.Collections.Generic;
using TitleSound;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSoundStart : MonoBehaviour
{
    void Start()
    {

    }
    void OnCollisionExit (Collision other)
    { //Exitにすると音が途切れるので一時的にEnterに なおしたbyめぶ
        if (other.gameObject.CompareTag ("Hammer"))
        {
            TitleSoundBOX.OnTitleSound ();
        }
    }
}