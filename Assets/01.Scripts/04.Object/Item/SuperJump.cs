using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 슈퍼 점프 효과 아이템 (일정 시간 PowerUp 태그 부여)
public class SuperJump : EffectItem
{
    [Header("슈퍼 점프 힘")]
    [Tooltip("위로 튕겨낼 점프 힘")]
    public float jumpBoost = 30f;

    /// <summary>
    /// 플레이어에게 슈퍼 점프 효과 적용
    /// </summary>
    /// <param name="player">효과를 적용할 대상 플레이어</param>
    public override void ApplyEffect(PlayerController player)
    {
        Debug.Log("[EffectItem] SuperJump 효과 발동");

        Rigidbody rb = player.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(Vector3.up * jumpBoost, ForceMode.VelocityChange);
        }
        else
        {
            Debug.LogWarning("[SuperJump] Rigidbody가 없음");
        }
    }
}
