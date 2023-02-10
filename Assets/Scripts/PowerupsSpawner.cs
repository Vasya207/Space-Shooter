using System.Collections;
using UnityEngine;

public class PowerupsSpawner : MonoBehaviour
{
    [Header("Powerups Prefabs")]
    [SerializeField] GameObject powerup;

    [Header("Spawn Time Settings")]
    [SerializeField] float timeBeforeFirstSpawn = 7.5f;
    [SerializeField] float timeBetweenSpawns = 15f;
    [SerializeField] float spawnTimeVariance = 5f;
    [SerializeField] float minimumSpawnTime = 7.5f;

    [Header("Powerups Settings")]
    [SerializeField] float powerupMoveSpeed = 5f;
    [SerializeField] float powerupLifeTime = 7f;

    Vector2 minBounds;
    Vector2 maxBounds;
    Rigidbody2D powerupRigidbody;

    void Start()
    {
        SetBoundariesForSpawn();
        StartCoroutine(SpawnPowerups());
    }

    IEnumerator SpawnPowerups()
    {
        yield return new WaitForSeconds(timeBeforeFirstSpawn);
        while (true)
        {
            float randomXPos = Random.Range(minBounds.x, maxBounds.x);
            Vector3 newSpawnPosition = new(randomXPos, transform.position.y, transform.position.z);

            GameObject powerupInstance = 
                Instantiate(powerup, newSpawnPosition, Quaternion.identity, transform);

            powerupRigidbody = powerupInstance.GetComponent<Rigidbody2D>();
            if(powerupRigidbody != null)
            {
                powerupRigidbody.velocity = -transform.up * powerupMoveSpeed;
            }

            Destroy(powerupInstance, powerupLifeTime);
            yield return new WaitForSeconds(GetRandomSpawnTime());
        }
    }

    void SetBoundariesForSpawn()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));

        minBounds.x++; maxBounds.x--;
    }

    float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(timeBetweenSpawns - spawnTimeVariance,
            timeBetweenSpawns + spawnTimeVariance);
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }
}
