using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class volumeLoader : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    private const string VolumePrefKey = "MusicVolume";
    private async void LoadVolumeSettings()
    {
        // Load the saved volume, if any
        if (PlayerPrefs.HasKey(VolumePrefKey))
        {
            float savedVolume = PlayerPrefs.GetFloat(VolumePrefKey);
            musicSource.volume = savedVolume;
        }
        else
        {
            // If no saved volume, set to max by default
            musicSource.volume = 1.0f;
        }

   
    }

    private void Awake()
    {
        LoadVolumeSettings();
    }
}
