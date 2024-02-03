using UnityEngine;

[CreateAssetMenu(fileName = "Builder", menuName = "Burger/New Level Config")]
public class LevelConfig : ScriptableObject
{
    [SerializeField] private BurgerElement _pan;
    [SerializeField] private BurgerElement[] _BurgerElements;
    [SerializeField] private GameObject _ingridientButtonPrefab;

    public BurgerElement Pan => _pan;
    public BurgerElement[] BurgerElements => _BurgerElements;
    public GameObject IngridientButtonPrefab => _ingridientButtonPrefab;
}