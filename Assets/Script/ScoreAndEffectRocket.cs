using System.Collections;
using System.Collections.Generic;
using SceroManager;
using Stun;
using UnityEngine;

public class ScoreAndEffectRocket : MonoBehaviour
{
    public int thisObjectScore; //モグラごとのスコアを打ち込む

    private GameObject rocketMoguraObject; //RocketMoguraObjectを取得

    private Animator animator; //アニメーターを取得

    private bool attackRocketFlag; //スコアが一回だけ加算される用のフラグ
    public MoguraAttackStun stunFlag;
    public GameObject[] hitHammerEffects; //ハンマーが当たった時のエフェクト

    void Start ()
    {
        rocketMoguraObject = transform.root.gameObject; //Rocketを取得

        animator = rocketMoguraObject.GetComponent<Animator> (); //Animatorを取得

        attackRocketFlag = true; //攻撃可能状態
    }

    void Update ()
    {
        if (animator.GetCurrentAnimatorStateInfo (0).IsName ("RocketMoguraKanState")) //ロケットモグラが待機状態のAnimationの場合
        {
            attackRocketFlag = true; //攻撃可能状態
        }
    }

    void OnTriggerEnter (Collider other) //特定のコリジョンに触れた瞬間発動
    {
        if (stunFlag.PlayerStunFlag == false)
        {
            if (other.gameObject.CompareTag ("Hammer")) //特定のTagの場合
            {
                if (animator.GetCurrentAnimatorStateInfo (0).IsName ("RocketMoguraFire")) //ロケットモグラが発射状態のAnimetionの場合
                {
                    if (attackRocketFlag == true) //攻撃可能状態の場合
                    {
                        //FindObjectOfType<ScoreManager>().
                        for (int i = 0; i < hitHammerEffects.Length; i++)
                        {
                            Instantiate (hitHammerEffects[i], this.transform.position, this.transform.rotation); //このオブジェクトと同じ場所にエフェクトを生成
                        }
                        ScoreManager.AddScore (thisObjectScore); //ScoreManagerスクリプトのthisObjectScoreメソッド起動
                        attackRocketFlag = false; //攻撃不可状態
                    }
                }
            }
        }
    }
}