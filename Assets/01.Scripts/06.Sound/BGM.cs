using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    // 오디오 클립
    [SerializeField] private AudioClip[] bgmClips;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        PlayRandomBGM();
    }

    //랜덤 선택 후 플레이동안 반복 재생
    void PlayRandomBGM()
    {
        int index = Random.Range(0, bgmClips.Length);
        audioSource.clip = bgmClips[index];
        audioSource.loop = true;
        audioSource.Play();
    }

    private void OnEnable()
    {
        SoundManager.OnBgmVolumeChanged += ApplyVolume;
    }

    private void OnDisable()
    {
        SoundManager.OnBgmVolumeChanged -= ApplyVolume;
    }

    private void ApplyVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
