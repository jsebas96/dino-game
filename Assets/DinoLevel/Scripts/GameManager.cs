using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private float initialScrollSpeed;
    [SerializeField] private GameObject dinoGameObject;


    private int score;
    private static int highScore;
    private float timer;
    private float scrollSpeed;
    private Dino dino;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        highScoreText.text = string.Format("HI {0:00000}", highScore);
        dino = dinoGameObject.GetComponent<Dino>();
    }

    void Update()
    {
        UpdateScore();
        UpdateSpeed();
        if (Input.GetKeyDown(KeyCode.Space) && !dino.GetDinoIsAlive())
        {
            RestartScene();
        }
    }

    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    private void UpdateScore()
    {
        int scorePerSeconds = 10;

        timer += Time.deltaTime;
        score = (int)(timer * scorePerSeconds);
        scoreText.text = string.Format("{0:00000}", score);
        if (score > highScore)
        {
            highScore = score;
            highScoreText.text = string.Format("HI {0:00000}", highScore);
        }
    }

    public float GetScrollSpeed()
    {
        return scrollSpeed;
    }

    private void UpdateSpeed()
    {
        float speedDivider = 8f;
        scrollSpeed = initialScrollSpeed + timer / speedDivider;
    }
}
