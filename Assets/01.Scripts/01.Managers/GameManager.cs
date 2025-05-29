using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    public static GameManager Instance { get { return instance; }
    }
    public SoundManager soundManager;
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

    private void Update()
    {
        if (Input.anyKey)
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoHome()
    {
        // 메인 화면으로 가기 (임시로 Restart)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
