using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerSwingSound : MonoBehaviour{
    private GameObject hammer;
    private static CriAtomSource swing;

    private Vector3 latestPos;
    private Vector3 deltaPosition;
    public float speed;
    public float refSpeed = 13.0f;
    public int swingCounter = 0;

    void Start(){
        hammer = GameObject.Find("Head");
        swing = GetComponent<CriAtomSource>();
    }

    // Update is called once per frame
    void Update(){
        deltaPosition = (hammer.transform.position - latestPos) / Time.deltaTime;
        speed = deltaPosition.magnitude;

        if(speed >= refSpeed){
            swing.Play();
            swingCounter++;
        }

        latestPos = hammer.transform.position;
    }
}
