using UnityEngine;

public class SpawnFriend : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnPosX;
    public float spawnPosZ;
    public float startDelay;
    public float repeatRate;
    void Start()
    {
        InvokeRepeating("SpawnPrefabEnemies", startDelay, repeatRate);
    }

    void SpawnPrefabEnemies()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnPosX, spawnPosX), 0, spawnPosZ);
        
        Instantiate(enemyPrefab, spawnPos, enemyPrefab.transform.rotation);
    }
}
