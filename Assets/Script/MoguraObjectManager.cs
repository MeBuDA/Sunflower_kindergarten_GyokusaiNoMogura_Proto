using System.Collections;
using System.Collections.Generic;
using MoguraPosition; //Mogura.csの情報を取ってきてる
using UnityEngine;

public class MoguraObjectManager : MonoBehaviour
{
    [SerializeField] int randomCountMax = 100; //出現頻度、上げると全然でなくて下げるとめっちゃ出る
    public GameObject[] moguraObject; //MoguraObjectのPrefabをアタッチして
    public MoguraPosition.Mogura[] moguraPosition;//= new MoguraPosition.Mogura[size];
	

	void Awake ()
    {
        for (int i = 0; moguraObject.Length > i; i++)
        {
           moguraPosition[i] =  moguraObject[i].GetComponent<Mogura> ();
        }

    }

	
    void Update ()
    {
        int randomCount = Random.Range (1, randomCountMax);
		

        if (randomCount == 1)
        {
            int moguraPopPosition = Random.Range (0, moguraPosition.Length);
			

			//とりあえず13個まで対応
			switch (moguraPopPosition)
            {
				 
                case 0:
					Select();
                    break;
				case 1:
					Select();
					break;
				case 2:
					Select();
					break;
				case 3:
					Select();
					break;
				case 4:
					Select();
					break;
				case 5:
					Select();
					break;
				case 6:
					Select();
					break;
				case 7:
					Select();
					break;
				case 8:
					Select();
					break;
				case 9:
					Select();
					break;
				case 10:
					Select();
					break;
				case 11:
					Select();
					break;
				case 12:
					Select();
					break;
				case 13:
					Select();
					break;
				default:
                    break;
            }
			void Select()//どのモグラを出すかを決める
			{
				int RandomSelect = Random.Range(0, 25);

				if (RandomSelect < 15)
				{
					moguraPosition[moguraPopPosition].MoguraOut();
				}
				else if (14 < RandomSelect && RandomSelect < 20)
				{
					moguraPosition[moguraPopPosition].BossMoguraOut();
				}
				else if (19 < RandomSelect && RandomSelect < 21)
				{
					moguraPosition[moguraPopPosition].GoldMoguraOut();
				}
				else if (20 < RandomSelect && RandomSelect < 26)
				{
					moguraPosition[moguraPopPosition].OjisanOut();
				}

			}
		}
    }
}