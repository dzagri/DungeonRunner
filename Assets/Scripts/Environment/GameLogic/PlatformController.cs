using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] List<GameObject> platforms = new List<GameObject>();
    int speed = 3;
    bool started;
    void Start()
    {
        started = true;
    }

    void Update()
    {
        if (started)
        {
            transform.position += new Vector3(0, 0, -.03f);
        }
    }
}
