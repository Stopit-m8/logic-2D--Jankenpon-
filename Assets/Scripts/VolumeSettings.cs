using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider SFXSlider;


    private void Awake()
    {
        musicSlider = GameObject.Find("BGMVolumeSlider").GetComponent<Slider>();
        masterSlider = GameObject.Find("MasterVolumeSlider").GetComponent<Slider>();
        SFXSlider = GameObject.Find("SFXVolumeSlider").GetComponent<Slider>();
    }
    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume") && PlayerPrefs.HasKey("masterVolume") && PlayerPrefs.HasKey("SFXVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
            SetMasterVolume();
            SetSFXVolume();
        }
    }

    public void SetMusicVolume()
    {
        float musicVolume = musicSlider.value;
        audioMixer.SetFloat("Music", MathF.Log10(musicVolume)*20);
        PlayerPrefs.SetFloat("musicVolume", musicVolume);
    }
    public void SetMasterVolume()
    {
        float masterVolume = masterSlider.value;
        audioMixer.SetFloat("Master", MathF.Log10(masterVolume)*20);
        PlayerPrefs.SetFloat("masterVolume", masterVolume);
    }
    public void SetSFXVolume()
    {
        float SFXVolume = SFXSlider.value;
        audioMixer.SetFloat("SFX", MathF.Log10(SFXVolume)*20);
        PlayerPrefs.SetFloat("SFXVolume", SFXVolume);
    }

    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SetMusicVolume();
        masterSlider.value = PlayerPrefs.GetFloat("masterVolume");
        SetMasterVolume();
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        SetSFXVolume();
    }
}
