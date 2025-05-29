using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 코인 획득량을 일정 시간 동안 2배로 증가시키는 아이템
public class CoinVolumeUpBuff : BuffItem
{
    [Header("버프 지속 시간 (초)")]
    public float defaultDuration = 10f;

    /// <summary>
    /// 플레이어에게 코인 2배 버프 효과 적용
    /// </summary>
    /// <param name="player">버프를 적용할 플레이어</param>
    /// <param name="itemData">적용할 아이템 데이터</param>
    public override void ApplyBuff(PlayerController player, ItemData itemData)
    {
        base.ApplyBuff(player, itemData);

        // Buff 목록에서 CoinVolumeUp 타입 찾기
        float duration = defaultDuration;
        foreach (ItemDataBuff buff in itemData.Buffs)
        {
            if (buff.type == BuffType.CoinVolumeUp)
            {
                duration = buff.duration;
                break;
            }
        }

        Point point = player.GetComponent<Point>();
        if (point != null)
        {
            point.StartCoroutine(point.DoubleCoinRoutine(duration));
            Debug.Log($"[CoinVolumeUpBuff] 코인 2배 효과 적용 ({duration}초간)");
        }
        else
        {
            Debug.LogWarning("[CoinVolumeUpBuff] Point 컴포넌트를 찾을 수 없습니다.");
        }
    }
}