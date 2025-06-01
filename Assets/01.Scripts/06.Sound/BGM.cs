using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    // 오디오 클립
    [SerializeField] private AudioClip[] bgmClips;

    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = SoundManager.Instance.audioSource;
    }

    //랜덤 선택 후 플레이동안 반복 재생
    public void PlayRandomBGM()
    {
        int index = Random.Range(0, bgmClips.Length);
        _audioSource.clip = bgmClips[index];
        _audioSource.loop = true;
        _audioSource.Play();
    }

    //BGM 볼륨 증가 감지시 반영
    private void OnEnable()
    {
        SoundManager.OnBgmVolumeChanged += ApplyVolume;
    }

    //BGM 볼륨 감소 감지시 반영
    private void OnDisable()
    {
        SoundManager.OnBgmVolumeChanged -= ApplyVolume;
    }

    private void ApplyVolume(float volume)
    {
        _audioSource.volume = volume;
    }
}
