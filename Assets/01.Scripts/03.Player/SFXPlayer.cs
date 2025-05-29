using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum SFX
{
    SideStep,
    Jump
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
}
