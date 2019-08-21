using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoguraAttackAni
{
    public class MoguraAttack : MonoBehaviour
    {
        public Animator rootAnimator;
        public Animator MoguraAttackAni;
        bool isReadyMogura;
        bool isReadyBOSS;
        private void Start()
        {
            isReadyMogura = rootAnimator.GetCurrentAnimatorStateInfo(0).IsName("MoguraKanOut");
            isReadyBOSS = rootAnimator.GetCurrentAnimatorStateInfo(0).IsName("BossMoguraOut");
        }

        public void MguAttack(string name)
        {
            int count = Random.Range(0,9);
            if (name == "Mogura")
            {
                if (count > 4 )
                {
                    MoguraAttackAni.SetTrigger("MoguraAttack");
                    Debug.Log("MoguraAttack");
                }
            }
            else if(name == "BOSS" )
            {
                if (count >2) {
                    MoguraAttackAni.SetTrigger("MoguraAttack");
                    Debug.Log("BOSSAttack");
                }
            }
        }

        private void Update()
        {
            if (isReadyMogura) {
                Debug.Log("test");
            }
        }
    }
}
