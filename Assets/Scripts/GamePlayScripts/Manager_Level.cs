using UnityEngine;
using UnityEngine.SceneManagement;



public class Manager_Level : MonoBehaviour
{
    public int life;

    public GameObject heartA;
    public GameObject heartB;
    public GameObject heartC;

    public GameObject panelIntructions;
    public GameObject panelInGame;
    public GameObject panelGameOver;

    void Start()
    {
        Time.timeScale = 0;
        panelIntructions.SetActive(true);
        panelGameOver.SetActive(false);
        panelInGame.SetActive(true);

        life = 3;

        heartA.SetActive(true);
        heartB.SetActive(true);
        heartC.SetActive(true);
    }

    private void Update()
    {
        HeartsActive();
        if (life <= 0)
        {
            panelInGame.SetActive(false);
            panelGameOver.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Damage()
    {
        life -= 1;
    }
    public void Healp()
    {
        life += 1;
    }

    void HeartsActive()
    {
        if (life == 3)
        {
            heartA.SetActive(true);
            heartB.SetActive(true);
            heartC.SetActive(true);

        }
        else if (life == 2)
        {
            heartA.SetActive(true);
            heartB.SetActive(true);
            heartC.SetActive(false);

        }
        else if (life == 1)
        {
            heartA.SetActive(true);
            heartB.SetActive(false);
            heartC.SetActive(false);

        }

        else if (life <= 0)
        {
            heartA.SetActive(false);
            heartB.SetActive(false);
            heartC.SetActive(false);

        }
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene("Level_01");
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        panelIntructions.SetActive(false);

    }
}
