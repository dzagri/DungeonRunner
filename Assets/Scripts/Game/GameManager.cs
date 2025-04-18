using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    internal float currentScore;
    internal float highScore;
    internal bool playerDead;
    float scoreSpeed;
    internal float scoreMultiplier;
    internal int coins;
    internal int heartAmount;
    private enum GameState
    {
        running,
        paused
    }
    private GameState currentState;
    private void Awake()
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
    private void Update()
    {
        StateManager();
        AddScore();
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
    void StateManager()
    {
        GameStates();
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            playerDead = false;
            currentState = GameState.running;
            currentScore = 0;
        }
        if (!playerDead)
        {
            currentState = GameState.running;
        }
        else
        {
            currentState = GameState.paused;
        }
    }
    void GameStates()
    {
        switch (currentState)
        {
            case GameState.running:
                Time.timeScale = 1.0f;
                break;
            case GameState.paused:
                Time.timeScale = 0f;
                SceneManager.LoadScene(sceneBuildIndex: 0);
                break;
        }
    }
}
