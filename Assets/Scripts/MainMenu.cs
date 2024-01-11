using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Dropdown levelDropdown; // Reference to the dropdown UI element in the Options menu

    private void Start()
    {
        // Check if the selected level is stored in player preferences
        if (PlayerPrefs.HasKey("SelectedLevel"))
        {
            int selectedLevelIndex = PlayerPrefs.GetInt("SelectedLevel");
            levelDropdown.value = selectedLevelIndex;
        }
    }

    public void OnPlayButton()
    {
        string selectedLevelName = "Level" + (levelDropdown.value + 1); // Assuming level names are Level1, Level2, ...
        SceneManager.LoadScene(selectedLevelName);
    }

    public void OnOptionsButton()
    {
        // Your options menu logic here
    }

    public void OnExitButton()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    // Method to save the selected level index when changed in the dropdown
    public void OnLevelDropdownChanged()
    {
        PlayerPrefs.SetInt("SelectedLevel", levelDropdown.value);
        PlayerPrefs.Save();
    }
}
