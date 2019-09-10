using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using RocketMoguraPosition;

public class RocketMoguraHuttobi : MonoBehaviour
{
    private GameObject rocketMoguraObject;

    void Start()
    {
        rocketMoguraObject = transform.root.gameObject;  //RocketMoguraObjectを取得
    }

    void OnTriggerEnter(Collider other) //特定のコリジョンに触れた瞬間発動
    {
        if (other.gameObject.CompareTag("Hammer")) //特定のTagの場合
        {
            rocketMoguraObject.GetComponent<RocketMogura>().RocketMoguraHuttobi();
        }
    }
}
