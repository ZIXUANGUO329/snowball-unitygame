
using UnityEngine;
using System.Collections;
public class PickupSpawner : MonoBehaviour
{
    [Header("Pickup Settings Prefabs")]
    public GameObject snowflakePrefab;
    public GameObject skiPolePrefab;

    [Header("Lane Distance Settings")]
    public float laneDistance = 4.5f;

    [Header("Generation Settings")]
    public float spawnZ = 40f;
    public float minInterval = 0.8f;
    public float maxInterval = 1f;

    [Header("Ski Pole Chance Settings")]
    [UnityEngine.Range(0f, 1f)]
    public float skiPoleChance = 0.15f; // Chance to spawn a ski pole instead of a snowflake
    void Start()
    {
        StartCoroutine(SpawnLoop());
        
    }
    IEnumerator SpawnLoop()
    {
        while (true)
        {
            float waitTime = Random.Range(minInterval, maxInterval);
            yield return new WaitForSeconds(waitTime);

            if (!GameManager.Instance.isGameOver)
            {
                SpawnPickup();
            }
        }
    }
    private void SpawnPickup()
    {
        int lane = Random.Range(0 , 3);
        float x = (lane - 1) * laneDistance;

        GameObject prefabToSpawn = (Random.value < skiPoleChance) ? skiPolePrefab : snowflakePrefab;

        float y = prefabToSpawn.transform .position.y;
        Vector3 spawnPosition = new Vector3(x, y, spawnZ);
        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
    }
}
