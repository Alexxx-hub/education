using UnityEngine;

public abstract class UIElement : MonoBehaviour
{
    [field: SerializeField] public Transform ContentArea { get; private set; }
    
    protected bool _opened;
    
    //---------------------------------------------------------------------------------------------------------------
    public virtual void Show()
    {
        if(_opened) return;
        ContentArea.gameObject.SetActive(true);
        _opened = true;
    }
    //---------------------------------------------------------------------------------------------------------------
    public virtual void Hide()
    {
        if(!_opened) return;
        ContentArea.gameObject.SetActive(false);
        _opened = false;
    }
    //---------------------------------------------------------------------------------------------------------------
}