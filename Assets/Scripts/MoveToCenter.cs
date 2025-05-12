using UnityEngine;

public class MoveToCenter : MonoBehaviour
{
    SpawnManager spawnManager;
    public float speed = 5f;
    Rigidbody objectRb;
  

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectRb = GetComponent<Rigidbody>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPointCenter();
    }

    /// </summary>  
    /// metodo que genera en movimiento automatico hacia en centro
    /// </summary>  
    private void MoveToPointCenter()
    { 
        Vector3 lookDirection = (spawnManager.centerPoint.position - transform.position).normalized;
        transform.Translate(lookDirection * speed * Time.deltaTime);
    }


}
