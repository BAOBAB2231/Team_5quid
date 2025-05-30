using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestObs : MonoBehaviour
{
   void OnTriggerEnter(Collider other)
   {

      if ( other.gameObject.layer ==  LayerMask.NameToLayer("Obstacle")) 
      {
         GameManager.Instance.GameOver();
         
      }

   }
}
