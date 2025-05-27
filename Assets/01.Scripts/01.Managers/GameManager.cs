using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   
    private static GameManager instance;
    public static GameManager Instance { get { return instance; }
    }
    public SoundManager soundManager;
    public UIManager uiManager;
    private Player player;
       public Player Player{get{return player;}}
    private void Awake()
    {
        if(instance ==  null)
            {
            instance = this;   
            DontDestroyOnLoad(gameObject);
            }

        else
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        player=FindObjectOfType<Player>();
        UIManager.Instance.Open<InGameUI>();
    }


    void Update()
    {
        
    }
}
