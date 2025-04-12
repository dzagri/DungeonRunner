using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    Camera cam;

    void Awake()
    {
        cam = Camera.main;
    }

    void LateUpdate()
    {
        if (cam != null)
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, transform.position, Mathf.SmoothStep(0.0f, 1.0f, 0.5f));
        }
    }
}