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
        // 게임이 진행 중일 때만 버프 적용
        if (GameManager.Instance.gameState != GameState.Playing)
        {
            return;
        }

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

        // GameManager에서 직접 플레이어를 가져와 버프 적용
        Player targetPlayer = GameManager.Instance.Player;
      
        if (targetPlayer != null)
        {
          GameManager.Instance.Player.ApplyJumpForceBuff(multiplier, duration);

        }
        
    }
}