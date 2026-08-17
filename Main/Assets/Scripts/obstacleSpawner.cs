using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class obstacleSpawner : MonoBehaviour
{
    [Header("Obstacle Settings Prefabs")]
    public GameObject lowRockPrefab; // Prefab for low rock obstacle
    public GameObject tallRockPrefab; // Prefab for tall rock obstacle

    [Header("GameObject Settings")]
    public float lanDistance = 4.5f;// The distance between two lanes

    [Header("Spawning Settings")]
    public float spawnZ = 40f;
    public float minInterval = 1f;
    public float maxInterval = 2f;

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

            SpawnRock();
        }

    }
    void SpawnRock()
    {
        int lane = Random.Range(0, 3);
        float x = (lane - 1) * lanDistance;
        GameObject prefabToSpawn = (Random.value < 0.5f) ? lowRockPrefab : tallRockPrefab;

        Vector3 spawnPositon = new Vector3(x, 0f, spawnZ);
        Instantiate(prefabToSpawn, spawnPositon, Quaternion.identity);

    }
}