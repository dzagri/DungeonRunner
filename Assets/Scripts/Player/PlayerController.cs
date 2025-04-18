using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 rightposition;
    Vector3 middlePosition;
    bool positionChanged;
    new Collider collider;
    readonly int minHeartAmount = 0;
    internal readonly int maxHeartAmount = 3;
    internal int currentHeartAmount;
    internal bool healable;
    bool damage;
    private void Start()
    {
        rightposition = new(2.5f, transform.position.y, transform.position.z);
        middlePosition = new(0, transform.position.y, transform.position.z);
        currentHeartAmount = maxHeartAmount;
        GameManager.instance.heartAmount = currentHeartAmount;
    }
    void Awake()
    {
        collider = GetComponent<Collider>();
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
        else if (!positionChanged)
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
        else if (!positionChanged)
        {
            transform.position = Vector3.Lerp(transform.position, -rightposition, 1);
            positionChanged = true;
        }
    }
    internal void Slide()
    {
        collider.enabled = false;
        StartCoroutine(WaitForSlide());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Barrier"))
        {
            collision.gameObject.SetActive(false);
            currentHeartAmount--;
        }
    }
    IEnumerator WaitForSlide()
    {
        yield return new WaitForSeconds(1.5f);
        collider.enabled = true;
        yield return null;
    }
}