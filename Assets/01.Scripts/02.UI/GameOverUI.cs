using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameOverUI : UIBase
{
    [SerializeField] private Button homeButton;
    [SerializeField] private Button retryButton;

    private void Awake()
    {
        homeButton.onClick.AddListener(OnClickHome);
        retryButton.onClick.AddListener(OnClickRetry);
    }

    private void OnClickHome()
    {
        GameManager.Instance.GoHome();
    }

    private void OnClickRetry()
    {
        GameManager.Instance.RestartGame();
    }
}
