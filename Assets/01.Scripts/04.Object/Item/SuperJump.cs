using UnityEngine;

// 슈퍼 점프 효과 아이템 (플레이어를 위로 튕겨냄)
public class SuperJump : EffectItem
{
    /// <summary>
    /// 플레이어에게 슈퍼 점프 효과 적용
    /// </summary>
    /// <param name="player">효과를 적용할 대상 플레이어</param>
    public override void ApplyEffect(PlayerController player, ItemDataEffect effect)
    {
        Debug.Log("[EffectItem] SuperJump 효과 발동");

        Rigidbody rb = player.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Y축으로 강한 점프 적용
            rb.velocity = new Vector3(rb.velocity.x, effect.strength, rb.velocity.z);
        }
    }
}
