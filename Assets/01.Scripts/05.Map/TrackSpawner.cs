using UnityEngine;

public class TrackSpawner : MonoBehaviour
{
    [Header("�÷��̾�(�Ǵ� ī�޶�) Transform")]
    public Transform player;

    [Header("������ Ʈ�� �����յ�")]
    public GameObject[] trackPrefabs;

    [Header("�÷��̾� �� �� ���� �Ÿ�")]
    public float spawnAheadDistance = 100f;

    private float nextSpawnZ;  // ���� ���׸�Ʈ ���� Z ��ġ

    void Start()
    {
        // �ʱ�ȭ: �÷��̾� �ٷ� �պ��� �� ä���
        nextSpawnZ = Mathf.Floor(player.position.z);
        while (nextSpawnZ < player.position.z + spawnAheadDistance)
        {
            SpawnTrack();
        }
    }

    void Update()
    {
        // �÷��̾ ������ �� ������, ���� �Ÿ����� ��� ä���ش�
        while (nextSpawnZ < player.position.z + spawnAheadDistance)
        {
            SpawnTrack();
        }
    }

    void SpawnTrack()
    {
        // 1) ���� ������ ����
        GameObject prefab = trackPrefabs[Random.Range(0, trackPrefabs.Length)];
        // 2) �ν��Ͻ� ����
        GameObject go = Instantiate(prefab, transform);
        // 3) ��ġ ����
        go.transform.position = new Vector3(0f, 0f, nextSpawnZ);
        go.transform.rotation = Quaternion.identity;  // �׻� ����

        // 4) ���� ���� Z ��ġ ����
        float trackLength = go.GetComponent<Track>().length;
        nextSpawnZ += trackLength;
    }
}