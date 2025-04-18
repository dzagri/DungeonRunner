using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUIManager : MonoBehaviour
{
    [SerializeField] TMP_Text highScoretext;

    void Start()
    {
        HighScore();
    }

    void HighScore()
    {
        highScoretext.text = Mathf.FloorToInt(GameManager.instance.highScore).ToString();
    }
    public void StartButton()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }
}
