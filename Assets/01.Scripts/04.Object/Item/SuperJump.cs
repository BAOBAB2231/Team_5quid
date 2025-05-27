using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 슈퍼 점프 효과 아이템 (플레이어를 위로 튕겨냄)
/// </summary>
public class SuperJump : EffectItem
{
    [Header("슈퍼 점프 힘")]
    [Tooltip("위로 튕겨낼 점프 힘")]
    public float jumpBoost = 30f;

    /// <summary>
    /// 플레이어에게 슈퍼 점프 효과 적용
    /// </summary>
    /// <param name="player">효과를 적용할 대상 플레이어</param>
    public override void ApplyEffect(PlayerController player, EffectType effect)
    {
        Debug.Log("[EffectItem] SuperJump 효과 발동");

        Rigidbody rb = player.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Y축으로 강한 점프 적용
            rb.velocity = new Vector3(rb.velocity.x, jumpBoost, rb.velocity.z);
        }
    }
}
