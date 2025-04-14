using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    readonly Vector3 rightposition = new(2.5f, 0, 0);
    readonly Vector3 middlePosition = new(0, 0, 0);
    bool positionChanged;
    new Collider collider;
    Transform cart;

    void Awake()
    {
        collider = GetComponent<Collider>();
        cart = GameObject.FindGameObjectWithTag("MineCart").transform;
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
            Time.timeScale = 0f;
        }
    }
    IEnumerator WaitForSlide()
    {
        yield return new WaitForSeconds(1.5f);
        collider.enabled = true;
        yield return null;
    }
}