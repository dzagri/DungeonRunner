using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    private Vector2 touchStartPos;
    private Vector2 touchEndPos;
    private float swipeThreshold = 50f;
    private float slideThreshold = 200f;
    private float slideDurationThreshold = 0.5f;
    private float touchStartTime;

    private bool isSliding = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        HandleTouchInput();
    }

    private void HandleTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStartPos = touch.position;
                    touchStartTime = Time.time;
                    break;

                case TouchPhase.Moved:
                    touchEndPos = touch.position;
                    break;

                case TouchPhase.Ended:
                    HandleTouchRelease(touch);
                    break;
            }
        }
    }

    private void HandleTouchRelease(Touch touch)
    {
        Vector2 swipeDelta = touch.position - touchStartPos;
        float touchDuration = Time.time - touchStartTime;

        if (swipeDelta.magnitude >= swipeThreshold)
        {
            HandleSwipe(swipeDelta);
        }
        else if (touchDuration >= slideDurationThreshold && swipeDelta.magnitude >= slideThreshold)
        {
            HandleSlide(swipeDelta);
        }
        else
        {
            HandleTap(touch.position);
        }
    }

    private void HandleTap(Vector2 tapPosition)
    {
        Debug.Log("Tap detected at position: " + tapPosition);
    }

    private void HandleSwipe(Vector2 swipeDelta)
    {
        if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
        {
            if (swipeDelta.x > 0)
                Debug.Log("Swipe Right");
            else
                Debug.Log("Swipe Left");
        }
        else
        {
            if (swipeDelta.y > 0)
                Debug.Log("Swipe Up");
            else
                Debug.Log("Swipe Down");
        }
    }

    private void HandleSlide(Vector2 slideDelta)
    {
        isSliding = true;

        Debug.Log("Slide detected!");


        Invoke("ResetSlideFlag", 0.5f);
    }

    private void ResetSlideFlag()
    {
        isSliding = false;
    }

    public bool IsSliding()
    {
        return isSliding;
    }
}
