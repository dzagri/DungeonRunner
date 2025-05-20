using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    float speed;
    void Update()
    {
        speed = GameManager.instance.platformSpeed;
        transform.position -= new Vector3(0, 0, speed * Time.deltaTime);
        if(transform.position.z <= -100f)
        {
            gameObject.SetActive(false);
            
            PlatformManager.instance.isAsked = true;
        }
    }

}
