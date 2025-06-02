using System.Linq;
using UnityEngine;

public enum SFX
{
    SideStep,
    Jump,
}

public class SFXPlayer : MonoBehaviour
{
    public AudioClip [] clips;
   
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        audioSource.volume = SoundManager.Instance.EffectVolume;
    }

    public void PlayClip(SFX name)
    {
        AudioClip  clip = clips.FirstOrDefault(e=>e.name == name.ToString());
        audioSource.PlayOneShot(clip);
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    private void OnEnable()
    {
        SoundManager.OnEffectVolumeChanged += ApplyVolume;
    }

    //BGM 볼륨 감소 감지시 반영
    private void OnDisable()
    {
        SoundManager.OnEffectVolumeChanged -= ApplyVolume;
    }

    private void ApplyVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
