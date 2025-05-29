using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpForceUp : BuffItem
{
    [Header("버프 지속 시간 (초)")]
    public float defaultDuration = 10f;

    [Header("점프 힘 배율")]
    public float powerMultiplier = 1.5f;

    // 점프력 버프 코루틴 제어용 변수 (동시 중복 방지)
    private Coroutine jumpForceBuffCoroutine;

    /// <summary>
    /// 플레이어에게 점프력 증가 버프를 적용
    /// itemData에서 버프 지속 시간을 가져올 수 있으며, 코루틴을 실행해 일정 시간 동안 점프력을 증가
    /// </summary>
    /// <param name="player">버프를 적용할 플레이어 객체</param>
    /// <param name="itemData">적용할 아이템 데이터</param>
    public override void ApplyBuff(PlayerController player, ItemData itemData)
    {
        base.ApplyBuff(player, itemData);

        float duration = defaultDuration;
        float multiplier = powerMultiplier;

        // 아이템 데이터 내 버프 정보에서 JumpForceUp 버프가 있으면 지속시간 갱신
        foreach (ItemDataBuff buff in itemData.Buffs)
        {
            if (buff.type == BuffType.JumpForceUp)
            {
                duration = buff.duration;
                break;
            }
        }

        // 버프 코루틴이 이미 돌고 있으면 중복 실행 방지를 위해 중지
        if (jumpForceBuffCoroutine != null)
        {
            player.StopCoroutine(jumpForceBuffCoroutine);
        }

        // 점프력 버프 코루틴 시작, player 스크립트에서 getter/setter로 점프력 조정
        jumpForceBuffCoroutine = player.StartCoroutine(JumpForceBuffRoutine(player, multiplier, duration));

        Debug.Log($"[jumpForceUp] 점프력 {multiplier}배 증가 효과 적용 ({duration}초간)");
    }

    /// <summary>
    /// 일정 시간 동안 플레이어의 점프 힘을 배율만큼 증가시키고, 시간이 지나면 원래 점프 힘으로 복원하는 코루틴
    /// </summary>
    /// <param name="player">점프력을 변경할 플레이어 객체</param>
    /// <param name="multiplier">점프력 배율</param>
    /// <param name="duration">버프 지속 시간 (초)</param>
    /// <returns></returns>
    private IEnumerator JumpForceBuffRoutine(Player player, float multiplier, float duration)
    {
        // 원래 점프력 저장
        float originalJumpForce = player.GetJumpForce();

        // 점프력 증가 적용
        player.SetJumpForce(originalJumpForce * multiplier);

        // 버프 지속 시간 대기
        yield return new WaitForSeconds(duration);

        // 점프력 원복
        player.SetJumpForce(originalJumpForce);

        // 코루틴 종료 처리
        jumpForceBuffCoroutine = null;
    }
}
