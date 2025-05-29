using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private void Start()
    {
        UIManager.Instance.Open<MainCanvas>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            UIManager.Instance.Open<GameOverUI>();

        if (Input.GetKeyDown(KeyCode.E))
            UIManager.Instance.Close<GameOverUI>();

        if (GameManager.Instance.gameState == GameState.Playing)
        {
            UIManager.Instance.Close<MainCanvas>();
        }
    }

    public void OpenSettingBoardCanvas()
    {
        UIManager.Instance.Open<SettingBoardCanvas>();
    }

    public void CloseSettingBoardCanvas()
    {
        UIManager.Instance.Close<SettingBoardCanvas>();
    }
}
