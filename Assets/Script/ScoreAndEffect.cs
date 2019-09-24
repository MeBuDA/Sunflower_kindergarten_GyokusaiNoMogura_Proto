using System.Collections;
using System.Collections.Generic;
using SceroManager;
using UnityEngine;
using Stun;
    public class ScoreAndEffect : MonoBehaviour
    {
        public int thisObjectScore; //モグラごとのスコアを打ち込む

        private GameObject moguraObject;

        private Animator animator;

        private bool attackFlag;
        
        public MoguraAttackStun stunFlag;
        [SerializeField] GameObject[] hitHammerEffects; //ハンマーが当たった時のエフェクト

        void Start ()
        {
            moguraObject = transform.root.gameObject; //MoguraObjectを取得

            animator = moguraObject.GetComponent<Animator> (); //Animatorを取得

            attackFlag = true; //攻撃可能状態
        }

        void Update ()
        {
            if (animator.GetCurrentAnimatorStateInfo (0).IsName ("New State")) //モグラ(全種)が待機状態のAnimationの場合
            {
                attackFlag = true; //攻撃可能状態
            }
        }
        void OnTriggerEnter (Collider other) //特定のコリジョンに触れた瞬間発動
        {
            if (stunFlag.PlayerStunFlag == false)
            {
                if (other.gameObject.CompareTag ("Hammer")) //特定のTagの場合
                {
                    if (!(animator.GetCurrentAnimatorStateInfo (0).IsName ("New State"))) //モグラ(全種)が待機状態でないAnimetionの場合
                    {
                        if (attackFlag == true) //攻撃可能状態の場合
                        {
                            //FindObjectOfType<ScoreManager>().
                            for (int i = 0; i < hitHammerEffects.Length; i++)
                            {
                                Instantiate (hitHammerEffects[i], this.transform.position, this.transform.rotation); //このオブジェクトと同じ場所にエフェクトを生成
                            }
                            ScoreManager.AddScore (thisObjectScore); //ScoreManagerスクリプトのthisObjectScoreメソッド起動
                            attackFlag = false; //攻撃不可状態
                        }
                    }
                }
            }
        }
    }


/*
//遺品置き場(始)
    private string thisObjectName;

        thisObjectName = this.gameObject.name; //付けているオブジェクトの名前を参照

        //モグラの種類によって叩いたときのスコアを設定(始)
        if (thisObjectName == "Mogura")
        {
            thisObjectScore = 100;
        }
        else if (thisObjectName == "BossMogura ")
        {
            thisObjectScore = 500;
        }
        else if (thisObjectName == "GoldMogura ")
        {
            thisObjectScore = 1000;
        }
        else if (thisObjectName == "Ojisan")
        {
            thisObjectScore = -400;
        }
        //モグラの種類によって叩いたときのスコアを設定(終)



    public string nameOfMoguraObject;//この変数にmoguraObjectの名前を打ち込む(めんどいのはわかるけどこれだけはお願い♥)

    moguraObject = GameObject.Find(nameOfMoguraObject); //MoguraObjectを取得

            if (animator.GetCurrentAnimatorStateInfo(0).IsName("MoguraKanOut")  ||  //条件文(始)
                animator.GetCurrentAnimatorStateInfo(0).IsName("MoguraKanIn")   ||
                animator.GetCurrentAnimatorStateInfo(0).IsName("BossMoguraOut") ||
                animator.GetCurrentAnimatorStateInfo(0).IsName("BossMoguraIn")  ||  //モグラ(全種)が待機状態でないAnimetionの場合
                animator.GetCurrentAnimatorStateInfo(0).IsName("GoldMoguraOut") ||
                animator.GetCurrentAnimatorStateInfo(0).IsName("GoldMoguraIn")  ||
                animator.GetCurrentAnimatorStateInfo(0).IsName("OjisanOut")     ||
                animator.GetCurrentAnimatorStateInfo(0).IsName("OjisanIn")        ) //条件文(終)
//遺品置き場(終)
*/