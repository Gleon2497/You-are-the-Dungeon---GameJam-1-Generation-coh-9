using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform centerPoint;
    public float speed = 5f;
    public AudioClip enemyOnVoidSound;

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
}
