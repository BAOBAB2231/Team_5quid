using UnityEngine;

public class DespawnZone : MonoBehaviour
{
    [Header("파괴할 오브젝트의 태그")]
    public string targetTag = "Track";

    private void OnTriggerEnter(Collider other)
    {
        // Track 컴포넌트를 탐색해서 있으면 해당 루트를 파괴
        var track = other.GetComponentInParent<Track>();
        if (track != null)
        {
            Destroy(track.gameObject);
        }
    }
}