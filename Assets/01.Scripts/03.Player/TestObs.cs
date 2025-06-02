using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestObs : MonoBehaviour
{
   private Player player;

   private void Start()
   {
      player = GetComponentInParent<Player>();
   }

   void OnTriggerEnter(Collider other)
   {

      if(player.tag == "PowerUp")return;

      if ( other.gameObject.layer ==  LayerMask.NameToLayer("Obstacle")) 
      {
         GameManager.Instance.GameOver();
         
      }

   }
}
