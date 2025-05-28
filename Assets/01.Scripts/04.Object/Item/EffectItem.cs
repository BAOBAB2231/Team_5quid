using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 효과 아이템의 기본 기능을 정의한 추상 클래스
public abstract class EffectItem : MonoBehaviour
{
    /// <summary>
    /// 플레이어에게 효과 적용 (자식 클래스에서 구체화)
    /// </summary>
    /// <param name="player">효과를 적용할 대상 플레이어</param>
    public abstract void ApplyEffect(PlayerController player, EffectType effect);

}
