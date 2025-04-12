using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    readonly Vector3 rightposition = new(2f, 0, 0);
    readonly Vector3 middlePosition = new(0, 0, 0);
    bool positionChanged;
    new Collider collider;

    void Awake()
    {
        collider = GetComponent<Collider>();
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

        if(!positionChanged && transform.position == rightposition)
        {
            transform.position = Vector3.Lerp(transform.position, middlePosition, 1);
            positionChanged = true;
        }
        else if(!positionChanged)
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

    IEnumerator WaitForSlide()
    {
        yield return new WaitForSeconds(1.5f);
        collider.enabled = true;
        yield return null;
    }
}