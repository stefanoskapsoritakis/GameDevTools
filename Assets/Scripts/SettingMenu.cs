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
    public Toggle fullScreenToggle;
    public Dropdown resolutionDropdown;
    public Resolution currentResolution;
    
    
    public Slider volumeSlider;

    public AudioSource audioSrc;
    public GameSettings gameSettings;
    public void OnEnable()
    {
        gameSettings = new GameSettings();
        resolutions = Screen.resolutions;
        currentResolution = Screen.currentResolution;
        gameSettings.currentVolume = volumeSlider.value;
        gameSettings.currentFullScreen = fullScreenToggle.isOn;
        fullScreenToggle.onValueChanged.AddListener(delegate { OnFullScreenChange(); });
        
        resolutionDropdown.onValueChanged.AddListener(delegate { OnResolutionChange(); });
        volumeSlider.onValueChanged.AddListener(delegate { OnVolumeChange(); });
        resolutions = Screen.resolutions;
        resolutionDropdown.options.Add(new Dropdown.OptionData(currentResolution.ToString()));
        foreach (Resolution resolution in resolutions)
        {
            resolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }
        
    }
    public void OnResolutionChange()
    {
        Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, Screen.fullScreen);
    }
    
    public void OnVolumeChange()
    {
        audioSrc.volume =gameSettings.musicVolume = volumeSlider.value;
        Debug.Log(volumeSlider.value);
    }  
    public void OnFullScreenChange()
    {
        Screen.fullScreen = fullScreenToggle.isOn;
        gameSettings.fullScreen = fullScreenToggle.isOn;
    }
    public void OnApplyButtonClick()
    {
        gameSettings.isApply = true;
        currentResolution = Screen.currentResolution;
        gameSettings.currentVolume = volumeSlider.value;
        gameSettings.currentFullScreen = fullScreenToggle.isOn;
    }
    public void OnCancelButtonClick()
    {
        gameSettings.isApply = false;
        Screen.SetResolution(currentResolution.width, currentResolution.height, Screen.fullScreen);        
        audioSrc.volume = gameSettings.currentVolume;
        volumeSlider.value = gameSettings.currentVolume;
        Screen.fullScreen = gameSettings.currentFullScreen;
        fullScreenToggle.isOn = gameSettings.currentFullScreen;
    }
}
