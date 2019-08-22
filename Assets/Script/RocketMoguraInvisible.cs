using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RocketMoguraInvisible : MonoBehaviour
{
    public bool flag;

    void Start()
    {
        flag = true;
    }

    void OnTriggerEnter(Collider other) //特定のコリジョンに触れた瞬間発動
    {
        if (other.gameObject.CompareTag("Hammer") || other.gameObject.CompareTag("Player")) //特定のTagの場合
        {
            if (flag == true)
            {
                flag = false;
            }
        }

        if (other.gameObject.CompareTag("RocketMoguraBackPoint")) //特定のTagの場合
        {
            if (flag == false)
            {
                flag = true;
            }
        }
    }
}