using UnityEngine;


public class Manager_Level : MonoBehaviour
{
    public int life;

    void Start()
    {
        life = 10;
    }

    public void Damage()
    {
        life -= 1;
    }
    public void Healp()
    {
        life += 1;
    }
}
