using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SceroManager;

public class ScoreRocket : MonoBehaviour
{
    public int thisObjectScore; //モグラごとのスコアを打ち込む

    private GameObject rocketMoguraObject;

    private Animator animator;

    private bool attackRocketFlag;

    void Start()
    {
        rocketMoguraObject = transform.root.gameObject;  //Rocketを取得

        animator = rocketMoguraObject.GetComponent<Animator>(); //Animatorを取得

        attackRocketFlag = true; //攻撃可能状態
    }

    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("RocketMoguraKanState")) //ロケットモグラが待機状態のAnimationの場合
        {
            attackRocketFlag = true; //攻撃可能状態
        }
    }

    void OnTriggerEnter(Collider other) //特定のコリジョンに触れた瞬間発動
    {
        if (other.gameObject.CompareTag("Hammer")) //特定のTagの場合
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("RocketMoguraFire")) //ロケットモグラが発射状態のAnimetionの場合
            {
                if (attackRocketFlag == true) //攻撃可能状態の場合
                {
                    //FindObjectOfType<ScoreManager>().
                    ScoreManager.AddScore(thisObjectScore); //ScoreManagerスクリプトのthisObjectScoreメソッド起動
                    attackRocketFlag = false; //攻撃不可状態
                }
            }
        }
    }
}
