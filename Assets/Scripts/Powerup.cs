using UnityEngine;

public class Powerup : MonoBehaviour
{
    [Header("!!! Powerup Type !!!")]
    [SerializeField] bool healler;
    [SerializeField] bool firingRateIncreaser;

    [Header("Healler")]
    [SerializeField] int healAmount = 25;

    [Header("Firing Rate Increaser")]
    [SerializeField] float increaseAmount = 1.05f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(healler)
            AddHealth(collision);
        else if(firingRateIncreaser)
            IncreaseFiringRate(collision);
    }

    void AddHealth(Collider2D collision)
    {
        Health playerHealth = collision.GetComponent<Health>();

        if (playerHealth != null)
        {
            playerHealth.AddToHealth(healAmount);
            Destroy(gameObject);
        }
    }

    void IncreaseFiringRate(Collider2D collision)
    {
        Shooter shooter = collision.GetComponent<Shooter>();

        if(shooter != null)
        {
            shooter.IncreaseFiringRate(increaseAmount);
            Destroy(gameObject);
        }
    }
}
