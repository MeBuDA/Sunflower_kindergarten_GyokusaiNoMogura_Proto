using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Stun
{
    public class MoguraAttackStun : MonoBehaviour
    {
        bool playerStun = false;
        public bool PlayerStunFlag { set { playerStun = value; } get { return playerStun; } } //スタンのフラッグ
    }
}