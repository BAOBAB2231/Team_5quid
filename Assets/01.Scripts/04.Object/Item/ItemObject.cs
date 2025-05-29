using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어와 충돌 시 부착된 효과 아이템들을 모두 적용하고 오브젝트를 제거
public class ItemObject : MonoBehaviour
{
    public ItemData itemData;    // 아이템 데이터 (ScriptableObject 참조)

    /// <summary>
    /// 플레이어와 충돌 시 아이템 효과를 적용하고 오브젝트 제거
    /// </summary>
    /// <param name="other">충돌한 콜라이더</param>
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"[OnTriggerEnter] 충돌 발생: {other.gameObject.name}");

        if (itemData == null)    // 아이템 데이터가 없으면 경고 후 종료
        {
            Debug.LogWarning("[ItemObject] itemData가 설정되지 않았습니다.");
            return;
        }

        // 충돌한 객체가 Player 레이어일 경우에만 처리
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            // PlayerController 컴포넌트 가져오기
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController == null) return;

            // 부착된 모든 EffectItem 컴포넌트에 대해 효과 적용
            foreach (EffectItem effectItem in GetComponents<EffectItem>())
            {
                effectItem.ApplyEffect(playerController);
            }

            // 아이템 오브젝트를 약간의 딜레이 후 제거하여 안정성 확보
            Destroy(gameObject, 0.05f);
        }
    }
}
