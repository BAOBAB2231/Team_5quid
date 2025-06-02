using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    private float currentScore = 0f; // 현재 점수
    private bool isCounting = false; // 점수 증가 활성화 여부
    private float scorePerSecond = 10f; // 초당 증가할 점수량

    private void Awake()
    {
        // 싱글톤 패턴: 인스턴스가 없으면 생성하고 유지, 없으면 제거
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        // 매 프레임 점수 증가, UI에 반영
        if (isCounting)
        {
            currentScore += scorePerSecond * Time.deltaTime;

            UIManager.TryGet<InGameUI>(out InGameUI ui);

            if (ui != null)
            {
                ui.UpdateScoreText((int)currentScore);
            }
        }
    }

    public void StartScoring() // 점수 계산 시작
    {
        isCounting = true;
    }

    public void StopScoring() // 점수 계산 멈춤
    {
        isCounting = false;
    }

    public void ResetScore() // 점수 초기화
    {
        currentScore = 0f;

        UIManager.TryGet<InGameUI>(out InGameUI ui);
        if (ui != null)
        {
            ui.UpdateScoreText(0);
        }
    }

    public int GetScore() // 점수 가져오기
    {
        return Mathf.FloorToInt(currentScore);
    }
}
