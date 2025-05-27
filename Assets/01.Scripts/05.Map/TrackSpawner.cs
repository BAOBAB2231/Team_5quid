using UnityEngine;

public class TrackSpawner : MonoBehaviour
{
    [Header("플레이어(또는 카메라) Transform")]
    public Transform player;

    [Header("스폰할 트랙 프리팹들")]
    public GameObject[] trackPrefabs;

    [Header("플레이어 앞 맵 유지 거리")]
    public float spawnAheadDistance = 100f;

    private float nextSpawnZ;  // 다음 세그먼트 시작 Z 위치

    void Start()
    {
        // 초기화: 플레이어 바로 앞부터 맵 채우기
        nextSpawnZ = Mathf.Floor(player.position.z);
        while (nextSpawnZ < player.position.z + spawnAheadDistance)
        {
            SpawnTrack();
        }
    }

    void Update()
    {
        // 플레이어가 앞으로 갈 때마다, 지정 거리까지 계속 채워준다
        while (nextSpawnZ < player.position.z + spawnAheadDistance)
        {
            SpawnTrack();
        }
    }

    void SpawnTrack()
    {
        // 1) 랜덤 프리팹 선택
        GameObject prefab = trackPrefabs[Random.Range(0, trackPrefabs.Length)];
        // 2) 인스턴스 생성
        GameObject go = Instantiate(prefab, transform);
        // 3) 위치 세팅
        go.transform.position = new Vector3(0f, 0f, nextSpawnZ);
        go.transform.rotation = Quaternion.identity;  // 항상 직선

        // 4) 다음 스폰 Z 위치 갱신
        float trackLength = go.GetComponent<Track>().length;
        nextSpawnZ += trackLength;
    }
}