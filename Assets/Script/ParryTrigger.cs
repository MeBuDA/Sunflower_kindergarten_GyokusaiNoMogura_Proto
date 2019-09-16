using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParryTrigger : MonoBehaviour
{

	public Animator MoguraAttackAni;

	void OnTriggerEnter(Collider other)
	{

		if (other.gameObject.CompareTag("Hammer"))
		{
			MoguraAttackAni.SetTrigger("Parry");
			Debug.Log("Parry");
		}
	}
}
