using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        InitializeSelectedLevel();
    }

    private void InitializeSelectedLevel()
    {
        int defaultLevelIndex = 0; // Set your default level index here

        if (PlayerPrefs.HasKey("SelectedLevel"))
        {
            int selectedLevelIndex = PlayerPrefs.GetInt("SelectedLevel");
            PersistentManager.selectedLevelIndex = selectedLevelIndex;
        }
        else
        {
            Debug.Log("No SelectedLevel key found in PlayerPrefs. Using default level.");

            // Set the default level index
            PersistentManager.selectedLevelIndex = defaultLevelIndex;
        }
    }

    public void OnPlayButton()
    {
        LoadSelectedLevel();
    }

    private void LoadSelectedLevel()
    {
        int selectedLevelIndex = PersistentManager.selectedLevelIndex;
        string selectedLevelName = "Level" + (selectedLevelIndex + 1);

        // Log information for debugging
        Debug.Log($"Selected Level Index: {selectedLevelIndex}");
        Debug.Log($"Selected Level Name: {selectedLevelName}");

        SceneManager.LoadScene(selectedLevelName);
    }

    public void OnOptionsButton()
    {
        SceneManager.LoadScene("Options");
    }

    public void OnMenuButton()
    {
        SceneManager.LoadScene("Menu");
    }

    public void OnExitButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
