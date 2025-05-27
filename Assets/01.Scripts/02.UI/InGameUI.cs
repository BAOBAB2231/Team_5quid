using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InGameUI : UIBase
{
    [SerializeField] private TMP_Text coinText;

    public void UpdataCoinText(float coin)
    {
        coinText.text = coin.ToString();
    }
}
