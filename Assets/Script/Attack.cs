using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Animator rootAnimator;

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag ("Hammer"))
        {
            rootAnimator.SetTrigger ("Attack");
            //Debug.Log ("Attack");
        }
    }
}
