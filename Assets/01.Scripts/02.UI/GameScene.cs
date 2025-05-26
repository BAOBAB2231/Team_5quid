using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            UIManager.Instance.Open<MainUI>();

        if (Input.GetKeyDown(KeyCode.E))
            UIManager.Instance.Close<MainUI>();
    }
}
