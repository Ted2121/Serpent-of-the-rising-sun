using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    GameObject Panel;
    GameObject storyPanel;
    public void MainStartButton()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void SettingsSetVolume ()
    {
        FindObjectOfType<SettingsToSave>().FindSliderValue();
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void SettingsButton()
    {
        if (Panel != null)
        {
            bool isActive = Panel.activeSelf;

            Panel.SetActive(!isActive);
           // Debug.Log(Panel.activeSelf);
        }
    }

    public void StoryButton()
    {
        if (storyPanel != null)
        {
            bool isActive = storyPanel.activeSelf;

            storyPanel.SetActive(!isActive);
            // Debug.Log(Panel.activeSelf);
        }
    }
}
