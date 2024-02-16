using UnityEngine;

public class Interactable : MonoBehaviour
{
    [HideInInspector] public SpriteRenderer Sprite { get; set; }

    [SerializeField] private Color32 _activeColor;
    [SerializeField] private Color32 _defaultColor;

    private void Awake()
    {
        Sprite = GetComponent<SpriteRenderer>();
    }

    private void OnMouseEnter()
    {
        Sprite.color = _activeColor;
    }

    private void OnMouseExit()
    {
        Sprite.color = _defaultColor;
    }
}
