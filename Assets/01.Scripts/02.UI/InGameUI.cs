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
}
