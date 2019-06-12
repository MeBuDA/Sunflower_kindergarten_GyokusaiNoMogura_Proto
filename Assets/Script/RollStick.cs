//このスクリプトは完全にデバック用
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollStick : MonoBehaviour
{

    private Transform transForm;
    [SerializeField] float moveSpeed = 1; //振り下ろし速度
    void Start()
    {
        transForm = this.GetComponent<Transform>();
    }
    void Update()
    {

        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (transForm.localEulerAngles.x < 95) //90度以上行かないようにしてる→衝突検証用に数値上げてそのまま
            {
                transForm.Rotate(new Vector3(moveSpeed, 0, 0));
            }

        }
        if (Input.GetKeyUp(KeyCode.Mouse0)) transForm.localEulerAngles = Vector3.zero; //初期値に戻る
    }
    //ハンマーと土管の当たり判定
    void OnCollisionStay(Collision kan)
    {
        if(kan.gameObject.tag == "Kan") //Kanは土管用のTAG
        {
            transForm.localEulerAngles = new Vector3(90f,0,0);
            Debug.Log("Hit" ); //デバッグログ邪魔だったら消してOK
        }
    }
}