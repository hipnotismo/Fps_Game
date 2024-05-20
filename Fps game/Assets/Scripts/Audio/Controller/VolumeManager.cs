using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    [Header("Volume")]
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private string volumeName = "musicVolume";

    private void Start()
    {
        if (!PlayerPrefs.HasKey(volumeName))
        {
            PlayerPrefs.SetFloat(volumeName, 1);
            AudioListener.volume = 1;
            volumeSlider.value = 1;
        }

        else
        {
            Load();
        }
    }
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();

    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat(volumeName);
    }

    private void Save()
    {
        PlayerPrefs.SetFloat(volumeName, volumeSlider.value);
    }

   
}
