using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   
    private static GameManager instance;
    public static GameManager Instance { get { return instance; }
    }
    public SoundManager soundManager;
    private Player player;
       public Player Player{get{return player;}}
    private void Awake()
    {
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

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UIManager.Instance.Open<InGameUI>();
        player = FindObjectOfType<Player>();
    }
}
