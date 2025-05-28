using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 플레이어가 보유한 자원을 관리하는 클래스
/// </summary>
public class Point : MonoBehaviour
{
    public float currentCoin = 0f;      // 현재 코인 수
    public float startCoin = 0f;        // 시작 코인 수

    private void Start()
    {
        currentCoin = startCoin;
    }

    /// <summary>
    /// 코인을 추가로 획득함
    /// </summary>
    /// <param name="amount">획득할 코인 양</param>
    public void AddCoin(int amount)
    {
        currentCoin += amount;
        Debug.Log($"[PlayerResource] 코인 {amount}개 획득! 현재 코인: {currentCoin}");

        // UI 업데이트 기능 추가 예정(추가 완료)
        UIManager.Instance.Get<InGameUI>()?.UpdataCoinText(currentCoin);
    }

    /// <summary>
    /// 현재 코인 수를 반환
    /// </summary>
    public float GetCoin()
    {
        return currentCoin;
    }
}
