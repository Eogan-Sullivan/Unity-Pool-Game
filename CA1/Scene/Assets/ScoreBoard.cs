using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreBoard: MonoBehaviour
{
  

    public Text scoreText;
    private int score;

    void Start()
    {
        score = 0;

    }

   

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
}