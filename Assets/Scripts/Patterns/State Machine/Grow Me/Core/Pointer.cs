using UnityEngine;

public class Pointer : MonoBehaviour
{
    public Sprite[] _toolSprites;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        Vector2 newPos = _camera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = newPos;
    }

    public void SetSprite(int id)
    {
        _spriteRenderer.sprite = _toolSprites[id - 1];
    }

    public void SetAnimatorState(int id)
    {
        _animator.SetInteger("state", id);
    }

    public void SetAnimatorWork(bool work)
    {
        _animator.SetBool("work", work);
    }
}
