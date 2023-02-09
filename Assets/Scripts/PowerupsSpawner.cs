using System.Collections;
using UnityEngine;

public class PowerupsSpawner : MonoBehaviour
{
    [SerializeField] GameObject powerup;
    [SerializeField] float timeBeforeFirstSpawn = 7.5f;
    [SerializeField] float timeBetweenSpawns = 15f;
    [SerializeField] float spawnTimeVariance = 5f;
    [SerializeField] float minimumSpawnTime = 7.5f;

    void Start()
    {
        StartCoroutine(SpawnPowerups());
    }

    IEnumerator SpawnPowerups()
    {
        yield return new WaitForSeconds(timeBeforeFirstSpawn);
        while (true)
        {
            int randomXPos = Random.Range(-4, 5);
            Vector3 newSpawnPosition = new(randomXPos, transform.position.y, transform.position.z);

            Instantiate(powerup, newSpawnPosition, Quaternion.identity, transform);
            yield return new WaitForSeconds(GetRandomSpawnTime());
        }
    }

    float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(timeBetweenSpawns - spawnTimeVariance,
            timeBetweenSpawns + spawnTimeVariance);
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }
}
