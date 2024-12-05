using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    // for death menu
    public void restartGame()
    {
        clearPlayerPrefs();
        SceneManager.LoadScene("PirateCampsLVL1"); 
    }

    public void loadMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); 
    }

    public void quitGame()
    {
        Application.Quit();
    }

    // main menu
    public void startGame()
    {
        clearPlayerPrefs();
        SceneManager.LoadScene("PirateCampsLVL1");
    }

    public void loadOptions()
    {
        SceneManager.LoadScene("Options");
    }

    public void clearPlayerPrefs()
    {
        PlayerPrefs.DeleteKey("PlayerHealth"); 
        PlayerPrefs.Save();
    }

}
