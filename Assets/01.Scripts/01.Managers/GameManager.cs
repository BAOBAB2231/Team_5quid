using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

//게임의 상태를 표시한 열거형
public enum GameState
{
    Waiting,
    Playing
}

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; }}

    private Player player;
    public Player Player{get{return player;}}

    public GameState gameState;

    private void Awake()
    {
        gameState = GameState.Waiting;

        if(instance ==  null)
            {
            instance = this;   
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
            }

        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public void PressAnyKey(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && gameState == GameState.Waiting) // 중복 호출 방지
        {
            gameState = GameState.Playing;

            UIManager.Instance.Open<InGameUI>();
            UIManager.Instance.Close<MainCanvas>();
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UIManager.Instance.ClearAll();
        player = FindObjectOfType<Player>();

        if (gameState == GameState.Playing)
        {
            UIManager.Instance.Open<InGameUI>();
            UIManager.Instance.Close<MainCanvas>();
        }
        else if (gameState == GameState.Waiting)
        {
            UIManager.Instance.Open<MainCanvas>();
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // 게임 시간 재게
        gameState = GameState.Playing;
        UIManager.Instance.ClearAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SoundManager.Instance.PlayBGM();
    }

    public void GoHome()
    {
        Time.timeScale = 1f; // 게임 시간 재게
        gameState = GameState.Waiting;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SoundManager.Instance.PlayBGM();
    }
}
