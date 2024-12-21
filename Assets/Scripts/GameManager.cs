using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private int score;

    public void GameOver()
    {
        Debug.LogError("Game Over");
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = "Score : "+score.ToString();
        Debug.Log("IncreaseScore : "+ score);
    }
}
