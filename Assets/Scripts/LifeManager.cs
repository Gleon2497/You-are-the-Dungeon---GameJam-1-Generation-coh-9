using UnityEngine;

public class LifeManager : MonoBehaviour
{
    private Rigidbody lifeRb;
    bool lifeIsOnVoid; //void es la region central, significa que llego al centro y da vida al dragon

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lifeRb = GetComponent<Rigidbody>();
        lifeIsOnVoid = false;
    }

    /// </summary>  
    /// Metodo que revisa si esta en void
    /// </summary>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Void")
        {
            lifeRb.gameObject.SetActive(false);
            lifeIsOnVoid = true;
        }
    }


}
