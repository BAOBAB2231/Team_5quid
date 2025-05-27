using UnityEngine;
public abstract class UIBase : MonoBehaviour
{
    public void Open()
    {
        gameObject.SetActive(true);
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void SetCanvasChildren()
    {
        
    }
}