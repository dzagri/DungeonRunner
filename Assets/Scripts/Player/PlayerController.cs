using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    new CapsuleCollider collider;
    readonly int minHeartAmount = 0;
    internal readonly int maxHeartAmount = 3;
    internal int currentHeartAmount;
    internal bool healable;
    readonly float slideTimer = 1.2f;
    readonly Vector3[] lanes = new Vector3[3];
    int currentLane;

    void Awake() =>collider = GetComponent<CapsuleCollider>();
    private void Start()
    {
        currentHeartAmount = maxHeartAmount;

        lanes[0] = new Vector3(2.5f, transform.position.y, transform.position.z);
        lanes[1] = new Vector3(0f, transform.position.y, transform.position.z);
        lanes[2] = new Vector3(-2.5f, transform.position.y, transform.position.z);
        currentLane = 1;
    }
    private void Update()
    {
        Health();
    }
    void Health()
    {
        GameManager.instance.heartAmount = currentHeartAmount;
        if (GameManager.instance.playerDamage)
        {
            GameManager.instance.playerDamage = false;
            currentHeartAmount--;
        }
        if(currentHeartAmount <= minHeartAmount)
        {
            GameManager.instance.playerDead = true;
        }
    }
    internal void MoveRight()
    {
        if (currentLane > 0)
        {
            currentLane--;
            StartCoroutine(MoveToLane(currentLane));
        }
    }
    internal void MoveLeft()
    {
        if (currentLane < 2)
        {
            currentLane++;
            StartCoroutine(MoveToLane(currentLane));
        }
    }

    IEnumerator MoveToLane(int lane)
    {
        Vector3 start = transform.position;
        Vector3 end = new(lanes[lane].x, transform.position.y, transform.position.z);
        float elapsed = 0f;
        float duration = 0.2f;

        while (elapsed < duration)
        {
            transform.position = Vector3.Lerp(start, end, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = end;
    }
    internal IEnumerator Slide()
    {
        collider.height = 1;
        yield return new WaitForSeconds(slideTimer);
        collider.height = 2;
        yield return null;
    }

    
}