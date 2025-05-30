using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public AudioSource audioSource;

    //Volume 범위 제한
    [SerializeField][Range(0f, 0.6f)] private float bgmVolume;
    [SerializeField][Range(0f, 1f)] private float effectVolume;

    public static event Action<float> OnBgmVolumeChanged;
    public static event Action<float> OnEffectVolumeChanged;

    //bgmVolume 프로퍼티화
    public float BgmVolume
    {
        get => bgmVolume;
        set
        {
            bgmVolume = value;
            OnBgmVolumeChanged?.Invoke(bgmVolume);
        }
    }

    //effectVolume 프로퍼티화
    public float EffectVolume
    {
        get => effectVolume;
        set
        {
            effectVolume = value;
        }

    }

    private void Start()
    {
        audioSource.volume = 0.2f;
        effectVolume = 0.75f;
    }
}
