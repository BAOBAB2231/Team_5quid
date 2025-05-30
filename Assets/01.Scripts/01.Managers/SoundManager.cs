using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
   private static SoundManager instance;

    //Volume 범위 제한
    [SerializeField][Range(0f, 1f)] private float bgmVolume;
    [SerializeField][Range(0f, 1f)] private float effectVolume;

    //bgmVolume 프로퍼티화
    public float BgmVolume
    {
        get => bgmVolume;
        set => bgmVolume = value;
    }

    //effectVolume 프로퍼티화
    public float EffectVolume
    {
        get => effectVolume;
        set => effectVolume = value;
    }

    public static SoundManager Instance {get {return instance;}}
    void Awake()
    {
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
}
