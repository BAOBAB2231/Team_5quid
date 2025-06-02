using System.Collections;
using UnityEngine;

// 플레이어가 보유한 자원을 관리하는 클래스
public class Point : MonoBehaviour
{
    public float currentCoin = 0f;      // 현재 코인 수
    public float startCoin = 0f;        // 시작 코인 수

    private float coinMultiplier = 1f;  // 코인 배율 (기본 1배)


    private void Start()
    {
        currentCoin = startCoin;

        if (UIManager.TryGet<InGameUI>(out InGameUI ui))
        {
            ui.UpdateCoinText(currentCoin);
        }
    }

    /// <summary>
    /// 코인을 추가로 획득함
    /// </summary>
    /// <param name="amount">획득할 코인 양</param>
    public void AddCoin(int amount)
    {
        float total = amount * coinMultiplier;
        currentCoin += total;

        Debug.Log($"[PlayerResource] 코인 {total}개 획득! 현재 코인: {currentCoin}");

        if (UIManager.TryGet<InGameUI>(out InGameUI ui))
        {
            ui.UpdateCoinText(currentCoin);
        }
    }

    /// <summary>
    /// 현재 코인 수를 반환
    /// </summary>
    public float GetCoin()
    {
        return currentCoin;
    }

    /// <summary>
    /// 일정 시간 동안 코인 획득량을 2배로 증가시키는 코루틴
    /// </summary>
    /// <param name="duration">버프 지속 시간 (초)</param>
    public IEnumerator DoubleCoinRoutine(float duration)
    {
        coinMultiplier = 2f;
        Debug.Log($"[Point] 코인 2배 버프 시작 ({duration}초)");

        yield return new WaitForSeconds(duration);

        coinMultiplier = 1f;
        Debug.Log("[Point] 코인 2배 버프 종료");
    }
}
