using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollStick : MonoBehaviour
{
    private　 Transform transForm;
    public float moveSpeed = 1;
    void Start ()
    {
        transForm = this.GetComponent<Transform> ();
    }
    void Update ()
    {
        if (Input.GetKey (KeyCode.Mouse0))
        {
            if (transForm.localEulerAngles.x < 90)
            {
            transForm.Rotate (new Vector3 (moveSpeed, 0, 0));
            }
           
        }
        if (Input.GetKeyUp (KeyCode.Mouse0)) transForm.localEulerAngles = Vector3.zero;
    }
}