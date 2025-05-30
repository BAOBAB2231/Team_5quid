using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 점프력 증가 버프 아이템
/// </summary>
public class jumpForceUp : BuffItem
{
    /// <summary>
    /// 플레이어에게 점프력 증가 버프를 적용합니다.
    /// </summary>
    /// <param name="player">버프를 적용할 대상 플레이어</param>
    /// <param name="itemData">아이템 버프 데이터</param>
    public override void ApplyBuff(Player player, ItemData itemData)
    {
        base.ApplyBuff(player, itemData);

        float duration = 0f;
        float multiplier = 1f;

        foreach (ItemDataBuff buff in itemData.Buffs)
        {
            if (buff.type == BuffType.JumpForceUp)
            {
                duration = buff.duration;
                multiplier = buff.multiplier;
                break;
            }
        }

        // Player 클래스의 점프력 버프 메서드 호출
        player.ApplyJumpForceBuff(multiplier, duration);

        Debug.Log($"[jumpForceUp] 점프력 {multiplier}배 증가 효과 적용 ({duration}초간)");
    }
}
