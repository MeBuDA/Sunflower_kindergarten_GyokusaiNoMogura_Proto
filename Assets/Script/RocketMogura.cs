using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//エレノアニキのスクリプトをパk･･･参考にさせてもらったよ！　エレノアニキありがと

namespace RocketMoguraPosition
{
    public class RocketMogura : MonoBehaviour
    {
        private Animator rocketAnimator;

        //[SerializeField] float rocketUpTime; //モグラロケットが起動するまでの時間(秒)
        private bool rocketUpFlag;

        void Awake()
        {
            rocketAnimator = this.GetComponent<Animator>();
        }

        void Start()
        {
            rocketUpFlag = false;
            //Invoke("RocketUp", rocketUpTime - 3.0f);
        }

        public void RocketUp()
        {
            rocketAnimator.SetTrigger("RocketMoguraKanUp");
            //Invoke("RocketUpFinish", 3.0f);
        }

        public void RocketUpFinish()
        {
            rocketUpFlag = true;
        }

        public void RocketMoguraFire()
        {
            if (rocketAnimator.GetCurrentAnimatorStateInfo(0).IsName("RocketMoguraKanState")) //このif文があるとロケットモグラが戻った直後に発射されなくなる
            {
                if (rocketUpFlag == true)
                {
                    rocketAnimator.SetTrigger("RocketMoguraFire");
                }
            }
        }

        public void RocketMoguraHuttobi()
        {
            rocketAnimator.SetBool("RocketMoguraHitHammer", true);
        }

        public void Update()
        {
            if (rocketAnimator.GetCurrentAnimatorStateInfo(0).IsName("RocketMoguraKanState"))
            {
                rocketAnimator.SetBool("RocketMoguraHitHammer", false);
            }
        }
    }
}