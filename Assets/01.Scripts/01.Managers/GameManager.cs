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
        UIManager.Instance.Open<InGameUI>();
        player = FindObjectOfType<Player>();
    }

    public void PressAnyKey(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            gameState = GameState.Playing;
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UIManager.Instance.Open<InGameUI>();
        player = FindObjectOfType<Player>();
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // 게임 시간 재게
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoHome()
    {
        Time.timeScale = 1f; // 게임 시간 재게
        // 메인 화면으로 가기 (임시로 Restart)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
