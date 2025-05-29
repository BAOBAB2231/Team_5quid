using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 자석 효과 아이템 (주변 코인을 플레이어에게 끌어당김)
public class Magnet : EffectItem
{
    [SerializeField] private List<Coin> coins;  // 끌어당길 코인 리스트

    [SerializeField] private float speed = 0.5f;   // 코인 이동 속도

    /// <summary>
    /// 플레이어에게 자석 효과 적용
    /// </summary>
    /// <param name="player">효과를 적용할 플레이어</param>
    public override void ApplyEffect(PlayerController player)
    {
        foreach (var coin in coins)
        {
            if (coin != null)
            {
                coin.MoveToPlayer(player.transform, speed);
            }
        }

        Debug.Log($"[Magnet] {player.name} 주변 코인들을 끌어당깁니다.");
    }
}
