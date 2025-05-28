using System.Collections;
using UnityEngine;

/// 장애물 오브젝트에 대한 동작을 제어하는 클래스.
public class Obstacle : MonoBehaviour
{
    [Header("튕겨나갈 때의 물리 설정")]
    [Tooltip("튕겨나갈 때 적용할 힘의 세기")]
    public float launchForce = 20f;

    [Tooltip("회전을 위한 토크 세기")]
    public float torqueAmount = 200f;

    private bool hasLaunched = false; // 중복 실행 방지용 플래그

    /// <summary>
    /// PowerUp 태그와 충돌했을 때 호출되는 함수.
    /// 장애물을 뒤+위 방향으로 날아가게 하고, 회전을 부여한 뒤 2초 후 제거
    /// </summary>
    /// <param name="collision">충돌 정보를 담고 있는 Collision 객체</param>
    private void OnCollisionEnter(Collision collision)
    {
        // 이미 한 번 발동했으면 무시
        if (hasLaunched) return;

        // 충돌한 객체가 PowerUp 태그인지 확인
        if (collision.gameObject.CompareTag("PowerUp"))
        {
            hasLaunched = true;

            // 플레이어와의 충돌 반대 방향 계산
            Vector3 collisionDirection = (transform.position - collision.transform.position).normalized;

            // 위쪽 방향과 섞어서 45도 방향 계산
            Vector3 launchDirection = (collisionDirection + Vector3.up).normalized;

            // Rigidbody를 동적으로 추가하고 설정
            Rigidbody rb = gameObject.AddComponent<Rigidbody>();
            rb.useGravity = true;
            rb.mass = 1f;
            rb.angularDrag = 0.05f;

            // 장애물을 튕겨내는 힘 적용
            rb.AddForce(launchDirection * launchForce, ForceMode.Impulse);

            // 회전 효과를 위한 토크 적용 (y축 기준 회전)
            rb.AddTorque(Vector3.up * torqueAmount);

            // 2초 후 게임 오브젝트 제거
            StartCoroutine(DestroyAfterSeconds(2f));
        }
    }

    /// <summary>
    /// 지정된 시간 후 장애물을 삭제하는 코루틴 함수.
    /// </summary>
    /// <param name="seconds">지연 시간 (초)</param>
    private IEnumerator DestroyAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}
