using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpener : MonoBehaviour
{

    public GameObject panel;
    public void SettingsButton()
    {
        if (panel != null)
        {
            bool isActive = panel.activeSelf;

            panel.SetActive(!isActive); 
        }
    }

    public void ClosePanel ()
    {
        panel.SetActive(false);
    }

   
}
