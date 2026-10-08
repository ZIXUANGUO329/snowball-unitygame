using UnityEngine;

public class EnvironmentSpawner : MonoBehaviour
{
    public GameObject[] environmentPrefabs;
    public float minInterval = 2f;
    public float maxInterval = 4f;
    public float spawnZ = 40f;
   

    private float timer;
    
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0f)
        {
            SpawnTree();
            timer = Random.Range(minInterval, maxInterval);
        }
    }
    
    void SpawnTree()
    {
        if (environmentPrefabs.Length == 0) return;

        GameObject prefabToSpawn = environmentPrefabs[Random.Range(0, environmentPrefabs.Length)];
        float x = prefabToSpawn.transform.position.x; // Use the prefab's original x position
        Vector3 spawnPosition = new Vector3(x, prefabToSpawn.transform.position.y, spawnZ);
        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
    }
}
