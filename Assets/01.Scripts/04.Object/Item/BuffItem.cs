using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 버프 아이템의 효과를 적용하는 클래스
/// </summary>
public class BuffItem : MonoBehaviour
{
    /// <summary>
    /// 플레이어에게 버프 효과 적용
    /// </summary>
    /// <param name="player">버프를 적용할 플레이어</param>
    /// <param name="buff">적용할 버프 데이터</param>
    public void ApplyBuff(PlayerController player, ItemDataBuff buff)
    {
        Debug.Log($"[BuffItem] {buff.type} 버프 적용! 지속 시간: {buff.value}초");

        switch (buff.type)
        {
            case BuffType.ScoringUp:   // 점수 배율 증가
                // 점수 관련 시스템 연동 필요
                break;

            case BuffType.JumpBoost:   // 점프력 증가
                // 점프부스트를 실행시키는 함수 추가
                break;

            case BuffType.CoinVolumeUp: // 코인 획득량 증가
                // 코인 시스템 연동 필요
                break;
        }
    }
}
