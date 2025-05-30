using UnityEngine;

public class TrackSpawner : MonoBehaviour
{
    [Header("플레이어(또는 카메라) Transform")] 
    public Transform player;

    [Header("스폰할 트랙 프리팹들")] 
    public GameObject[] trackPrefabs;

    [Header("플레이어 앞 맵 유지 거리")] 
    public float spawnAheadDistance = 100f;

    private float nextSpawnZ; // 다음 트랙 시작 Z 위치
    private int lastPrefabIndex = -1; // 마지막에 뽑은 Prefab 인덱스

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
        // 1) 뽑을 인덱스 결정 (마지막과 다르게)
        int prefabCount = trackPrefabs.Length;
        int newIndex;

        if (prefabCount <= 1)
        {
            newIndex = 0;
        }
        else
        {
            // 0부터 prefabCount-1 중 lastPrefabIndex만 제외해야 하므로
            // 랜덤으로 하나 뽑고, 같으면 (idx+1)%count 방식으로 밀기
            newIndex = Random.Range(0, prefabCount - 1);
            if (newIndex >= lastPrefabIndex)
                newIndex += 1;
        }

        // 2) 선택된 Prefab 으로 인스턴스화
        GameObject prefab = trackPrefabs[newIndex];
        GameObject go = Instantiate(prefab, transform);

        // 3) 배치
        go.transform.position = new Vector3(0f, 0f, nextSpawnZ);
        go.transform.rotation = Quaternion.identity;

        // 4) nextSpawnZ 갱신
        float length = go.GetComponent<Track>().length;
        nextSpawnZ += length;

        // 5) 이번에 뽑은 인덱스를 저장
        lastPrefabIndex = newIndex;
    }
}