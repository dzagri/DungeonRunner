using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text coinText;
    [SerializeField] Image[] heartImages;

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

    void Hearts()
    {
        if (GameManager.instance.heartAmount == 3)
        {
            heartImages[2].color = Color.red;
            heartImages[1].color = Color.red;
            heartImages[0].color = Color.red;
        }
        else if (GameManager.instance.heartAmount == 2)
        {
            heartImages[2].color = Color.gray;
            heartImages[1].color = Color.red;
            heartImages[0].color = Color.red;
        }
        else if (GameManager.instance.heartAmount == 1)
        {
            heartImages[2].color = Color.gray;
            heartImages[1].color = Color.gray;
            heartImages[0].color = Color.red;
        }
        else
        {
            heartImages[2].color = Color.gray;
            heartImages[1].color = Color.gray;
            heartImages[0].color = Color.gray;
        }
    }
}
