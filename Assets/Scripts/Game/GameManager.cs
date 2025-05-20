using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    internal int coins;
    public int heartAmount;
    internal float currentScore;
    internal float highScore;
    internal float scoreSpeed;
    internal float scoreMultiplier;
    internal float platformSpeed = 5;
    internal bool playerDead;
    public bool playerDamage;
    public bool gameRestart;
    readonly float speedIncreaseInterval = 30f;
    readonly float scoreSpeedIncreaseAmount = 0.3f;
    float timeSinceLastIncrease = 0f;

    public event Action OnGameOver;
    private enum GameState
    {
        running,
        paused
    }
    private GameState currentState;
    void Awake()
    {
        scoreSpeed = 0.4f;
        scoreMultiplier = 1.0f;
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GameStart()
    {
        currentState = GameState.running;
        playerDead = false;
        Time.timeScale = 1f;
        currentScore = 0;
        coins = 0;
        platformSpeed = 5;
        scoreSpeed = 0.4f;
    }

    void Update()
    {
        StateManager();
        AddScore();
    }

    void OnEnable() => SceneManager.sceneLoaded += OnSceneLoaded;

    void OnDisable() => SceneManager.sceneLoaded -= OnSceneLoaded;

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) => GameStart();
    void StateManager()
    {
        if (playerDead && currentState != GameState.paused)
        {
            currentState = GameState.paused;
            OnGameOver?.Invoke();
        }
        else if (!playerDead)
        {
            currentState = GameState.running;
        }

        GameStates();
    }

    void SpeedIncrease()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            timeSinceLastIncrease += Time.deltaTime;

            if (timeSinceLastIncrease >= speedIncreaseInterval)
            {
                platformSpeed += 2.5f;
                scoreSpeed += scoreSpeedIncreaseAmount;
                timeSinceLastIncrease = 0f;
            }
        }
        else
        {
            platformSpeed = 5;
        }
    }
    void GameStates()
    {
        switch (currentState)
        {
            case GameState.running:
                if (Time.timeScale != 1f) Time.timeScale = 1f;
                SpeedIncrease();
                break;
            case GameState.paused:
                if (Time.timeScale != 0f) Time.timeScale = 0f;
                break;
        }
    }
    private void AddScore()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            currentScore += scoreSpeed * scoreMultiplier;

        }
        if (currentScore >= highScore)
        {
            highScore = currentScore;
        }

    }
}
