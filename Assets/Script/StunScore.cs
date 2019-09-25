using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Stun;
using SoundSystem;

public class StunScore : MonoBehaviour
{
        [SerializeField] float stunTime = 3.0f;
        public MoguraAttackStun stunFlag;

        //Sound System
        public GameSEPlayer attackSE;

        void Start ()
        {

        }

        public void PlayerStun ()
        {
            attackSE.PlaySEOneShot3D("MogAttack_pri01");
            if(stunFlag.PlayerStunFlag == false){
                SoundManager.Instance.Play_PlayerSE("Stan_pri02", 0.2f);
            }
            stunFlag.PlayerStunFlag = true;
            Invoke ("StunRelease", stunTime);
        }
        void StunRelease ()
        {
            stunFlag.PlayerStunFlag = false;
        }

}
