using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void OpenOptions()
    {
        // Replace "Options" with the name of your options scene
        SceneManager.LoadScene("Options");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void GoBack()
    {
        SceneManager.LoadScene("Menu");
    }
}
