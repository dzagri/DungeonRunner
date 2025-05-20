using UnityEngine;

public class Spike : MonoBehaviour
{
    Animator animator;

    void Start() => animator = GetComponent<Animator>();
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("Activate");
            GameManager.instance.playerDamage = true;
        }
    }
    
}
