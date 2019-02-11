using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ScoreController : NetworkBehaviour {

    Text scoreText;

    [SyncVar(hook = "updateScoreText")]
    int score;

	// Use this for initialization
	void Start ()
    {
        scoreText = GetComponent<Text>();
        score = 0;
	}
	
	public void updateScore()
    {
        score++;
    }
    public void updateScoreText(int newScore)
    {
        scoreText.text = newScore + "";
        scoreText.fontSize = 170;

        if (scoreText.tag == "PlayerScore")
        {
            scoreText.color = new Color32(110, 255, 178, 255);
        }
        else if (scoreText.tag == "EnemyScore")
        {
            scoreText.color = new Color32(255, 0, 0, 255);
        }
        Invoke("resetColor", 2);
    }
    void resetColor()
    {
        scoreText.color = new Color32(255, 255, 255, 157);
        scoreText.fontSize = 150;
    }
}
