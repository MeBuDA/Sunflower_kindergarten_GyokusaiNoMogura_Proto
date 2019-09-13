using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoguraAttackAni
{
    public class MoguraAttack : MonoBehaviour
    {   
        public Animator MoguraAttackAni;
        
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
    }
}
