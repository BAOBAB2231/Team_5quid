using UnityEngine;

public class ObstacleActivationMover : MonoBehaviour
{
    [Header("플레이어 Transform")]
    public Transform player;

    [Header("이동 시작 거리 (유닛)")]
    public float activationDistance = 100f;

    [Header("이동 속도")]
    public float moveSpeed = 40f;

    // 한 번 활성화되면 계속 움직이도록 플래그
    private bool isActive = false;
    
    void Awake()
    {
        // 플레이어가 할당되지 않았으면 태그로 찾아서 할당
        if (player == null)
        {
            var go = GameObject.FindWithTag("Player");
            if (go != null)
                player = go.transform;
            else
                Debug.LogError("[ObstacleMover] Player 태그가 붙은 오브젝트를 찾을 수 없습니다.");
        }
    }

    void Update()
    {
        if (!isActive)
        {
            // 장애물이 플레이어 앞(플레이어보다 Z 값이 큼)에 있을 때
            float deltaZ = transform.position.z - player.position.z;

            // 0 < deltaZ ≤ activationDistance 일 때 활성화
            if (deltaZ > 0f && deltaZ <= activationDistance)
            {
                isActive = true;
            }
        }
        else
        {
            // 활성화된 이후엔 계속 플레이어 쪽(-Z)으로 이동
            transform.position += Vector3.back * moveSpeed * Time.deltaTime;
        }
    }
}