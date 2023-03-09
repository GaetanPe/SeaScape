using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    void Start()
    {
        pausePanel.SetActive(false);
    }

    private void LateUpdate()
    {
        if (pausePanel == true)
        {
            if(Input.GetKeyDown(KeyCode.Escape)) 
            {
                pausePanel.SetActive(false);
                Time.timeScale = 1.0f;
            }
        }
    }
    public void ButtonPause()
    {        
        pausePanel.SetActive(true);
        Time.timeScale = 0f;

    }

    public void closeWindow()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void MenuScene()
    {
        closeWindow();
        SceneManager.LoadScene("Menu");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        pausePanel.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
