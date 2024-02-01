using UnityEngine;

public abstract class UIElement : MonoBehaviour
{
    protected bool _opened = false;
    
    //---------------------------------------------------------------------------------------------------------------
    public virtual void Show()
    {
        if(_opened) return;
        gameObject.SetActive(true);
        _opened = true;
    }
    //---------------------------------------------------------------------------------------------------------------
    public virtual void Hide()
    {
        if(!_opened) return;
        gameObject.SetActive(false);
        _opened = false;
    }
    //---------------------------------------------------------------------------------------------------------------
}