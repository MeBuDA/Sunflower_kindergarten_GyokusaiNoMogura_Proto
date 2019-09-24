using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Stun;

public class StunScore : MonoBehaviour
{
        [SerializeField] float stunTime = 3.0f;
        public MoguraAttackStun stunFlag;

        void Start ()
        {

        }

        public void PlayerStun ()
        {
            stunFlag.PlayerStunFlag = true;
            Invoke ("StunRelease", stunTime);
        }
        void StunRelease ()
        {
            stunFlag.PlayerStunFlag = false;
        }

}
