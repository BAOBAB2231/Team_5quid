using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 버프 아이템 효과를 정의한 클래스. 여러 버프를 플레이어에게 적용함.
public class BuffItem : MonoBehaviour
{
    public ItemData itemData;    // 아이템 데이터 (ScriptableObject 참조)

    /// <summary>
    /// 버프 아이템 효과 적용
    /// </summary>
    /// <param name="player">효과를 적용할 플레이어</param>
    public void ApplyBuffs(PlayerController player)
    {
        if (itemData == null)
        {
            Debug.LogWarning("[BuffItem] itemData가 설정되지 않았습니다.");
            return;
        }

        foreach (ItemDataBuff buff in itemData.Buffs)
        {
            ApplyBuff(player, buff);
        }
    }

    /// <summary>
    /// 단일 버프 효과 적용
    /// </summary>
    /// <param name="player">버프 대상 플레이어</param>
    /// <param name="buff">적용할 버프 정보</param>
    private void ApplyBuff(PlayerController player, ItemDataBuff buff)
    {
        Debug.Log($"[BuffItem] {buff.type} 버프 적용 (지속시간: {buff.value})");
        // 실제 버프 로직은 구현 예정
    }
}
