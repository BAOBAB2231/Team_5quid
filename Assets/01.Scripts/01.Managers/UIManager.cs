using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                // 하이어라키에 있는 오브젝트들 중에
                // UIManager 컴포넌트가 있는지 확인
                _instance = FindObjectOfType<UIManager>();
            }
            // 찾아봤는데 없을경우 새 게임오브젝트를 만들어서, UIManager 컴포넌트를 추가
            if (_instance == null)
            {
                GameObject go = new GameObject();
                go.name = "UIManger";
                _instance = go.AddComponent<UIManager>();
            }
            return _instance;
        }
    }
    private Dictionary<string, UIBase> _uiList = new();
    private string GetUIName<T>() where T : UIBase
    {
        return typeof(T).Name;
    }
    // UI를 열어주는 함수
    public T Open<T>() where T : UIBase // 타입 제한(UIBase를 상속받은 타입만 들어갈 수 있도록)
    {
        string uiName = GetUIName<T>();
        if (_uiList.ContainsKey(uiName) == false) // _uiList에 ui가 저장되어있지 않을경우
        {
            GameObject prefab = Resources.Load<GameObject>($"UI/{uiName}");
            if (prefab == null)
                throw new Exception($"Resources/UI/{uiName} 프리팹을 찾을 수 없습니다.");
            T ui = Instantiate(prefab).GetComponent<T>();
            ui.Open();
            _uiList.Add(uiName, ui);
            return ui;
        }
        UIBase savedUI = _uiList[uiName];
        savedUI.Open();
        return savedUI as T;
    }
    // UI를 닫아주는 함수
    public void Close<T>() where T : UIBase
    {
        string uiName = GetUIName<T>();
        if (_uiList.ContainsKey(uiName) == false)
            return;
        _uiList[uiName].Close();
    }
    // UI의 레퍼런스를 반환해주는 함수
    public T Get<T>() where T : UIBase
    {
        return _uiList[GetUIName<T>()] as T;
    }
}