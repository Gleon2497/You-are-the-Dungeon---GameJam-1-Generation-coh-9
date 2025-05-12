using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private Rigidbody enemyRb;
    private int enemyLife = 10;
    bool enemyIsOnVoid; //void es la region central, significa que llego al centro y afecta salud del dragon


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        enemyIsOnVoid = false;
        SetEnemyLife(enemyLife);
    }

    /// </summary>  
    /// metodo que inicializa la vida del enemigo
    /// </summary> 
    public void SetEnemyLife(int enemyLifenew)
    {
        enemyLife = enemyLifenew;
    }

    // Update is called once per frame
    void Update()
    {
        CheckLifeStatus();
    }

    /// </summary>  
    /// metodo que revisa la vida del enemigo para apagarlo
    /// </summary> 
    void CheckLifeStatus()
    {
        if (enemyLife < 0)
        {
            enemyRb.gameObject.SetActive(false);
        }
    }

   
    /// </summary>  
    /// Metodo que revisa si esta en zona mala y resta vida enemigo
    /// </summary>  
    private void OnCollisionStay(Collision collision)
    {
        
        if (collision.gameObject.tag == "Bad")
        {
            enemyLife--;
            Debug.Log(enemyLife);
        }
    }

    /// </summary>  
    /// Metodo que revisa si esta en void
    /// </summary>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Void")
        {
            enemyRb.gameObject.SetActive(false);
            enemyIsOnVoid = true;
        }
    }

}
