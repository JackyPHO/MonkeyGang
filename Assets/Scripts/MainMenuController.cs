using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour

{
    public CanvasGroup SettingsPanel;
    public CanvasGroup CreditsPanel;

    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Settings()
    {
        SettingsPanel.alpha = 1;
        SettingsPanel.blocksRaycasts = true;
    }

    public void Credits()
    {
        CreditsPanel.alpha = 2;
        CreditsPanel.blocksRaycasts = true;
    }

    public void Back()
    {
        SettingsPanel.alpha = 0;
        SettingsPanel.blocksRaycasts = false;
        CreditsPanel.alpha = 0;
        CreditsPanel.blocksRaycasts = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

