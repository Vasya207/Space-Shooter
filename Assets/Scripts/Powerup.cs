using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] int healAmount = 25;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Health playerHealth = collision.GetComponent<Health>();

        if(playerHealth != null)
        {
            playerHealth.AddToHealth(healAmount);
            Destroy(gameObject);
        }
    }
}
