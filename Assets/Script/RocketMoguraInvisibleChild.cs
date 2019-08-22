using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMoguraInvisibleChild : MonoBehaviour
{
    public string nameRocketMogura;
    private bool flagChild;

    Color color;

    void Start()
    {
        color = gameObject.GetComponent<Renderer>().material.color;
    }

    void Update()
    {
        flagChild = GameObject.Find(nameRocketMogura).GetComponent<RocketMoguraInvisible>().flag;

        if (flagChild == true)
        {
            color.a = 0.0f;
            gameObject.GetComponent<Renderer>().material.color = color;
        }

        if (flagChild == false)
        {
            color.a = 1.0f;
            gameObject.GetComponent<Renderer>().material.color = color;
        }
    }
}

//color = gameObject.GetComponent<Renderer>().material.color;

//color.a = 1.0f;
//gameObject.GetComponent<Renderer>().material.color = color;
