using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SceroManager
{
    public class ScoreManager : MonoBehaviour
    {
    
        public static float scoreCount;

        public TextMesh textMesh;

        void Start()
        {
            scoreCount = 0; //スコアリセット
        }

        public static void AddScore(int addPoint) //Scoreスクリプトから起動
        {
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
    }
}
