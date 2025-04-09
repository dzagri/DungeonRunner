using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerController playerController;

    Vector2 startTouchPos;
    Vector2 endTouchPos;
    readonly float swipreThreshHold = 50;

    void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                startTouchPos = touch.position;
            }
            if(touch.phase == TouchPhase.Ended)
            {
                endTouchPos = touch.position;
                Vector2 swipeDelta = endTouchPos - startTouchPos;
                if(swipeDelta.magnitude > swipreThreshHold)
                {
                    if(Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
                    {
                        if(swipeDelta.x > 0)
                        {
                            playerController.MoveRight();
                        }
                        else
                        {
                            playerController.MoveLeft();
                        }
                    }
                    else
                    {
                        if(swipeDelta.y < 0)
                        {
                            playerController.Slide();
                        }
                    }
                }
            }
        }
    }
}