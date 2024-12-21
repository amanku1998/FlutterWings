using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private Player player;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject gameOver;

    private int score;

    private void Awake()
    {
        if (Instance != null){
            DestroyImmediate(gameObject);
        }
        else{
            Instance = this;
        }

        Pause();
        playButton.GetComponent<Button>().onClick.AddListener(Play);
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    public void Play()
    {
        score = 0;
        scoreText.text = "Score : " + score.ToString();

        gameOver.SetActive(false);
        playButton.SetActive(false);

        Time.timeScale = 1;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();
        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }
    
    public void Pause()
    {
        Time.timeScale = 0;
        player.enabled = false;
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);

        Pause();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = "Score : "+score.ToString();
    }
}
