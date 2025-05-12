using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    public GameObject spawnEnemyPrefab;
    public GameObject spawnLifePowerUp;
    private int enemyPoolSize = 5;
    private int powerUpPoolSize = 2;
    public int enemyLife = 10;
    public Transform centerPoint;
    [SerializeField] List<GameObject> pooledEnemies = new List<GameObject>();
    [SerializeField] List<GameObject> pooledLives = new List<GameObject>();
    private float spawnRate = 6.0f;
    int numberMaxOfEnemies= 6; // cantidad maxima de enemigos que hace spawn al mismo tiempo 
    //Radios maximo y minimo de aparicion a partir de un punto fijo centerpoint
    float maxRadius  = 10f;
    float minRadius = 6.5f;


    public bool isGameActive = true;// variable que controla cuando el juego esta activo

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        numberMaxOfEnemies = enemyPoolSize + 1; 
        AddToPool(enemyPoolSize,spawnEnemyPrefab,pooledEnemies);
        AddToPool(powerUpPoolSize,spawnLifePowerUp, pooledLives);
        StartCoroutine(GenerateCircleOfEnemies()); // comienza a instanciar enemigos
        StartCoroutine(GenerateLives()); // comienza a instanciar powerup
    }

    
    /// </summary>  
    /// Método para adicionar un objeto al pool  
    /// </summary>  
    void AddToPool(int poolSize, GameObject spawnObject, List<GameObject> listToFill)
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject prefabObject;
            prefabObject = Instantiate(spawnObject, Vector3.zero, Quaternion.identity);
            prefabObject.SetActive(false);
            listToFill.Add(prefabObject);
        }
    }

    /// </summary>  
    /// Función que retorna el objeto disponible para su uso  
    /// </summary>  
    private GameObject FirstDesactivate(List<GameObject> listToSearch, GameObject spawnObject)
    {
        for (int i = 0; i < listToSearch.Count; i++)
        {  
            if (!listToSearch[i].activeInHierarchy)
            {
                return listToSearch[i];
            }
        }  
        AddToPool( 1, spawnObject, listToSearch);
        return listToSearch.Last<GameObject>();
    }

    /// </summary>  
    /// rutina que genera enemigos en un radio al azar y setea su vida en enemyLife
    /// </summary> 
    IEnumerator GenerateCircleOfEnemies() 
    {
        while (isGameActive) 
        {
            yield return new WaitForSeconds(spawnRate);
            float tempRadius = RandomRadius();
            int randomNumberEnemies = Random.Range(1, numberMaxOfEnemies);
            for (int i = 0; i < randomNumberEnemies; i++)
            {
                GameObject enemy = FirstDesactivate(pooledEnemies,spawnEnemyPrefab);
                enemy.gameObject.GetComponent<EnemyManager>().SetEnemyLife(enemyLife);
                Vector3 finalPosition = PositionInACircle(i, randomNumberEnemies,tempRadius);
                enemy.transform.position = new Vector3(centerPoint.position.x,0.2f,centerPoint.position.z) + finalPosition;
                enemy.SetActive(true);
            }
        }
    }


    IEnumerator GenerateLives()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate+2);
            float tempRadius = RandomRadius();
            GameObject life = FirstDesactivate(pooledLives, spawnLifePowerUp);
            Vector3 finalPosition = PositionInACircle(1, 1, tempRadius);
            life.transform.position = new Vector3(centerPoint.position.x, 0.2f, centerPoint.position.z) + finalPosition;
            life.SetActive(true);
        }
        
    }


    /// </summary>  
    /// funcion que retorna un radio random
    /// </summary> 
    float RandomRadius( ) 
    {
         return Random.Range(minRadius, maxRadius);
    }

    Vector3 PositionInACircle(int actualNumber ,int numberOfObjects, float radius) 
    {
        float angle = actualNumber * (360f / numberOfObjects) * Mathf.Deg2Rad;
        Vector3 finalPosition = new Vector3(Mathf.Cos(angle) * radius, 0.0f, Mathf.Sin(angle) * radius);
        return finalPosition;
    }



}
