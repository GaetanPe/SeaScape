using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsMenu;


    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void SettingsMenu()
    {
        settingsMenu.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
