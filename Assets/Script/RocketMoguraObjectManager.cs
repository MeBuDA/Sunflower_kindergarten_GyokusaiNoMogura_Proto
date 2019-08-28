using System.Collections;
using System.Collections.Generic;
using RocketMoguraPosition;
using UnityEngine;

//エレノアニキのスクリプトをパk･･･参考にさせてもらったよ！　エレノアニキありがと

public class RocketMoguraObjectManager : MonoBehaviour
{
    [SerializeField] int randomCountMax_Rocket = 100;
    public RocketMoguraPosition.RocketMogura[] rocketMoguraPosition;

    private int randomCountRocket_Rocket;
    private int rocketMoguraPopPosition;

    void Update()
    {
        randomCountRocket_Rocket = Random.Range(1, randomCountMax_Rocket);

        if (randomCountRocket_Rocket == 1)
        {
            rocketMoguraPopPosition = Random.Range(0, rocketMoguraPosition.Length);

            switch (rocketMoguraPopPosition)
            {
                case 0:
                    Fire();
                    break;
                case 1:
                    Fire();
                    break;
                case 2:
                    Fire();
                    break;
                case 3:
                    Fire();
                    break;
                case 4:
                    Fire();
                    break;
            }
        }
    }

    void Fire()
    {
        rocketMoguraPosition[rocketMoguraPopPosition].RocketMoguraFire();
    }
}