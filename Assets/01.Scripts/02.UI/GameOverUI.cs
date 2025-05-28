using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : UIBase
{
    public void OnClickRetry()
    {
        // 재시작 기능 추가
        Close();
    }

    public void OnClickHome()
    {
        // 게임 초기화 추가
        Close();
    }
}
