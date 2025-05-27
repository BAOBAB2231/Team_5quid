using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : EffectItem
{
    [SerializeField] private float duration = 10f; // 지속 시간
    [SerializeField] private float speed = 0.5f;   // 속도
    [SerializeField] private float range = 7f;     // 범위
    
    /// <summary>
    /// 플레이어에게 자석 효과 적용
    /// </summary>
    /// <param name="player">효과를 적용할 대상 플레이어</param>
    /// <param name="effect">적용할 효과 타입 (사용 안 함)</param>
    public override void ApplyEffect(PlayerController player, EffectType effect)
    {
        Debug.Log("[EffectItem] MagnetEffect 효과 발동");

        // 자석 코루틴 시작
        StartCoroutine(AttractCoins(player));
    }

    /// <summary>
    /// 지정된 시간 동안 범위 내 코인을 플레이어 방향으로 끌어당기는 코루틴
    /// </summary>
    /// <param name="player">플레이어 객체</param>
    /// <returns>IEnumerator</returns>
    private IEnumerator AttractCoins(PlayerController player)
    {
        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;

            // 범위 반폭(halfExtents) 설정
            Vector3 halfExtents = Vector3.one * range;

            // 플레이어 위치 기준 range 범위 내의 모든 충돌체 탐색
            Collider[] hits = Physics.OverlapBox(player.transform.position, Vector3.one * range, Quaternion.identity);
            Debug.Log($"OverlapBox가 감지한 콜라이더 수: {hits.Length}");

            foreach (Collider hit in hits)
            {
                Debug.Log($"감지된 오브젝트 이름: {hit.name} 태그: {hit.tag}");
                // 코인 태그가 붙은 오브젝트만 처리
                if (hit.CompareTag("Coin"))
                {
                    if (hit.CompareTag("Coin")) 
                    {
                        Debug.Log($"코인 {hit.name} 이동 시도");
                        Vector3 direction = (player.transform.position - hit.transform.position).normalized;

                        Rigidbody rb = hit.GetComponent<Rigidbody>();
                        if (rb != null)
                        {
                            // Rigidbody가 있으면 MovePosition 사용
                            rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
                        }
                        else
                        {
                            // Rigidbody 없으면 transform 직접 이동
                            hit.transform.position += direction * speed * Time.deltaTime;
                        }
                    }
                }
            }

            yield return null;
        }
    }
}

