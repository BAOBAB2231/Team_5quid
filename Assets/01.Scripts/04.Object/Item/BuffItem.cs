using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffItem : MonoBehaviour
{
    /// <summary>
    /// 버프 아이템의 효과를 플레이어에게 적용
    /// </summary>
    /// <param name="player">점프 강화 등 컨트롤 관련 효과를 적용할 플레이어</param>
    /// <param name="point">코인 수량, 점수의 포인트를 적용할 컴포넌트</param>
    /// <param name="data">적용할 아이템 데이터</param>
    //public static void Apply(PlayerController player, ItemData data, Point point)
    //{
    //    // 소비형 아이템이 아니거나, 소비 효과 정보가 없으면 처리 중단
    //    if (data.type != ItemType.Buff || data.Buff == null)
    //        return;

    //    // 각 버프 효과를 순회하면서 적용
    //    foreach (var buff in data.Buff)
    //    {
    //        switch (buff.type)
    //        {
    //            case BuffType.JumpBoost:
    //                // 점프 강화 효과 적용 (지속 시간 기반)
    //                player?.ApplyJumpBoost(buff.value);
    //                break;

    //            case BuffType.ScoringUp:
    //                // 스코어 버프 효과 적용
    //                point?.ApplyScoringUp(buff.value);
    //                break;

    //            case BuffType.CoinVolumeUp:
    //                // 코인 버프 효과 적용
    //                point?.ApplyCoinVolumeUp(buff.value);
    //                break;
    //        }
    //    }
    //}
}
