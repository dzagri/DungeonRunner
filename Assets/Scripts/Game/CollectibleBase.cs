using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class CollectibleBase : MonoBehaviour, ICollectible
{
    float timer;
    public abstract void Collect(ManageCollectibles manager);

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.TryGetComponent<ManageCollectibles>(out var manager))
            {
                Collect(manager);
                gameObject.SetActive(false);
            }
        }
        if (CompareTag("Coin") && other.CompareTag("MagnetArea"))
        {
            timer = Time.time;
            if(timer >= 2)
            {
                gameObject.SetActive(false);
            }
        }
    }

}
