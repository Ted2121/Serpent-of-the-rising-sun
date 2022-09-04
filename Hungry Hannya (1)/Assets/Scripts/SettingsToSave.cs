using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsToSave : MonoBehaviour
{
    static SettingsToSave instance;
    public float globalVolume;

    private void Awake()
    {
        float globalVolume = .5f;
        // Checking whether or not this object is a duplicate.
        // Destroys itself if it is
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void FindSliderValue ()
    {
        globalVolume = FindObjectOfType<Slider>().value;
    }

    public void SetGlobalVolume ()
    {
        AudioSource[] aSources;
        aSources = FindObjectsOfType<AudioSource>();
        for (int i = 0; i < aSources.Length; i++)
        {
            aSources[i].volume = globalVolume;
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        SetGlobalVolume();
    }
}
