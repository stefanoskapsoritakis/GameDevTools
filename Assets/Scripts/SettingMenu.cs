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

    public AudioMixer audioMixer;
    public void SetVolume ()
    {
        float sliderValue = volumeSlider.value;
        Debug.Log(sliderValue);
        audioMixer.SetFloat("Volume", sliderValue);
    }
    public void SetQuality()
    {
        int qualityIndex = qualityDropdown.value;
        Debug.Log(qualityIndex);
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SetResolution()
    {
        int resolutionIndex = resolutionDropdown.value;
        Debug.Log(resolutionIndex);
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    private void Start()
    {
        qualityDropdown.onValueChanged.AddListener(delegate { SetQuality(); });
        resolutionDropdown.onValueChanged.AddListener(delegate { SetResolution(); });
        resolutions = Screen.resolutions;
        foreach(Resolution resolution in resolutions)
        {
            resolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }
    }
}
