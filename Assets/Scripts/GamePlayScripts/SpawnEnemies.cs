using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject[] enemyPrefab;
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
        Vector3 spawnPos = new Vector3(spawnPosX, 0, Random.Range(-spawnPosZ, spawnPosZ));
        int enemyPref = Random.Range(0, enemyPrefab.Length);

        Instantiate(enemyPrefab[enemyPref], spawnPos, enemyPrefab[enemyPref].transform.rotation);
    }
}
