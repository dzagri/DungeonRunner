using System.Collections;
using UnityEngine;

public class ManageCollectibles : MonoBehaviour
{
    int coins;
    internal Transform magnetArea;
    PlayerController playerController;
    internal bool scoreMultiplier;

    private void Awake()
    {
        magnetArea = GameObject.FindGameObjectWithTag("MagnetArea").transform;
    }
    void Start()
    {
        magnetArea.GetComponent<SphereCollider>().enabled = false;
        playerController = GetComponent<PlayerController>();
    }
    private void Update()
    {

    }
    internal void Coin(int amount)
    {
        coins += amount;
        GameManager.instance.coins = coins;
    }

    internal void Magnet(float duration, bool isActive)
    {
        magnetArea.gameObject.SetActive(true);
        if(isActive)
        {
            StartCoroutine(MagnetTime(duration));
        }
    }

    internal void Heart(int amount)
    {
        int coinAmount = 10;
        if(playerController.currentHeartAmount != playerController.maxHeartAmount)
        {
            playerController.currentHeartAmount += amount;
        }
        else
        {
            Coin(coinAmount);
        }
    }
    IEnumerator MagnetTime(float duration)
    {
        yield return new WaitForSeconds(duration);
        magnetArea.gameObject.SetActive(false);
    }

    internal void ScoreMultiplier(float duration, bool isActive)
    {
        if (isActive)
        {
            StartCoroutine(ScoreMultiplierTime(duration));
        }
    }

    IEnumerator ScoreMultiplierTime(float duration)
    {
        GameManager.instance.scoreMultiplier = 10;
        yield return new WaitForSeconds(duration);
        GameManager.instance.scoreMultiplier = 1;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            other.transform.position = Vector3.Lerp(other.transform.position, transform.position, Mathf.SmoothStep(0.0f, 1.0f, 0.2f));
        }
    }
}
