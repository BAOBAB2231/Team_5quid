using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 자원 아이템(코인)을 획득하는 아이템. 충돌 시 자원을 추가함.
public class ResourceItem : MonoBehaviour
{
    public int amount = 1; // 획득량

    /// <summary>
    /// 플레이어에게 자원 지급
    /// </summary>
    /// <param name="player">자원을 받을 플레이어</param>
    public void Apply(GameObject player)
    {
        Point point = player.GetComponent<Point>();
        if (point != null)
        {
            point.AddCoin(amount);
            Debug.Log($"[ResourceItem] 코인 {amount}개 추가!");
        }
        else
        {
            Debug.LogWarning("[ResourceItem] Point 컴포넌트를 찾을 수 없습니다.");
        }
    }
}
