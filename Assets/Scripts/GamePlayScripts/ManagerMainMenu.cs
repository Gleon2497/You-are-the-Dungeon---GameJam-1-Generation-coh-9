using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerMainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Level_01");
    }
}
