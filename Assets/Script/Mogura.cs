using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mogura : MonoBehaviour
{

    //デバック用はあとでモグラマネージャー作って分ける
    //マネージャ付けないと無理ゲーと化すし難易度調整できん
    private int randomCount;//デバック用
    public int randomCountMax=200;//デバック用
    private Animator animator ;
    void Start()
    {
        animator =this.GetComponent<Animator>();
    }
    void Update()
    {
        randomCount=Random.Range(1,randomCountMax);//デバック用
        if(randomCount==50)MoguraOut();//デバック用
    }

    void MoguraOut()
    {
        animator.SetTrigger("MoguraStart"); 
        //アニメーションで管理してるけどtransformのほうがいいかも
        //Prefabにするとずれる
    }
    
    void OnTriggerEnter()
    {
        animator.SetTrigger("Attack");
    }
}
