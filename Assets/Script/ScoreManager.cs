using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SceroManager
{
    public class ScoreManager : MonoBehaviour
    {
    
        public static float scoreCount;
		public static float AttackMoguraCount;//モグラに攻撃した回数
		public static float AttackOjisanCount;//おじさんに攻撃した回数
		public TextMesh textMesh;

        void Start()
        {
            scoreCount = 0; //スコアリセット
        }

        public static void AddScore(int addPoint) //Scoreスクリプトから起動
        {
			if (addPoint > 0)//スコアが－か＋かで店長とモグラを判別
			{
				AttackMoguraCount++;
			}
			else if (addPoint < 0)
			{
				AttackOjisanCount++;
			}
			scoreCount = scoreCount + addPoint; //スコア加算
        }

        void Update()
        {
            if (scoreCount < 0) //スコアが0未満になった時に発動(スコア0の時に減点したとき用)
            {
                scoreCount = 0;
            }

            textMesh.text = "Score\n" + scoreCount;
        }
		public static float GetScore()//スコアとカウントを他シーンに拝借
		{
			return scoreCount;
		}
		public static float GetAttacMoguraCount()
		{
			return AttackMoguraCount;
		}
		public static float GetAttackOjisanCount()
		{
			return AttackOjisanCount;
		}
	}
}
