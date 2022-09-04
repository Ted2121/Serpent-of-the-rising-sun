using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsScript : MonoBehaviour
{
public AudioMixer audioMixer;

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetFullScreen()
    {

        bool isFullScreen = Screen.fullScreen;
        if (!isFullScreen)
        { Screen.fullScreen = true; }
        else
        { Screen.fullScreen = false; }
       // Debug.Log(Screen.fullScreenMode);
    }
}
