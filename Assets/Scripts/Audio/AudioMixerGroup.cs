using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class AudioMixerController : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Slider musicSlider;
    public Slider effectsSlider;
    public Slider otherSlider;

    private const float MinVolume = 0.0001f;
    private const float MaxVolume = 1f;
    private const float DecibelMultiplier = 20f;

    private void Start()
    {
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        effectsSlider.onValueChanged.AddListener(SetEffectsVolume);
        otherSlider.onValueChanged.AddListener(SetOthereVolume);
    }

    private void SetMusicVolume(float volume)
    {
        float clampedVolume = Mathf.Clamp(volume, MinVolume, MaxVolume);
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(clampedVolume) * DecibelMultiplier);
    }

    private void SetEffectsVolume(float volume)
    {
        float clampedVolume = Mathf.Clamp(volume, MinVolume, MaxVolume);
        audioMixer.SetFloat("EffectsVolume", Mathf.Log10(clampedVolume) * DecibelMultiplier);
    }

    private void SetOthereVolume(float volume)
    {
        float clampedVolume = Mathf.Clamp(volume, MinVolume, MaxVolume);
        audioMixer.SetFloat("OtherVolume", Mathf.Log10(clampedVolume) * DecibelMultiplier);
    }
}
