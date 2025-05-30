using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Magnet : EffectItem
{
    [SerializeField] private List<Coin> coins;

    [SerializeField] private float size;

    private void Awake()
    {
        var cols = Physics.OverlapBox(center: transform.position, halfExtents: Vector3.one * size);

        coins = cols
            .Where(col => col.CompareTag("Coin"))
            .Select(col => col.GetComponent<Coin>())
            .ToList();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;

        Gizmos.DrawWireCube(center: transform.position, Vector3.one * size * 2);
    }

    /// <summary>
    /// 플레이어에게 자석 효과 적용
    /// </summary>
    /// <param name="player">효과를 적용할 대상 플레이어</param>
    /// <param name="effect">적용할 효과 타입 (사용 안 함)</param>
    public override void ApplyEffect(PlayerController player, ItemDataEffect effect)
    {
        // 모든 코인을 순회하며 플레이어에게 이동
        foreach (var coin in coins)
            coin.MoveToPlayer(player.transform, effect.strength);
    }
}