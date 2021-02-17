using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer mixer;

    Resolution[] resolutions;

    public Dropdown resolutionDropDown;

    public Slider[] sliders;

    public Toggle fullScreenToggle;
    public Dropdown graphicsDropDown;

    private void Awake()
    {
        
        sliders[0].onValueChanged.AddListener(SetMasterVolume);
        sliders[1].onValueChanged.AddListener(SetDialoguesVolume);
        sliders[2].onValueChanged.AddListener(SetFXVolume);
        sliders[3].onValueChanged.AddListener(SetMusicVolume);

       fullScreenToggle.onValueChanged.AddListener(SetFullScreen);
        resolutionDropDown.onValueChanged.AddListener(SetResolution);
        graphicsDropDown.onValueChanged.AddListener(ChangeGraphics);


        float value;
        mixer.GetFloat("MasterVolume", out value);
        sliders[0].value = value;
        mixer.GetFloat("DialoguesVolume", out value);
        sliders[1].value = value;
        mixer.GetFloat("FXVolume", out value);
        sliders[2].value = value;
        mixer.GetFloat("MusicVolume", out value);
        sliders[3].value = value;
    }

    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropDown.ClearOptions();

        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                resolutionDropDown.value = i;
            }
        }

        resolutionDropDown.AddOptions(options);

        resolutionDropDown.RefreshShownValue();

        graphicsDropDown.value = QualitySettings.GetQualityLevel();
    }

    public void SetResolution(int resolutionIndex)
    {
        Screen.SetResolution(resolutions[resolutionIndex].width, resolutions[resolutionIndex].height, Screen.fullScreen);
    }

    public void ChangeGraphics(int quality)
    {
        QualitySettings.SetQualityLevel(quality);
    }

    public void SetMasterVolume(float volume)
    {
        mixer.SetFloat("MasterVolume", volume); 
    }

    public void SetMusicVolume(float volume)
    {
        mixer.SetFloat("MusicVolume", volume);
    }

    public void SetFXVolume(float volume)
    {
        mixer.SetFloat("FXVolume", volume);
    }

    public void SetDialoguesVolume(float volume)
    {
        mixer.SetFloat("DialoguesVolume", volume);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
