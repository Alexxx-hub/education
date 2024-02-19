using UnityEngine;
using UnityEngine.EventSystems;

public delegate void UpdatePointer(bool activeState);

public class UIZone : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private UpdatePointer _updatePointer;

    public void Construct(UpdatePointer updatePointer)
    {
        _updatePointer = updatePointer;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Cursor.visible = true;
        _updatePointer?.Invoke(false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Cursor.visible = false;
        _updatePointer?.Invoke(true);
    }
}
