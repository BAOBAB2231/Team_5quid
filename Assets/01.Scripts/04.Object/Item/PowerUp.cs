using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플레이어가 이 PowerUp 오브젝트에 충돌하면
/// 일정 시간 동안 PowerUp 태그를 부여한다.
/// 이전 효과가 존재하면 제거 후 새로 적용한다.
/// </summary>
public class PowerUp : MonoBehaviour
{
    [Header("파워업 지속 시간 설정")]
    [Tooltip("PowerUp 태그가 유지될 시간 (초)")]
    public float powerUpDuration = 10f;

    public string powerUpTag = "PowerUp";

    // 플레이어에 적용 중인 파워업 코루틴을 추적하기 위한 Dictionary
    private static Dictionary<GameObject, Coroutine> activePowerUps = new Dictionary<GameObject, Coroutine>();

    private void OnTriggerEnter(Collider other)
    {
        GameObject target = other.gameObject;

        // 레이어 이름으로 플레이어 확인
        if (LayerMask.LayerToName(target.layer) != "Player") return;

        // 유효한 태그인지 확인
        if (string.IsNullOrEmpty(powerUpTag)) return;

        // 기존 파워업 코루틴이 있으면 중단하고 초기화
        if (activePowerUps.TryGetValue(target, out Coroutine existing))
        {
            StopCoroutine(existing);
            target.tag = "Untagged"; // 초기화
            activePowerUps.Remove(target);
        }

        // 새 파워업 효과 적용
        Coroutine newPowerUp = StartCoroutine(ApplyPowerUpTag(target));
        activePowerUps[target] = newPowerUp;
    }

    /// <summary>
    /// 일정 시간 동안 PowerUp 태그를 적용하고 원래 태그로 복원
    /// </summary>
    private IEnumerator ApplyPowerUpTag(GameObject player)
    {
        string originalTag = player.tag;

        player.tag = powerUpTag;

        yield return new WaitForSeconds(powerUpDuration);

        player.tag = originalTag;

        // 파워업 종료 처리
        activePowerUps.Remove(player);
    }
}
