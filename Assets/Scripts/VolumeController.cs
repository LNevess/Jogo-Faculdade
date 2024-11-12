using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private AudioSource musicSource;
    private const string VolumePrefKey = "MusicVolume";

    private void Awake()
    {
        // Ensure the AudioSource is set
        if (musicSource == null)
        {
            musicSource = GetComponent<AudioSource>();
        }

        // Load saved volume settings
        LoadVolumeSettings();

        // Subscribe to the slider value change event
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    private void OnDestroy()
    {
        // Unsubscribe from the slider value change event
        volumeSlider.onValueChanged.RemoveListener(SetVolume);
    }

    private void LoadVolumeSettings()
    {
        // Load the saved volume, if any
        if (PlayerPrefs.HasKey(VolumePrefKey))
        {
            float savedVolume = PlayerPrefs.GetFloat(VolumePrefKey);
            volumeSlider.value = savedVolume;
            musicSource.volume = savedVolume;
        }
        else
        {
            // If no saved volume, set to max by default
            volumeSlider.value = 1.0f;
            musicSource.volume = 1.0f;
        }
    }

    public void SetVolume(float volume)
    {
        musicSource.volume = volume;
        SaveVolumeSettings(volume);
    }

    private void SaveVolumeSettings(float volume)
    {
        // Save the volume setting
        PlayerPrefs.SetFloat(VolumePrefKey, volume);
        PlayerPrefs.Save();
    }
}
