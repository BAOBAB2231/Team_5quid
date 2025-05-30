using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestObs : MonoBehaviour
{
   void OnTriggerEnter(Collider other)
   {
     
      if (other.tag == "Player")
      {
         GameManager.Instance.GameOver();
          Debug.Log("충돌");
      }

   }
}
