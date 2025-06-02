using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 코인 획득량을 일정 시간 동안 2배로 증가시키는 아이템
public class CoinVolumeUpBuff : BuffItem
{

    /// <summary>
    /// 플레이어에게 코인 2배 버프 효과 적용
    /// </summary>
    /// <param name="player">버프를 적용할 플레이어</param>
    /// <param name="itemData">적용할 아이템 데이터</param>
    public override void ApplyBuff(Player player, ItemData itemData)
    {
        base.ApplyBuff(player, itemData);

        foreach (ItemDataBuff buff in itemData.Buffs)
        {
            if (buff.type == BuffType.CoinVolumeUp)
            {
                Point point = player.GetComponent<Point>();
                if (point != null)
                {
                    point.StartCoroutine(point.DoubleCoinRoutine(buff.duration));
                }
                break;
            }
        }

        
    }
}