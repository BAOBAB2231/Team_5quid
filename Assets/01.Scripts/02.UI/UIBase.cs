using UnityEngine;
public abstract class UIBase : MonoBehaviour
{
    private Canvas canvas;

    //Canvas 있나 찾기
    private void Start()
    {
        canvas = FindAnyObjectByType<Canvas>();
    }

    public void Open()
    {
        gameObject.SetActive(true);
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }

    //프리팹 불러올 때 Canvas의 자식으로 설정하기
    public void SetCanvasChildren()
    {
        gameObject.transform.SetParent(canvas.transform, false);
    }
}