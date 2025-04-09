using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    readonly Vector3 rightposition = new(1, 0, 0);
    readonly Vector3 middlePosition = new(0, 0, 0);
    bool positionChanged;
    new Collider collider;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
    }

    void Start()
    {
        rb.freezeRotation = true;
    }

    internal void MoveRight()
    {
        positionChanged = false;

        if (!positionChanged && transform.position == -rightposition)
        {
            transform.position = middlePosition;
            positionChanged = true;
        }
        else if (!positionChanged)
        {
            transform.position = rightposition;
            positionChanged = true;
        }
    }
    internal void MoveLeft()
    {
        positionChanged = false;

        if(!positionChanged && transform.position == rightposition)
        {
            transform.position = middlePosition;
            positionChanged = true;
        }
        else if(!positionChanged)
        {
            transform.position = -rightposition; 
            positionChanged = true;
        }
    }
    internal void Slide()
    {
        collider.enabled = false;
        StartCoroutine(WaitForSlide());
    }

    IEnumerator WaitForSlide()
    {
        yield return new WaitForSeconds(1.5f);
        collider.enabled = true;
        yield return null;
    }
}