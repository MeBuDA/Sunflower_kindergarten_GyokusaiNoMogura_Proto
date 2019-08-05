using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamege : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider att)
    {
        if (att.gameObject.CompareTag("MoguraWeapon"))
        {
            Debug.Log("MoguraWeapon");
        }
    }
}
