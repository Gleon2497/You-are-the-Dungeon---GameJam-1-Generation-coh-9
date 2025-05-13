using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform centerPoint;
    public float speed = 5f;
    public AudioClip enemyOnVoidSound;
    
    public int life;
    private float damageTimer = 0f;
    public float damageInterval = 1f; // Daño cada x segundo
    public int damagePerInterval = 1;


    private Manager_Level managerLv;

    void Start()
    {
        centerPoint = GameObject.Find("CenterPoint").GetComponent<Transform>();
        managerLv = GameObject.Find("GameManager").GetComponent<Manager_Level>();
    }

    void Update()
    {
        MoveToPointCenter();
    }
    // metodo que genera en movimiento automatico hacia en centro
    private void MoveToPointCenter()
    {
        Vector3 lookDirection = (centerPoint.position - transform.position).normalized;
        transform.Translate(lookDirection * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CenterPoint"))
        {
            Destroy(gameObject);
            managerLv.Damage();
            AudioManager.Instance.PlaySFX(enemyOnVoidSound);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("DamageZone"))
        {
            damageTimer += Time.deltaTime;

            if (damageTimer >= damageInterval)
            {
                life -= damagePerInterval;
                damageTimer = 0f; // Reiniciar el temporizador

                if (life <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("DamageZone"))
        {
            damageTimer = 0f; // Reiniciar al salir de la zona
        }
    }
}
