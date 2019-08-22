using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//エレノアニキのスクリプトをパk･･･参考にさせてもらったよ！　エレノアニキありがと

namespace RocketMoguraPosition
{
    public class RocketMogura : MonoBehaviour
    {
        private Animator rocketAnimator;

        void Awake()
        {
            rocketAnimator = this.GetComponent<Animator>();
        }

        public void RocketMoguraFire()
        {
            rocketAnimator.SetTrigger("RocketMoguraFire");
        }
    }
}