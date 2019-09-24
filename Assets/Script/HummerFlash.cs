using System.Collections;
using System.Collections.Generic;
using Stun;
using UnityEngine;
public class HummerFlash : MonoBehaviour
{
    public GameObject hummer;
    public MoguraAttackStun stun;
    // Start is called before the first frame update
    void Start ()
    {

    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        float level = Mathf.Sin (Time.time*10);
        if (stun.PlayerStunFlag)
        {
            IsHummerFlash (level);
        }else
        {
            hummer.SetActive(true);
        }
    }
    void IsHummerFlash (float level)
    {
        if (level < 0)
        {
            hummer.SetActive (false);
        }
        else
        {
            hummer.SetActive (true);
        }
    }
}