using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public Text scoreLabel;
    public float scoreCount;

    void Start()
    {
        scoreCount = 0; //スコアリセット

        scoreLabel.text = "Score : " + scoreCount; //スコア表示
    }

    public void AddScore(int addPoint) //Scoreスクリプトから起動
    {
        scoreCount = scoreCount + addPoint; //スコア加算
    }

    void Update()
    {
        if (scoreCount < 0) //スコアが0未満になった時に発動(スコア0の時に減点したとき用)
        {
            scoreCount = 0;
        }

        scoreLabel.text = "Score : " + scoreCount; //スコア表示
    }
}
