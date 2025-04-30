using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 rightposition;
    Vector3 middlePosition;
    bool positionChanged;
    new CapsuleCollider collider;
    readonly int minHeartAmount = 0;
    internal readonly int maxHeartAmount = 3;
    internal int currentHeartAmount;
    internal bool healable;
    readonly float slideTimer = 1.2f;

    void Awake() =>collider = GetComponent<CapsuleCollider>();
    private void Start()
    {
        rightposition = new(2.5f, transform.position.y, transform.position.z);
        middlePosition = new(0, transform.position.y, transform.position.z);
        currentHeartAmount = maxHeartAmount;
        GameManager.instance.heartAmount = currentHeartAmount;
    }
    private void Update()
    {
        Health();
    }
    void Health()
    {
        GameManager.instance.heartAmount = currentHeartAmount;
        if(currentHeartAmount <= minHeartAmount)
        {
            GameManager.instance.playerDead = true;
        }
    }
    internal void MoveRight()
    {
        positionChanged = false;

        if (!positionChanged && transform.position == -rightposition)
        {
            transform.position = Vector3.Lerp(transform.position, middlePosition, 1);
            positionChanged = true;
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, rightposition, 1);
            positionChanged = true;
        }
    }
    internal void MoveLeft()
    {
        positionChanged = false;

        if (!positionChanged && transform.position == rightposition)
        {
            transform.position = Vector3.Lerp(transform.position, middlePosition, 1);
            positionChanged = true;
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, -rightposition, 1);
            positionChanged = true;
        }
    }
    internal IEnumerator Slide()
    {
        collider.height = 1;
        yield return new WaitForSeconds(slideTimer);
        collider.height = 2;
        yield return null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.SetActive(false);
        if (collision.transform.CompareTag("Barrier"))
        {
            currentHeartAmount--;
        }
    }
}