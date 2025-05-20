using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] Transform[] menus;
    [SerializeField] Image[] heartImages;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text coinText;

    void Start() => GameManager.instance.OnGameOver += DeathMenu;
    void OnDisable() => GameManager.instance.OnGameOver -= DeathMenu;

    void Update()
    {
        Stats();
    }

    void Stats()
    {
        scoreText.text = Mathf.FloorToInt(GameManager.instance.currentScore).ToString();
        coinText.text = Mathf.FloorToInt(GameManager.instance.coins).ToString();
        Hearts();
    }

    public void SceneChange(int index)
    {
        GameManager.instance.GameStart();
        SceneManager.LoadScene(index);
    }

    void Hearts()
    {
        switch (GameManager.instance.heartAmount)
        {
            case 0:
                heartImages[2].color = Color.gray;
                heartImages[1].color = Color.gray;
                heartImages[0].color = Color.gray;
                break;
            case 1:
                heartImages[2].color = Color.gray;
                heartImages[1].color = Color.gray;
                heartImages[0].color = Color.red;
                break;
            case 2:
                heartImages[2].color = Color.gray;
                heartImages[1].color = Color.red;
                heartImages[0].color = Color.red;
                break;
            case 3:
                heartImages[2].color = Color.red;
                heartImages[1].color = Color.red;
                heartImages[0].color = Color.red;
                break;
        }
    }

    void DeathMenu()
    {
        menus[0].gameObject.SetActive(false);
        menus[1].gameObject.SetActive(true);
    }

    
}
