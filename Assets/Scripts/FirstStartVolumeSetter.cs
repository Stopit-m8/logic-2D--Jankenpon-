using UnityEngine;
using UnityEngine.Audio;

public class VolumeLoader : MonoBehaviour
{
    public AudioMixer audioMixer;

    private void Start()
    {
        float music = PlayerPrefs.GetFloat("musicVolume", 1f);
        float master = PlayerPrefs.GetFloat("masterVolume", 1f);
        float sfx = PlayerPrefs.GetFloat("SFXVolume", 1f);

        ApplyVolume("Music", music);
        ApplyVolume("Master", master);
        ApplyVolume("SFX", sfx);
    }

    void ApplyVolume(string mixerName, float value)
    {
        audioMixer.SetFloat(mixerName, Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * 20);
    }
}
