using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
  //1public GameObject obstPrefab;
    public GameObject[] obstPrefab;
    [SerializeField] private List<GameObject> pooledObject = new List<GameObject>();
    public int sizePool = 4;
    private Vector3 spawnPosition = new Vector3(25, 0, 0);
    private float startDelay = 2;
    private float repeatRate = 2;
   // private PlayerControllerCity playerControllerCity;
    private GameObject objtemp;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       // playerControllerCity = GameObject.Find("Player").GetComponent<PlayerControllerCity>();
        AddToPool(sizePool);
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// </summary> 
    /// Método para adicionar un objeto a la piscina 
    /// </summary> 
    void AddToPool(int poolSize)
    {
        for (int i = 0; i < poolSize; i++)
        {
            int randomIndex = Random.Range(0, obstPrefab.Length);
            GameObject prefabPool;
            objtemp = obstPrefab[randomIndex];
            prefabPool = Instantiate(objtemp, Vector3.zero, Quaternion.identity);
            prefabPool.SetActive(false);
            pooledObject.Add(prefabPool);
        }
    }

    /// </summary> 
    /// Función que retorna el objeto disponible para su uso 
    /// </summary> 
    public GameObject FirstDesactivate()
    {
        for (int i = 0; i < pooledObject.Count; i++)
        {
            if (!pooledObject[i].activeInHierarchy)
            {
                return pooledObject[i];
            }
        }
        AddToPool(1);
        return pooledObject.Last<GameObject>();
    }
    //void SpawnObstacle()
    //{
    //    if (playerControllerCity.gameOver == false)
    //    {
    //        GameObject temporal = FirstDesactivate();
    //        temporal.transform.position = spawnPosition;
    //        temporal.SetActive(true);
    //    }
    //}

}


