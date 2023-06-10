using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundOptions : MonoBehaviour
{
    public AudioSource[] audioSource;

    public Slider bgmSlider;
    public Slider sfxSlider;

    // º¼·ý Á¶Àý
    public void SetBgmVolme()
    {
        audioSource[0].volume = bgmSlider.value;
    }

    public void SetSFXVolme()
    {
        audioSource[1].volume = sfxSlider.value;
    }
}
