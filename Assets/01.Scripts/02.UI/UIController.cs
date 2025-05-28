using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            UIManager.Instance.Open<GameOverUI>();

        if (Input.GetKeyDown(KeyCode.E))
            UIManager.Instance.Close<GameOverUI>();
    }

    //UI
    public void OpenUICanvas()
    {
        UIManager.Instance.Open<UICanvas>();
    }

    public void OpenSettingBoard()
    {
        UIManager.Instance.Open<SettingBoard>();
    }
}
