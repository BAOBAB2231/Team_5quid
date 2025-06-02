using UnityEngine;
using UnityEngine.UI;

public class SettingBoard : UIBase
{
    [SerializeField] private Slider bgmVolumeController;
    [SerializeField] private Slider effectVolumeController;

    private void Update()
    {
        SoundManager.Instance.BgmVolume = bgmVolumeController.value;
        SoundManager.Instance.EffectVolume = effectVolumeController.value;
    }
}
