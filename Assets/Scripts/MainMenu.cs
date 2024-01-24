using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void SkipToLevel2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void SkipToLevel3()
    {
        SceneManager.LoadScene("Level3");
    }

    public void SkipToLevel4()
    {
        SceneManager.LoadScene("Level4");
    }

    public void SkipToEind()
    {
        SceneManager.LoadScene("Eind");
    }

    public void OpenOptions()
    {
        // Replace "Options" with the name of your options scene
        SceneManager.LoadScene("Tutorial");
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
