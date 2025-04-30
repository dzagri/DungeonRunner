using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] internal GameObject[] platformPool;
    internal int randomIndex;
    internal bool isAsked;
    readonly Vector3 spawnPosition = new(0, 0, 100f);
    internal static PlatformManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        ChooseFirstPlatform();
    }

    void Update()
    {
        ControlPlatforms();
    }

    void ChooseFirstPlatform()
    {
        randomIndex = Random.Range(0, platformPool.Length);
        platformPool[randomIndex].SetActive(true);
        platformPool[randomIndex].transform.position = spawnPosition;
    }

    void ControlPlatforms()
    {
        if (isAsked)
        {
            randomIndex = Random.Range(0, platformPool.Length);
            if (!platformPool[randomIndex].activeSelf)
            {
                platformPool[randomIndex].SetActive(true);
                platformPool[randomIndex].transform.position = spawnPosition;
                foreach (Transform child in platformPool[randomIndex].GetComponentsInChildren<Transform>(true))
                {
                    child.gameObject.SetActive(true);
                }
                isAsked = false;
            }
        }
    }
}
