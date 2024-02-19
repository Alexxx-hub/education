using UnityEngine;

public class Interactable : MonoBehaviour
{
    [HideInInspector] public SpriteRenderer Sprite { get; set; }

    protected bool _isActive;
    private void Awake()
    {
        Sprite = GetComponent<SpriteRenderer>();
    }

    private void OnMouseEnter()
    {
        _isActive = true;
    }

    private void OnMouseExit()
    {
        _isActive = false;
    }
}
