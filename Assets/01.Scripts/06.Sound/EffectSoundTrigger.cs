using UnityEngine;

public class EffectSoundTrigger : MonoBehaviour
{
    [SerializeField] private SFXPlayer sfxPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Item"))
        {
            ItemObject itemObject = other.GetComponent<ItemObject>();
            if (itemObject != null && itemObject.itemData != null && itemObject.itemData.Sounds != null)
            {
                sfxPlayer.PlaySFX(itemObject.itemData.Sounds);
            }
        }
    }
}
