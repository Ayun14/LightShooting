using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundOptions : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Slider bgmSlider;
    public Slider sfxSlider;

    // º¼·ý Á¶Àý
    public void SetBgmVolme()
    {
        audioMixer.SetFloat("BGM", Mathf.Log10(bgmSlider.value) * 20);
    }

    public void SetSFXVolme()
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(sfxSlider.value) * 20);
    }
}
