using UnityEngine;

public class UIController : MonoBehaviour
{
    private void Start()
    {
        if (GameManager.Instance != null && GameManager.Instance.gameState == GameState.Waiting)
        {
            UIManager.Instance.Open<MainCanvas>();
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
