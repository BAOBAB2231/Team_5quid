using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI : UIBase
{
    [SerializeField] private Button homeButton;
    [SerializeField] private Button retryButton;
    [SerializeField] private GameObject buttonPanel;
    [SerializeField] private GameObject resumePanel;
    [SerializeField] private TMP_Text countdownText;

    private void Awake()
    {
        homeButton.onClick.AddListener(OnClickHome);
        retryButton.onClick.AddListener(OnClickRetry);
        resumePanel.SetActive(false); // 시작 시 끄기
    }

    public override void Open() // 부모 함수 재정의
    {
        base.Open(); // UIBase의 Open 실행
        buttonPanel.SetActive(true); // 버튼 패널 활성화
        resumePanel.SetActive(false); // 리섬 패널 숨기기
        countdownText.gameObject.SetActive(false); // 카운트다운 텍스트 숨기기
    }

    private void OnClickHome()
    {
        GameManager.Instance.GoHome();
    }

    private void OnClickRetry()
    {
        GameManager.Instance.RestartGame();
    }

    public void OnClickResume()
    {
        buttonPanel.SetActive(false);
        resumePanel.SetActive(true);
        countdownText.gameObject.SetActive(true);

        StartCoroutine(ResumeCountdown());
    }

    private IEnumerator ResumeCountdown()
    {
        for (int i = 3; i > 0; i--)
        {
            countdownText.text = i.ToString();
            yield return new WaitForSecondsRealtime(1f);
        }

        resumePanel.SetActive(false);
        countdownText.gameObject.SetActive(false);
        Time.timeScale = 1f;
        UIManager.Instance.Close<PauseUI>();
    }
}
