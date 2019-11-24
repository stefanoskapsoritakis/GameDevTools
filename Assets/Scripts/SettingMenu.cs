using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class SettingMenu : MonoBehaviour
{
    // Start is called before the first frame update
     public Resolution[] resolutions;

    public Dropdown resolutionDropdown;
    public Dropdown qualityDropdown;
    
    public Slider volumeSlider;

    public AudioSource audioSrc;
    public GameSettings gameSettings;
    void OnEnable()
    {
        gameSettings = new GameSettings();
        resolutions = Screen.resolutions;
        qualityDropdown.onValueChanged.AddListener(delegate { OnQualityChange(); });
        resolutionDropdown.onValueChanged.AddListener(delegate { OnResolutionChange(); });
        volumeSlider.onValueChanged.AddListener(delegate { OnVolumeChange(); });
    }
    public void OnResolutionChange()
    {

    }
    public void OnQualityChange()
    {
        QualitySettings.masterTextureLimit = gameSettings.textureQuality = qualityDropdown.value;

        Debug.Log(QualitySettings.masterTextureLimit.ToString());
    }
    public void OnVolumeChange()
    {
        audioSrc.volume =gameSettings.musicVolume = volumeSlider.value;
        Debug.Log(volumeSlider.value);
    }  
}
