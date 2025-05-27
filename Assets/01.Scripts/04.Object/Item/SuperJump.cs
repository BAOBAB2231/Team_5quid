using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플레이어가 접촉할 경우 위로 튕겨내고, 자신은 삭제되는 점프대
/// </summary>
public class SuperJump : MonoBehaviour
{
    [Header("점프 설정")]
    [Tooltip("플레이어를 위로 튕겨낼 힘")]
    public float jumpForce = 0f;

    /// <summary>
    /// 플레이어가 충돌 시 점프력을 주고 슈퍼 점프 아이템을 제거
    /// </summary>
    /// <param name="collision">충돌 정보</param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Debug.Log("슈퍼점프 작동!");

                // 점프력 적용
                rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);

                // 아이템 제거 (0.05초 후 제거로 처리 안정성 확보)
                Destroy(gameObject, 0.05f);
            }
        }
    }
}
