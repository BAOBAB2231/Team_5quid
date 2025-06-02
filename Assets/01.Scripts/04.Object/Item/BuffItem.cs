using UnityEngine;

// 버프 아이템의 효과를 적용하는 클래스
public class BuffItem : MonoBehaviour
{
    /// <summary>
    /// 플레이어에게 버프 효과 적용
    /// </summary>
    /// <param name="player">버프를 적용할 플레이어</param>
    /// <param name="itemData">적용할 아이템 데이터</param>
    public virtual void ApplyBuff(Player player, ItemData itemData)
    {
        if (itemData.Buffs == null || itemData.Buffs.Length == 0)
        {
            return;
        }

        foreach (ItemDataBuff buff in itemData.Buffs)
        {

            switch (buff.type)
            {
                case BuffType.ScoringUp:
                    // 추후 구현
                    break;

                case BuffType.JumpForceUp:
                    break;

                case BuffType.CoinVolumeUp:
                    break;
            }
        }
    }
}