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
        // Inspector에 할당이 안 돼 있으면 Layer로 찾아서 채워준다.
        if (player == null)
        {
            // “Player”라는 이름의 Layer 인덱스를 가져옵니다.
            int playerLayer = LayerMask.NameToLayer("Player");
            if (playerLayer == -1)
            {
                Debug.LogError("[ObstacleActivationMover] 'Player' 레이어가 존재하지 않습니다. Layer 설정을 확인하세요.");
                return;
            }

            // 씬에 있는 모든 Transform을 순회하면서 동일한 레이어인지 확인
            foreach (var t in FindObjectsOfType<Transform>())
            {
                if (t.gameObject.layer == playerLayer)
                {
                    player = t;
                    break;
                }
            }

            if (player == null)
                Debug.LogError("[ObstacleActivationMover] 'Player' 레이어가 할당된 오브젝트를 찾을 수 없습니다.");
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