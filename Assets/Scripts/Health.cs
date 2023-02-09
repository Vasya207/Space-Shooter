using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int health = 50;
    [SerializeField] int score = 50;
    [SerializeField] ParticleSystem hitEffect;

    [SerializeField] bool applyCameraShake;
    CameraShake cameraShake;
    int startingHealth;

    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;
    LevelManager levelManager;

    void Awake()
    {
        startingHealth = health;
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealler damageDealler = collision.GetComponent<DamageDealler>();

        if(damageDealler != null)
        {
            TakeDamage(damageDealler.GetDamage());
            PlayHitEffect();
            ShakeCamera();
            audioPlayer.PlayDamageClip();
            damageDealler.Hit();
        }
    }

    public int GetHealth() { return health; }

    public void AddToHealth(int value)
    {
        if (isPlayer)
        {
            health = Mathf.Clamp(health + value, 0, startingHealth);
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;

        if (!isPlayer)
        {
            scoreKeeper.ModifyScore(Random.Range(1, 2));
        }

        if(health <= 0)
        {
            Die();
        } 
    }

    void Die()
    {
        if (!isPlayer)
            scoreKeeper.ModifyScore(score);
        else
            levelManager.LoadGameOver();
        Destroy(gameObject);
    }

    void PlayHitEffect()
    {
        if(hitEffect != null)
        {
            ParticleSystem effectInstance = Instantiate(hitEffect, 
                transform.position, 
                Quaternion.identity);

            Destroy(effectInstance.gameObject, 
                effectInstance.main.duration + effectInstance.main.startLifetime.constantMax);
        }
    }

    void ShakeCamera()
    {
        if (applyCameraShake && cameraShake != null)
            cameraShake.Play();
    }
}
