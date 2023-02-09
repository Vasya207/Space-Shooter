using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] int healAmount = 25;

    Rigidbody2D myRigidbody;

    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    { 
        myRigidbody.velocity = new Vector2(0, -moveSpeed);
    }

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
