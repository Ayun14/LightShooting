using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BGMType { Stage = 0, Boss}

public class BGMController : MonoBehaviour
{
    [SerializeField] private AudioClip[] bgmClips;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = transform.GetChild(0).GetComponent<AudioSource>();
    }

    public void ChangeBGM(BGMType index)
    {
        audioSource.Stop();

        audioSource.clip = bgmClips[(int)index];
        audioSource.Play();
    }
}
