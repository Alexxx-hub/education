using UnityEngine;

[CreateAssetMenu(fileName = "Builder", menuName = "Burger/New Level Config")]
public class LevelConfig : ScriptableObject
{
    [SerializeField] private BurgerElement _pan;
    [SerializeField] private BurgerElement[] _BurgerElements;

    public BurgerElement Pan => _pan;
    public BurgerElement[] BurgerElements => _BurgerElements;
    
    
}