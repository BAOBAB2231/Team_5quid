using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 아이템의 종류를 정의하는 열거형
public enum ItemType
{
    Effect,      // 효과 아이템
    Buff,        // 버프 아이템
    Resource     // 자원 아이템 (코인)
}

// 효과 아이템의 타입 정의
public enum EffectType
{
    Magnet,      // 자석
    PowerUp,       // 파워 -> 오브젝트를 파괴하면서 전진
    SuperJump    // 슈퍼 점프 -> 상단의 다른 맵으로 이동해서 보너스 코인과 아이템 획득
}

[Serializable]
public class ItemDataEffect
{
    public EffectType type;     // 효과 타입
    public float duration;      // 지속 시간
    public float strength;      // 효과 강도 
}

// 버프 아이템의 타입 정의
public enum BuffType
{
    ScoringUp,   // 점수 배율 업
    JumpForceUp,   // 점프 부스트
    CoinVolumeUp // 코인 획득 업 
}

// 버프 아이템의 상세 정보 (효과 종류 및 수치)
[Serializable]
public class ItemDataBuff
{
    public BuffType type;  // 버프 종류
    public float duration;   // 버프 지속 시간
    public float multiplier; // 버프 효과 배율 (예: 1.5배)
}

/// <summary>
/// 인벤토리 아이템의 데이터 정의 ScriptableObject
/// </summary>
[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string displayName;         // 아이템 이름
    public string description;         // 아이템 설명
    public ItemType type;              // 아이템 분류

    [Header("Stacking")]
    public bool canStack;              // 여러 개 쌓을 수 있는지 여부
    public int maxStackAmount;         // 최대 스택 수

    [Header("Buff")]
    public ItemDataBuff[] Buffs;        // 버프 아이템 효과들

    [Header("Effect")]
    public ItemDataEffect[] Effects;  // 효과 아이템 효과들
}
