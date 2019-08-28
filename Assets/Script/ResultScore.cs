using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultScore : MonoBehaviour
{
	public TextMesh Result;
	float HighScore;
	string Key = "High Score";

	
	void Start()
    {
		//PlayerPrefs.DeleteAll();//ハイスコアリセットの時に使う
		HighScore = PlayerPrefs.GetFloat(Key, 0);
		
    }

    // Update is called once per frame
    void Update()
    {
		if(HighScore < SceroManager.ScoreManager.GetScore())
		{
			HighScore = SceroManager.ScoreManager.GetScore();
			PlayerPrefs.SetFloat(Key, HighScore);
		}
		Result.text = "スコア  " + SceroManager.ScoreManager.GetScore()
			+ "\nハイスコア"　+ HighScore
			+ "\n叩いたモグラの数　" + SceroManager.ScoreManager.GetAttacMoguraCount() + "/" + MoguraObjectManager.GetMoguraCount()
			+ "\n店長を叩いた回数  " + SceroManager.ScoreManager.GetAttackOjisanCount() + "/" + MoguraObjectManager.GetOjisanCount();//頭悪い羅列
	}
}
