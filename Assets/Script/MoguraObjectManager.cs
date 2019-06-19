using System.Collections;
using System.Collections.Generic;
using MoguraPosition; //Mogura.csの情報を取ってきてる
using UnityEngine;

public class MoguraObjectManager : MonoBehaviour
{
	[SerializeField] int randomCountMax = 100; //出現頻度、上げると全然でなくて下げるとめっちゃ出る
	[SerializeField] int SelectMogura = 25; //選ぶモグラの確率の分母
	[SerializeField] int NomalMoguraSelect = 15; //普通のモグラが選ばれる確率の分子
	[SerializeField] int BossMoguraSelect = 5; //ボスモグラが選ばれる確率の分子
	[SerializeField] int GoldMoguraSelect = 1; //ゴールドモグラが選べれる確率の分子
	[SerializeField] int OjisanSelect = 4; //おじさんが選ばれる確率の分s
	public MoguraPosition.Mogura[] moguraPosition; //moguraObjectのアタッチ

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
					Select ();
					break;
				case 1:
					Select ();
					break;
				case 2:
					Select ();
					break;
				case 3:
					Select ();
					break;
				case 4:
					Select ();
					break;
				case 5:
					Select ();
					break;
				case 6:
					Select ();
					break;
				case 7:
					Select ();
					break;
				case 8:
					Select ();
					break;
				case 9:
					Select ();
					break;
				case 10:
					Select ();
					break;
				case 11:
					Select ();
					break;
				case 12:
					Select ();
					break;
				case 13:
					Select ();
					break;
				default:
					break;
			}
			void Select () //どのモグラを出すかを決める
			{
				int RandomSelect = Random.Range (0, SelectMogura);

				int x1 = NomalMoguraSelect + BossMoguraSelect;
				int x2 = x1 + GoldMoguraSelect;
				int x3 = x2 + OjisanSelect;

				if (RandomSelect < NomalMoguraSelect)
				{
					moguraPosition[moguraPopPosition].MoguraOut ();
				}
				else if (NomalMoguraSelect <= RandomSelect && RandomSelect < x1)
				{
					moguraPosition[moguraPopPosition].BossMoguraOut ();
				}
				else if (x1 <= RandomSelect && RandomSelect < x2)
				{
					moguraPosition[moguraPopPosition].GoldMoguraOut ();
				}
				else if (x2 <= RandomSelect && RandomSelect < x3)
				{
					moguraPosition[moguraPopPosition].OjisanOut ();
				}

			}
		}
	}
}