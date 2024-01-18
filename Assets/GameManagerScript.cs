using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;
    public TMP_Text pointText;
    public CoinManager coinManager;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void gameOver()
    {
        gameOverUI.SetActive(true);
        pointText.text = coinManager.coinCount.ToString() + " Studiepunten";

    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void mainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
