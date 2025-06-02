using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        bgm = GetComponent<BGM>();

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
    private BGM bgm;

    //Volume 범위 제한
    [SerializeField][Range(0f, 0.6f)] private float bgmVolume;
    [SerializeField][Range(0f, 1f)] private float effectVolume;

    //볼륨 변화를 감지하는 이벤트 함수
    public static event Action<float> OnBgmVolumeChanged;
    public static event Action<float> OnEffectVolumeChanged;

    //bgmVolume 프로퍼티화
    public float BgmVolume
    {
        get => bgmVolume;
        set
        {
            bgmVolume = value;
            //BGM 볼륨 변화를 감지시 작동
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
            //Effect 볼륨 변화를 감지시 작동
            OnEffectVolumeChanged?.Invoke(effectVolume);
        }

    }

    private void Start()
    {
        audioSource.volume = 0.05f;
        effectVolume = 0.75f;
        PlayBGM();
    }

    public void PlayBGM()
    {
        bgm.PlayRandomBGM();
    }
}
