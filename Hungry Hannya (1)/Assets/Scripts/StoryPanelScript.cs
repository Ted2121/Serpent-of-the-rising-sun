using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryPanelScript : MonoBehaviour
{

    public GameObject storyPanel;
    public void StoryButton()
    {
        if (storyPanel != null)
        {
            bool isActive = storyPanel.activeSelf;

            storyPanel.SetActive(!isActive);


        }
    }
}