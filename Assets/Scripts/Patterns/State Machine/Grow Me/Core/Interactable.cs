using UnityEngine;
using UnityEngine.EventSystems;

public class Interactable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Color32 _activeColor;
    [SerializeField] private Color32 _defaultColor;

    private SpriteRenderer _image;

    private void Awake()
    {
        _image = GetComponent<SpriteRenderer>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
       _image.color = _activeColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _image.color = _defaultColor;
    }
}
