using System.Collections;
using System.Collections.Generic;
using MoguraPosition; //Mogura.csの情報を取ってきてる
using UnityEngine;

public class MoguraObjectManager : MonoBehaviour
{
    [SerializeField] int randomCountMax = 100; //出現頻度、上げると全然でなくて下げるとめっちゃ出る
    const int size = 5; //合計のモグラ数
    public GameObject[] moguraObject = new GameObject[size]; //MoguraObjectのPrefabをアタッチして
    private MoguraPosition.Mogura[] moguraPosition = new MoguraPosition.Mogura[size];
    void Awake ()
    {
        for (int i = 0; size > i; i++)
        {
            moguraPosition[i] = moguraObject[i].GetComponent<Mogura> ();
        }
    }
    void Update ()
    {
        int randomCount = Random.Range (1, randomCountMax);
        if (randomCount == 1)
        {
            int moguraPopPosition = Random.Range (0, size);
            //とりあえず13個まで対応
            switch (moguraPopPosition)
            {
                case 0:
                    moguraPosition[0].MoguraOut ();
                    break;
                case 1:
                    moguraPosition[1].MoguraOut ();
                    break;
                case 2:
                    moguraPosition[2].MoguraOut ();
                    break;
                case 3:
                    moguraPosition[3].MoguraOut ();
                    break;
                case 4:
                    moguraPosition[4].MoguraOut ();
                    break;
                case 5:
                    moguraPosition[5].MoguraOut ();
                    break;
                case 6:
                    moguraPosition[6].MoguraOut ();
                    break;
                case 7:
                    moguraPosition[7].MoguraOut ();
                    break;
                case 8:
                    moguraPosition[8].MoguraOut ();
                    break;
                case 9:
                    moguraPosition[9].MoguraOut ();
                    break;
                case 10:
                    moguraPosition[10].MoguraOut ();
                    break;
                case 11:
                    moguraPosition[11].MoguraOut ();
                    break;
                case 12:
                    moguraPosition[12].MoguraOut ();
                    break;
                case 13:
                    moguraPosition[13].MoguraOut ();
                    break;
                default:
                    break;
            }
        }
    }
}