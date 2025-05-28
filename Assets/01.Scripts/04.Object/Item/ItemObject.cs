using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 게임 내에서 등장하는 아이템 오브젝트. 플레이어와 충돌 시 아이템 타입에 따라 효과를 적용함.
public class ItemObject : MonoBehaviour
{
    public ItemData itemData;    // 아이템 데이터 (ScriptableObject 참조)

    // BuffItem, EffectItem 컴포넌트 캐싱 (매번 GetComponent 호출 방지)
    private BuffItem buffItem;
    private EffectItem effectItem;

    private void Awake()
    {
        buffItem = GetComponent<BuffItem>();
        effectItem = GetComponent<EffectItem>();
    }
    /// <summary>
    /// 플레이어와 충돌 시 아이템 효과를 적용하고 오브젝트 제거
    /// </summary>
    /// <param name="other">충돌한 콜라이더</param>
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"[OnTriggerEnter] 충돌 발생: {other.gameObject.name}");
        if (itemData == null)    // 아이템 데이터가 없을 경우 처리 중단
        {
            Debug.LogWarning("[ItemObject] itemData가 설정되지 않았습니다.");
            return;
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Player")) // 충돌 대상이 'Player' 레이어일 경우만 처리
        {
            ApplyEffect(other.gameObject); // 아이템 효과 적용

            Destroy(gameObject, 0.05f);    // 아이템 제거 (0.05초 후 제거로 처리 안정성 확보)
        }
    }

    /// <summary>
    /// 아이템 타입에 따라 효과를 분기 처리
    /// </summary>
    /// <param name="player">효과를 적용할 플레이어 오브젝트</param>
    private void ApplyEffect(GameObject player)
    {
        switch (itemData.type)
        {
            case ItemType.Buff:      // 버프 아이템일 경우
                ApplyBuff(player);
                break;

            case ItemType.Effect:    // 효과 아이템일 경우
                ApplyEffectItem(player);
                break;

            case ItemType.Resource:  // 자원 아이템(코인)일 경우
                ApplyResource(player);
                break;
        }
    }

    /// <summary>
    /// 버프 아이템 효과 적용
    /// </summary>
    /// <param name="player">버프를 적용할 플레이어</param>
    private void ApplyBuff(GameObject player)
    {
        if (buffItem == null) return;

        foreach (ItemDataBuff buff in itemData.Buffs)  
        {
            buffItem.ApplyBuff(player.GetComponent<PlayerController>(), buff);
        }
    }

    /// <summary>
    /// 효과 아이템 즉시 발동
    /// </summary>
    /// <param name="player">효과를 적용할 플레이어</param>
    private void ApplyEffectItem(GameObject player)
    {
        if (effectItem == null) return;

        PlayerController playerController = player.GetComponent<PlayerController>();
        if (playerController == null) return;

        foreach (EffectType effect in itemData.Effect)
        {
            effectItem.ApplyEffect(playerController, effect); // 인수 2개짜리 ApplyEffect 사용
        }
    }

    /// <summary>
    /// 자원 아이템(코인) 획득 처리 (플레이어에게 위임)
    /// </summary>
    /// <param name="player">코인을 획득할 플레이어</param>
    private void ApplyResource(GameObject player)
    {
        int amount = 1; // 항상 1씩 증가

        Debug.Log($"[Resource] 코인 {amount}개 획득!");

        Point point = player.GetComponent<Point>();
        if (point != null)
        {
            point.AddCoin(amount); // 항상 1코인만 추가
        }
        else
        {
            Debug.LogWarning("Point 컴포넌트를 찾을 수 없습니다.");
        }
    }
}
