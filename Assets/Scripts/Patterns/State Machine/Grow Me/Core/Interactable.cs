using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Interactable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Color32 _activeColor;
    [SerializeField] private Color32 _defaultColor;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
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
