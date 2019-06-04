using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollStick : MonoBehaviour
{
    private　 Transform transForm;
    //private Rigidbody rb;
    public float moveSpeed = 1;
    void Start ()
    {
        transForm = this.GetComponent<Transform> ();
        //rb = this.GetComponent<Rigidbody> ();
    }
    void Update ()
    {
        if (Input.GetKey (KeyCode.Mouse0))
        {
            if (transForm.localEulerAngles.x < 90)
            {
            transForm.Rotate (new Vector3 (moveSpeed, 0, 0));
            }
            //if (transForm.localEulerAngles.x > 100) transForm.localEulerAngles = (new Vector3 (90f, 0, 0));
            //rb.angularVelocity = new Vector3 (1.0f, 0, 0) * moveSpeed;
        }
        if (Input.GetKeyUp (KeyCode.Mouse0)) transForm.localEulerAngles = Vector3.zero;
    }
}