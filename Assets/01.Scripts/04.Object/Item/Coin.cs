using System.Collections;
using UnityEngine;

// Coin 클래스는 코인을 플레이어 방향으로 이동시키며, 비활성화 시 이동을 멈춥니다.
public class Coin : MonoBehaviour
{
    // 현재 실행 중인 코루틴을 저장할 변수
    private IEnumerator _coroutine;

    /// <summary>
    /// 코인을 지정한 플레이어 위치로 주어진 속도로 이동시키는 메서드입니다.
    /// </summary>
    /// <param name="player">이동 대상인 플레이어의 Transform</param>
    /// <param name="speed">이동 속도</param>
    public void MoveToPlayer(Transform player, float speed)
    {
        // 이전에 실행 중이던 코루틴이 있다면 중지
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        // 새로운 이동 코루틴을 설정하고 실행
        _coroutine = MoveCoroutine(player, speed);
        StartCoroutine(_coroutine);
    }

    /// <summary>
    /// 플레이어를 향해 지속적으로 이동하는 코루틴입니다.
    /// </summary>
    /// <param name="player">이동 대상인 플레이어의 Transform</param>
    /// <param name="speed">이동 속도</param>
    /// <returns>IEnumerator</returns>
    IEnumerator MoveCoroutine(Transform player, float speed)
    {
        while (true)
        {
            // 플레이어 방향 벡터를 정규화
            Vector3 direction = (player.position - transform.position).normalized;

            // 코인을 방향으로 일정 속도로 이동
            transform.position += direction * Time.deltaTime * speed;

            // 다음 프레임까지 대기
            yield return null;
        }
    }

    /// <summary>
    /// 게임 오브젝트가 비활성화될 때 호출되며, 코루틴을 중지시킵니다.
    /// </summary>
    private void OnDisable()
    {
        // 코루틴이 실행 중이면 중지
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }
}
