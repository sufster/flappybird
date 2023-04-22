using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;

    public GameObject playButton;
    public GameObject gameOver;


    private int score;

    public void IncreaseScore()
    {
        score++;
    }

    public void GameOver()
    {
        Debug.Log("Game over!");
    }
}
