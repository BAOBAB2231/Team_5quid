using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSoundTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Item") && other.GetComponent<AudioClip>())
        {

        }
    }
}
