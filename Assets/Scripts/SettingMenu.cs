using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.IO;

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
        resolutions = Screen.resolutions;
        foreach(Resolution resolution in resolutions)
        {
            resolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }
    }
    public void OnResolutionChange()
    {
        Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, Screen.fullScreen);
    }
    public void OnQualityChange()
    {
        QualitySettings.SetQualityLevel(qualityDropdown.value);
        Debug.Log(QualitySettings.GetQualityLevel());
        gameSettings.textureQuality = qualityDropdown.value;

        
    }
    public void OnVolumeChange()
    {
        audioSrc.volume =gameSettings.musicVolume = volumeSlider.value;
        Debug.Log(volumeSlider.value);
    }  
    
}
