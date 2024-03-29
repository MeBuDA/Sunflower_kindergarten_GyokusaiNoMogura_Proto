﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDeath : MonoBehaviour
{
    public float effectDeathTime;
    void Start()
    {
        Invoke("EffectFinish", effectDeathTime);
    }

    void EffectFinish()
    {
        Destroy(this.gameObject);
    }
}