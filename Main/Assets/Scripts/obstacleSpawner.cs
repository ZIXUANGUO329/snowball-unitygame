using System.Collections;
using UnityEngine;


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
    public float hardMinInterval = 0.3f;
    public float hardMaxInterval = 0.5f;

    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        
        while (true)
        {
            float currentMin = Mathf.Lerp(minInterval, hardMinInterval, GameManager.Instance.difficulty);
            float currentMax = Mathf.Lerp(maxInterval, hardMaxInterval, GameManager.Instance.difficulty);
            float waitTime = Random.Range(currentMin, currentMax);
            yield return new WaitForSeconds(waitTime);

            if (!GameManager.Instance.isGameOver)
            {
                SpawnRock();
            }
        }

    }
    void SpawnRock()
    {
        int lane = Random.Range(0, 3);
        float x = (lane - 1) * lanDistance;
        GameObject prefabToSpawn = (Random.value < 0.5f) ? lowRockPrefab : tallRockPrefab;

        Vector3 spawnPositon = new Vector3(x, prefabToSpawn.transform.position.y, spawnZ);
        Instantiate(prefabToSpawn, spawnPositon, Quaternion.identity);

    }
}