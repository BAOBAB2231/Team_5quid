using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InGameUI : UIBase
{
    [SerializeField] private TMP_Text coinText;
    [SerializeField] private TMP_Text scoreText;

    public void UpdataCoinText(float coin)
    {
        coinText.text = coin.ToString("F0");
    }

    public void UpdataScoreText(float score)
    {
        scoreText.text = score.ToString("F0");
    }

    public void OnClickPause()
    {
        Time.timeScale = 0f; // 게임 정지
        UIManager.Instance.Open<PauseUI>(); // 일시정지 UI 오픈
    }
}
