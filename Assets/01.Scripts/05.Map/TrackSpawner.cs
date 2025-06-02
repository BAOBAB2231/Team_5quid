using System.Collections.Generic;
using UnityEngine;

public class TrackSpawner : MonoBehaviour
{
    [Header("플레이어 Transform")] public Transform player;

    [Header("스폰할 트랙 프리팹들")] public GameObject[] trackPrefabs;

    [Header("플레이어 앞 맵 유지 거리")] public float spawnAheadDistance = 800f;

    private float nextSpawnZ; // 다음 트랙 시작 Z 위치
    private bool firstTrackSpawned = false;  // 첫 트랙 스폰 여부
    private int lastPrefabIndex = -1; // 마지막에 뽑은 Prefab 인덱스

    void Start()
    {
        // 초기화: 플레이어 바로 앞부터 맵 채우기
        nextSpawnZ = Mathf.Floor(player.position.z);
        
        // 처음에는 인덱스 0의 트랙을 스폰
        SpawnTrack();

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

        if (!firstTrackSpawned)
        {
            // 첫 스폰은 index 0
            newIndex = 0;
            firstTrackSpawned = true;
        }
        else
        {
            // 첫 번째 이후부터는 index=0을 제외한 [1..prefabCount-1] 중에서
            // 직전에 뽑은 lastPrefabIndex를 제외하고 랜덤 선택

            // 후보 인덱스 리스트 만들기
            List<int> candidates = new List<int>();
            for (int i = 1; i < prefabCount; i++)
            {
                if (i == lastPrefabIndex) continue;
                candidates.Add(i);
            }

            // 만약 후보가 하나밖에 없다면 그걸 고르고, 그렇지 않으면 List.Count 범위 내에서 랜덤
            if (candidates.Count == 1)
            {
                newIndex = candidates[0];
            }
            else
            {
                int pick = Random.Range(0, candidates.Count);
                newIndex = candidates[pick];
            }
        }
        
        // 트랙 생성 및 배치
        GameObject go = Instantiate(trackPrefabs[newIndex], transform);
        go.transform.position = new Vector3(0f, 0f, nextSpawnZ);
        go.transform.rotation = Quaternion.identity;

        // nextSpawnZ 갱신
        float length = go.GetComponent<Track>().length;
        nextSpawnZ += length;

        // 방금 뽑은 인덱스를 저장
        lastPrefabIndex = newIndex;
    }
}