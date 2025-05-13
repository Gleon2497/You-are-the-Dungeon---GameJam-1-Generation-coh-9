using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerMainMenu : MonoBehaviour
{
    //public GameObject panelInstructions;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //panelInstructions.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level_01");
    }
}
