using System.Collections;
using System.Collections.Generic;
using SoundSystem;
using Stun;
using UnityEngine;

public class StunScore : MonoBehaviour
{
    [SerializeField] float stunTime = 3.0f;
    public MoguraAttackStun stunFlag;
    public Animator MoguraAttackAni;

    void OnTriggerEnter (Collider other)
    {
        if (other.name.Equals ("PlayerCollider"))
        {
            PlayerStun ();
        }
    }

    public void PlayerStun ()
    {
        SoundManager.Instance.PlayOneShot_PlayerSE ("MogAttack_pri01");
        if (stunFlag.PlayerStunFlag == false)
        {
            SoundManager.Instance.Play_PlayerSE ("Stan_pri02", 0.2f);
        }
        stunFlag.PlayerStunFlag = true;
        if (!(MoguraAttackAni == null))
        {
            MoguraAttackAni.SetTrigger ("HitMogAttack");
        }
        Invoke ("StunRelease", stunTime);
    }

    void StunRelease ()
    {
        stunFlag.PlayerStunFlag = false;
    }

}