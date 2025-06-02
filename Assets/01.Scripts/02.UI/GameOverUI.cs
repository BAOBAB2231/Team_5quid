using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GameOverUI : UIBase
{
    [SerializeField] private Button homeButton;
    [SerializeField] private Button retryButton;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text bestText;

    private void Awake()
    {
        homeButton.onClick.AddListener(OnClickHome);
        retryButton.onClick.AddListener(OnClickRetry);
    }

    public void UpdateScoreTexts(int score)
    {
        scoreText.text = score.ToString();

        int best = PlayerPrefs.GetInt("BestScore", 0);
        if (score > best)
        {
            best = score;
            PlayerPrefs.SetInt("BestScore", best);
        }

        bestText.text = best.ToString();
    }

    public override void Open()
    {
        base.Open();

        int finalScore = ScoreManager.Instance.GetScore();
        UpdateScoreTexts(finalScore);
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
