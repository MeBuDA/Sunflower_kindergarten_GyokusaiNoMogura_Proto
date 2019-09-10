using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDevMasChange : MonoBehaviour
{
    public bool oculusGo;
    public GameObject oculusGoplayer;
    public GameObject mousePlayer;
    void Awake()
    {
        if(oculusGo)
        {
            oculusGoplayer.SetActive(true);
            mousePlayer.SetActive(false);
        }else
        {
            oculusGoplayer.SetActive(false);
            mousePlayer.SetActive(true);
        }
    }
}
