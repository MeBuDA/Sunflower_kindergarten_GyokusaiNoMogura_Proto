﻿//このスクリプトは完全にデバック用

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRig : MonoBehaviour
{
    private Transform transForm;
    public float mouseSensitivity=1;
    void Start()
    {
        transForm = GetComponent<Transform>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse1))
        {
            var xPosition　=Input.GetAxis("Mouse X");
            transForm.Rotate(new Vector3(0,xPosition*mouseSensitivity,0));
        }
    }
}
