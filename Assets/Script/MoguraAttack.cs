using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoguraAttackAni
{
    public class MoguraAttack : MonoBehaviour
    {
        public int moguraAttackKakuritu;
        public int bossAttackKakuritu;
        public Animator MoguraAttackAni;
        
        public void MguAttack(string name)
        {
            int count = Random.Range(0,100);
            if (name == "Mogura")
            {
                if (count < moguraAttackKakuritu)
                {
                    MoguraAttackAni.SetTrigger("MoguraAttack");
                    //Debug.Log("MoguraAttack");
                }
            }
            else if(name == "BOSS" )
            {
                if (count > bossAttackKakuritu)
                {
                    MoguraAttackAni.SetTrigger("MoguraAttack");
                    //Debug.Log("BOSSAttack");
                }
            }
        }
    }
}
